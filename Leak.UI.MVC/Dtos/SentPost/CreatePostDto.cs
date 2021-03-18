using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.SentPost
{
    public class CreateSentPostDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public IFormFile PhotoFile { get; set; }

        public int BlogId { get; set; }

        public int CategoryId { get; set; }

        public Guid AuthorId { get; set; }
    }
}
