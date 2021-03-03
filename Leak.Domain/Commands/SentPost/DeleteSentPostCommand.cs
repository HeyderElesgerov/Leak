using Leak.Domain.Commands.Post;
using Leak.Domain.Core.Command;

namespace Leak.Domain.Commands.SentPost
{
    public class DeleteSentPostCommand : Command
    {
        public int Id { get; set; }

        public DeleteSentPostCommand(int id)
        {
            Id = id;
        }
    }
}
