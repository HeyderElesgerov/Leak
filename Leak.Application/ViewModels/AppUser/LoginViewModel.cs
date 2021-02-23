using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.ViewModels.AppUser
{
    class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public LoginViewModel(string email, string password, bool remeberMe = false)
        {
            Email = email;
            Password = password;
            RememberMe = remeberMe;
        }
    }
}
