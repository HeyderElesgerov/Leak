using Leak.Application.Interfaces;
using Leak.Domain.Enums;
using Leak.Domain.Models;
using Leak.UI.MVC.Dtos.AppUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Leak.UI.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileService _fileservice;

        public UserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Update()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            var updateuserDto = new UpdateUserInfoDto()
            {
                Email = user.Email,
                FullName = user.FullName,
                CurrentPhotoPath = user.PhotoFileName
            };

            return View(updateuserDto);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(UpdateUserInfoDto updateUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                    return NotFound();

                user.Email = updateUserDto.Email;
                user.FullName = updateUserDto.FullName;

                if (updateUserDto.NewPhoto != null)
                {
                    try
                    {
                        _fileservice.UpdateLocalFile(updateUserDto.NewPhoto, updateUserDto.CurrentPhotoPath);
                        var updateResult = await _userManager.UpdateAsync(user);

                        if (updateResult.Succeeded)
                            updateUserDto.IsUpdated = true;
                        else
                        {
                            foreach (var error in updateResult.Errors)
                            {
                                ModelState.AddModelError(error.Code, error.Description);
                            }
                        }
                    }
                    catch (IOException)
                    {
                        ModelState.AddModelError("", "Unable to update photo");
                    }
                }
            }

            return View(updateUserDto);
        }

        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return NotFound();

            return View(new ChangePasswordDto());
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                    return NotFound();

                var result = await _userManager.ChangePasswordAsync(user, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);

                if (result.Succeeded)
                    changePasswordDto.IsUpdated = true;
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }

            return View(changePasswordDto);
        }
    }
}
