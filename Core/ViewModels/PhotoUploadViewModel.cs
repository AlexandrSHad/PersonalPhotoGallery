using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.ViewModels
{
    public class PhotoUploadViewModel
    {
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose a photo.")]
        [Display(Name = "File path")]
        public IFormFile File { get; set; }
    }
}
