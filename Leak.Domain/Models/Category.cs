using Leak.Domain.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Models
{
    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }

        public Category()//for ef
        {
        }

        public Category(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public Category(string title)
        {
            Title = title;
        }

        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }
    }
}
