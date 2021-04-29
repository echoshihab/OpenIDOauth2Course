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
    }
}
