using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Leak.UI.MVC.Dtos.Post
{
    public class UpdatePostDto
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title"), JsonRequired]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "Content"), JsonRequired]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "Photo")]
        public IFormFile PhotoFile { get; set; }

        [JsonProperty(PropertyName = "BlogId")]
        public int BlogId { get; set; }

        [JsonProperty(PropertyName = "CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty(PropertyName = "IsActive")]
        public bool IsActive { get; set; }
    }
}
