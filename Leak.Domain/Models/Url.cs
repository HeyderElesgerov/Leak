using System;
using System.Collections.Generic;
using System.Text;
using Leak.Domain.Core.Entity;

namespace Leak.Domain.Models
{
    public class Url : BaseEntity<int>
    {
        public string Path { get; set; }

        public Url()
        {
        }

        public Url(int id, string path)
        {
            Id = id;
            Path = path;
        }

        public Url(string path) : this(0, path)
        {
        }
    }
}
