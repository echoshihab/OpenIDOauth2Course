using IServer.IDP.PasswordReset;
using IServer.IDP.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IServer.IDP.Quickstart.PasswordReset
{
    public class PasswordResetController : Controller
    {
        private readonly ILocalUserService _localuserService;

        public PasswordResetController(ILocalUserService localuserService)
        {
            _localuserService = localuserService ??
                throw new ArgumentNullException(nameof(localuserService));
        }

        [HttpGet]
        public IActionResult RequestPassword()
        {
            var vm = new RequestPasswordViewModel();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestPassword(RequestPasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var securityCode = await _localuserService
                .InitiatePasswordResetRequest(model.Email);
            await _localuserService.SaveChangesAsync();

            //create an activation link
            var link = Url.ActionLink("ResetPassword", "PasswordReset", new { securityCode });

            Debug.WriteLine(link);

            return View("PasswordResetRequestSent");
        }

        [HttpGet]
        public IActionResult ResetPassword(string securityCode)
        {
            var vm = new ResetPasswordViewModel()
            {
                SecurityCode = securityCode
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if(await _localuserService.SetPassword(model.SecurityCode, model.Password))
            {
                ViewData["Message"] = "Your password has successfully change. " +
                    "Navigate to your client application to log in.";

            }
            else
            {
                ViewData["Message"] = "Your password couldn't be changed, please" +
                    "contact your administrator";
            }

            await _localuserService.SaveChangesAsync();

            return View("ResetPasswordResult");
        }
    }
}
