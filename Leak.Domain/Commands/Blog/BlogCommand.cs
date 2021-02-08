using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Blog
{
    public abstract class BlogCommand : Command
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public BlogCommand(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
