using System;
using System.Collections.Generic;
using System.Text;
using Leak.Domain.Core.Entity;

namespace Leak.Domain.Models
{
    public class Blog : BaseEntity<int>
    {
        public string Title { get; set; }

        public int UrlId { get; set; }
        public Url Url { get; set; }

        public List<Post> Posts { get; set; }

        public Blog()
        {
        }

        public Blog(string title, Url url)
        {
            Title = title;
        }
    }
}
