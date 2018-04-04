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
        public string Email { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        public string Password { get; set; }
    }
}
