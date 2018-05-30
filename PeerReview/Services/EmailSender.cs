using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MailKit;
using MimeKit;

namespace PeerReview.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage emailMessage = new MailMessage();

            emailMessage.From = new MailAddress("net.konkov.11@gmail.com");
            emailMessage.To.Add(new MailAddress(email));
            emailMessage.Subject = subject;
            emailMessage.SubjectEncoding = Encoding.UTF8;
            emailMessage.Priority = MailPriority.High;
            emailMessage.IsBodyHtml = false;
            emailMessage.Body = message;
            var client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("net.konkov.11@gmail.com", "agtxjet*0sp23_");
            client.SendCompleted += (s, e) =>
            {
                if (e.Error == null)
                {
                    client.Dispose();
                    emailMessage.Dispose();
                }
                else
                {
                    throw new SmtpException($"Message not sended! {e.Error.Message}");
                }
            };
            await client.SendMailAsync(emailMessage);
        }
    }
}