using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.SubmissionViewModel
{
    public class SubmissionViewModel
    {
        [Required(ErrorMessage="Решение не может быть пустым!")]
        [StringLength (4096, MinimumLength=128,ErrorMessage="Размер решения должен быть от 128 до 4096 символов")]
        [Display(Name = "Решение")]
        public string Code { get; set; }    
        [Required(ErrorMessage="Необходимо выбрать задачу!")]
        public int TaskId { get; set; }
    }
}