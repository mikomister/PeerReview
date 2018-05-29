using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.ManageViewModel
{
    public class CreateInviteViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}