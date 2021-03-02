using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Models
{
    public class SentPost : Post
    {
        public bool IsApproved { get; set; }
    }
}
