﻿using System.ComponentModel.DataAnnotations;

namespace FavoursShop.Core.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email/Username")]
        public string EmailOrUsername { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
