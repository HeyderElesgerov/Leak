using Leak.Domain.Core.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public string PhotoFileName { get; set; }
        
        public List<Post> Posts { get; set; }
    }
}
