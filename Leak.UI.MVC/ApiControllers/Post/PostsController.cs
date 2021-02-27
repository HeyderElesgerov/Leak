using Leak.Application.Interfaces;
using Leak.Application.ViewModels.Post;
using Leak.UI.MVC.Dtos.Post;
using Leak.UI.MVC.Utility;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace Leak.UI.MVC.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        private readonly IFileService _fileService;
        private readonly string PostPhotosFolder;

        public PostsController(IPostService postService, IFileService fileService, IWebHostEnvironment webHostEnvironment)
        {
            _postService = postService;
            _fileService = fileService;
            PostPhotosFolder = Path.Combine(webHostEnvironment.WebRootPath, "PostPhotos");
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm]CreatePostDto createPostDto)
        {
            try
            {
                string createdFilePath = _fileService.CreateLocalFile(createPostDto.PhotoFile, PostPhotosFolder);

                CreatePostViewModel createPostViewModel = CustomMapper.GetCreatePostViewModel(createPostDto, createdFilePath);
                var result = await _postService.Add(createPostViewModel);

                if (result.IsValid)
                    return Ok();

                return BadRequest(result.Errors);
            }
            catch (IOException) { }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm]UpdatePostDto updatePostDto)
        {
            UpdatePostViewModel updatePostViewModel = CustomMapper.GetUpdatePostViewModel(updatePostDto);

            if (updatePostDto.PhotoFile != null)
            {
                var post = await _postService.GetById(updatePostDto.Id);
                string existingFilePath = post.HeaderPhotoPath;

                try
                {
                    _fileService.UpdateLocalFile(updatePostDto.PhotoFile, existingFilePath);
                }
                catch (IOException) { }
            }

            var result = await _postService.Update(updatePostViewModel);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _postService.GetById(id);
            string filePath = post.HeaderPhotoPath;
            try
            {
                _fileService.DeleteLocalFile(filePath);
            }
            catch (IOException) { }

            var result = await _postService.Delete(id);

            if (result.IsValid)
                return Ok();

            return BadRequest(result.Errors);
        }
    }
}
