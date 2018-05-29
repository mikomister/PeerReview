using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.TasksViewModel
{
    public class CreateViewModel
    {
        [Required(ErrorMessage="Необходимо указать название задания.")]
        [Display(Name = "Название задания")]
        public string Title { get; set; }
         
        [Required(ErrorMessage="Описание не может быть пустым.")]
        [StringLength (65535, MinimumLength=128,ErrorMessage="Размер описания должен быть от 128 до 65535 символов")]
        [Display(Name = "Описание задания:")]
        public string Descrition { get; set; }
        
        [Required(ErrorMessage="Описание не может быть пустым.")]
        [Display(Name = "Сдать до:")]
        public string ExpirationDate { get; set; }
        
        public string ReturnUrl { get; set; }
    }
}