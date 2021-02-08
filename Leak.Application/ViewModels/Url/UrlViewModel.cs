using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Application.ViewModels.Url
{
    public class UrlViewModel
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public UrlViewModel(int id, string path)
        {
            Id = id;
            Path = path;
        }

        public UrlViewModel(string path) : this(default(int), path)
        {
        }

        public UrlViewModel(int id) : this(id, string.Empty)
        {
        }
    }
}
