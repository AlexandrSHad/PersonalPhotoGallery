using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please provide email address")]
        [EmailAddress]
        [Display(Name = "Email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
