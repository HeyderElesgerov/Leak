using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.Post
{
    public class CreatePostDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public IFormFile PhotoFile { get; set; }

        public int BlogId { get; set; }

        public int CategoryId { get; set; }

        public bool IsActive { get; set; }
    }
}
