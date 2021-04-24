using IdentityModel;
using IdentityServer4;
using IdentityServer4.Services;
using IServer.IDP.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IServer.IDP.UserRegistration
{
    public class UserRegistrationController: Controller
    {
        private readonly ILocalUserService _localUserService;
        private readonly IIdentityServerInteractionService _interaction;

        public UserRegistrationController(ILocalUserService localUserService,
            IIdentityServerInteractionService interaction)
        {
            _localUserService = localUserService ??
                throw new ArgumentNullException(nameof(localUserService));
            _interaction = interaction ??
                throw new ArgumentNullException(nameof(interaction));
        }

        [HttpGet]
        public IActionResult RegisterUser(string returnUrl)
        {
            var vm = new RegisterUserViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userToCreate = new Entities.User
            {
                Password = model.Password,
                UserName = model.UserName,
                Subject = Guid.NewGuid().ToString(),
                Active = true
            };

            userToCreate.Claims.Add(new Entities.UserClaim()
            {
                Type= "country",
                Value = model.Country
            });

            userToCreate.Claims.Add(new Entities.UserClaim()
            {
                Type = JwtClaimTypes.Address,
                Value = model.Address
            });

            userToCreate.Claims.Add(new Entities.UserClaim()
            {
                Type = JwtClaimTypes.GivenName,
                Value = model.GivenName
            });

            userToCreate.Claims.Add(new Entities.UserClaim()
            {
                Type = JwtClaimTypes.FamilyName,
                Value = model.FamilyName
            });

            _localUserService.AddUser(userToCreate);
            await _localUserService.SaveChangesAsync();

            //log the user in
            await HttpContext.SignInAsync(new IdentityServerUser(userToCreate.UserName));

            if (_interaction.IsValidReturnUrl(model.ReturnUrl) 
                || Url.IsLocalUrl(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return Redirect("~/");
        }
    }
}
