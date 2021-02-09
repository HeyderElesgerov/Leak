using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leak.Domain.Commands.Post
{
    public class DeletePostCommand : Command
    {
        public DeletePostCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
