using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.SubmissionViewModel
{
    public class SubmissionViewModel
    {
        [Required(ErrorMessage="Необходимо указать название задачи!")]
        [StringLength (128, MinimumLength=8,ErrorMessage="Длина строки должна быть от 8 до 128 символов")]
        [Display(Name = "Название задачи")]
        public string Title { get; set; }
         
        [Required(ErrorMessage="Решение не может быть пустым!")]
        [StringLength (4096, MinimumLength=128,ErrorMessage="Размер решения должен быть от 128 до 4096 символов")]
        [Display(Name = "Решение")]
        public string Code { get; set; }        
    }
}