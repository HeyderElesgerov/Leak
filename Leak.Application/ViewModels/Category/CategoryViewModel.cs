using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Application.ViewModels.Category
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public CategoryViewModel(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public CategoryViewModel(string title) : this(default(int), title)
        {
        }
    }
}
