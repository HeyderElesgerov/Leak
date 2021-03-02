using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.Blog
{
    public class CreateBlogDto
    {
        [Required]
        public string Title { get; set; }
    }
}
