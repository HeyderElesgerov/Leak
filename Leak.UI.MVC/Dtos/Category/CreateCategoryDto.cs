﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Leak.UI.MVC.Dtos.Category
{
    public class CreateCategoryDto
    {
        [JsonProperty(PropertyName = "Title"), Required]
        public string Title { get; set; }
    }
}
