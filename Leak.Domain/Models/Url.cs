using System;
using System.Collections.Generic;
using System.Text;
using Leak.Domain.Core.Entity;

namespace Leak.Domain.Models
{
    public class Url : BaseEntity<int>
    {
        public string Path { get; set; }
    }
}
