using Leak.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Models
{
    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }
    }
}
