using Leak.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.Services
{
    class UserService
    {
        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;

        public UserService(
            UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //public async Task<SignInResult> LoginAsync(LoginViewModel loginViewModel)
        //{
        //    AppUser appUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
            
        //    var result = await _signInManager.PasswordSignInAsync(
        //        appUser, loginViewModel.Password, loginViewModel.RememberMe, false);

        //    return result;
        //}
    }
}
