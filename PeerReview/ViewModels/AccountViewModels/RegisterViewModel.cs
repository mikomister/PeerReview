﻿using System.ComponentModel.DataAnnotations;

namespace PeerReview.ViewModels.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Invite")]
        public string Invite { get; set; }
        
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
 
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
 
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}