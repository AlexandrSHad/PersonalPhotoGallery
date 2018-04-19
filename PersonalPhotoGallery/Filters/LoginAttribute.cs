using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPhotoGallery.Filters
{
    public class LoginAttribute : Attribute, IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginAttribute(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var currentUser = _httpContextAccessor.HttpContext.Session.GetString("User");

            if (string.IsNullOrEmpty(currentUser))
            {
                context.Result = new RedirectToActionResult("Index", "Logins", null);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
