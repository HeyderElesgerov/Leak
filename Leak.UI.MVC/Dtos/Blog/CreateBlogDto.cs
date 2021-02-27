using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.Blog
{
    public class CreateBlogDto
    {
        [JsonProperty(propertyName: "Title"), Required]
        public string Title { get; set; }
    }
}
