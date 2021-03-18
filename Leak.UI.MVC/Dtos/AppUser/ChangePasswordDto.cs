using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leak.UI.MVC.Dtos.AppUser
{
    public class ChangePasswordDto
    {
        [Required, DataType(DataType.Password)]
        public string CurrentPassword{ get; set; }

        [Required, DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, DataType(DataType.Password)]
        public string ReNewPassword { get; set; }

        public bool IsUpdated { get; set; }
    }
}
