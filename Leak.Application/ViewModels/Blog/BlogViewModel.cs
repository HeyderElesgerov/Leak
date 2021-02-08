using Leak.Application.ViewModels.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.ViewModels.Blog
{
    public class BlogViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int UrlId { get; set; }

        public string UrlPath { get; set; }

        public BlogViewModel(int id, string title, UrlViewModel urlViewModel)
        {
            Id = id;
            Title = title;

            if(urlViewModel != null)
            {
                UrlId = urlViewModel.Id;
                UrlPath = urlViewModel.Path;
            }
        }

        public BlogViewModel(string title, UrlViewModel urlViewModel)
            : this(0, title, urlViewModel)
        {
        }

        public BlogViewModel(int id)
            : this(id, String.Empty, default(UrlViewModel))
        {
        }
    }
}
