using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.Blog
{
    public class UpdateBlogDto
    {
        [JsonProperty(propertyName: "Id")]
        public int Id { get; set; }

        [JsonProperty(propertyName: "Title"), Required]
        public string Title { get; set; }
    }
}
