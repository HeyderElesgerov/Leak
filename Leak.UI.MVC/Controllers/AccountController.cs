using Leak.Domain.Enums;
using Leak.Domain.Models;
using Leak.UI.MVC.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Leak.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Login()
        {
            return View(new SignInModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signInModel)
        {
            if (ModelState.IsValid)
            {
                string email = signInModel.Email;
                string password = signInModel.Password;
                bool rememberMe = signInModel.RememberMe;

                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                    ModelState.AddModelError("", "Email or password is incorrect");
                else
                {
                    var signInResult = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);

                    if (signInResult.Succeeded)
                    {
                        if(await _userManager.IsInRoleAsync(user, UserRole.Admin))
                        {

                        }
                        else
                        {

                        }

                        throw new NotImplementedException("You have logged in, but next page is not implemented");
                    }

                    ModelState.AddModelError("", "Email or password is incorrect");
                }
            }

            return View(signInModel);
        }

        public IActionResult Register()
        {
            return View(new SignUpModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(SignUpModel signUpModel)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    UserName = signUpModel.FullName,
                    Email = signUpModel.Email
                };

                IdentityResult signUpResult = await _userManager.CreateAsync(newUser, signUpModel.Password);

                if (signUpResult.Succeeded)
                {
                    throw new NotImplementedException("You have registered successfully, but next page is not implemented");
                }

                foreach (var error in signUpResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }

            return View(signUpModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
