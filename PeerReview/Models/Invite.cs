using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace PeerReview.Models
{
    public class Invite
    {
        [Key] 
        public int Id { get; set; }
        
        public string InviteCode { get; set; }

        public Invite(User user)
        {
            this.InviteCode = GenerateInvite(user.Id.GetHashCode() * 13 + (new Random().Next(10, 10000)) + "", user);
        }

        public int UserId { get; set; }
        public User User { get; set; }
        
        private string GenerateInvite(string key, User user)
        {
            var toEncrypt = key + user.ConcurrencyStamp + user.Email + new Random().NextDouble() * 100 +
                            new DateTime();
            return GetSHA256Hash(SHA256.Create(), toEncrypt);
        }

        private string GetSHA256Hash(SHA256 sha256Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}