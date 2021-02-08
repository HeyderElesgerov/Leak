using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Url
{
    public abstract class UrlCommand : Command
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public UrlCommand(int id, string path)
        {
            Id = id;
            Path = path;
        }
    }
}
