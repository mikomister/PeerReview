using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.SubmissionViewModel
{
    public class SubmissionViewModel
    {
        [Required(ErrorMessage="Необходимо выбрать задачу!")]
        [Display(Name = "Задача:")]
        public string Task { get; set; }
         
        [Required(ErrorMessage="Решение не может быть пустым!")]
        [StringLength (4096, MinimumLength=128,ErrorMessage="Размер решения должен быть от 128 до 4096 символов")]
        [Display(Name = "Решение")]
        public string Code { get; set; }        
    }
}