using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leak.UI.MVC.Dtos.AppUser
{
    public class UpdateUserInfoDto
    {
        [Required]
        public string FullName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IFormFile NewPhoto { get; set; }

        [Required]
        public string CurrentPhotoPath { get; set; }

        public bool IsUpdated { get; set; }
    }
}
