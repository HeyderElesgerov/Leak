using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.Application.ViewModels.SentPost;
using Leak.Domain.Models;
using Leak.UI.MVC.Dtos.SentPost;
using Leak.UI.MVC.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentPostsController : ControllerBase
    {
        private readonly ISentPostService _sentPostService;
        private readonly IFileService _fileService;
        private readonly UserManager<AppUser> _userManager;
        private readonly string PostPhotosFolder;

        public SentPostsController(ISentPostService sentPostService, IFileService fileService, IWebHostEnvironment webHostEnvironment, UserManager<AppUser> userManager)
        {
            _sentPostService = sentPostService;
            _fileService = fileService;
            _userManager = userManager;
            PostPhotosFolder = Path.Combine(webHostEnvironment.WebRootPath, "PostPhotos");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] CreateSentPostDto createSentPostDto)
        {
            try
            {
                string createdFilePath = _fileService.CreateLocalFile(createSentPostDto.PhotoFile, PostPhotosFolder);

                var user = await _userManager.GetUserAsync(User);

                if (user == null)
                    return BadRequest();

                createSentPostDto.AuthorId = user.Id;

                CreateSentPostViewModel createPostViewModel = CustomMapper.GetCreateSentPostViewModel(createSentPostDto, createdFilePath);
                var result = await _sentPostService.Add(createPostViewModel);

                if (result.IsValid)
                    return Ok();

                return BadRequest(result.Errors);
            }
            catch (IOException) { }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Approve(int id)
        {
            var result = await _sentPostService.Approve(id);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _sentPostService.GetById(id);
            string filePath = post.HeaderPhotoPath;
            try
            {
                _fileService.DeleteLocalFile(filePath);
            }
            catch (IOException) { }

            var result = await _sentPostService.Delete(id);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
