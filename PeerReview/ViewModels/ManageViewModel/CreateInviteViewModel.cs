using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.ManageViewModel
{
    public class CreateInviteViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
    }
}