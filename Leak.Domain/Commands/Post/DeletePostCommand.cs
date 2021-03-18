using Leak.Domain.Core.Command;

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
