using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [JsonProperty(PropertyName = "Id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "Title"), Required]
        public string Title { get; set; }
    }
}
