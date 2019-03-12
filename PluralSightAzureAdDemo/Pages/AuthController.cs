using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;

namespace PluralSightAzureAdDemo.Pages
{
    [Route("auth")]
    public class AuthController : Controller
    {
        [Route("signin")]
        public IActionResult SignIn()
        {
            return Challenge(new AuthenticationProperties { RedirectUri = "/" });
        }

        [Route("signout")]
        [HttpPost]
        public async Task SignOut()
        {
            //sign-out locally 
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            
            //sign-out on the identify provider end too.
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme); 
        }
    }
}