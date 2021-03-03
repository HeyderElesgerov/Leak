using Leak.Domain.Core.Command;

namespace Leak.Domain.Commands.SentPost
{
    public class ApproveSentPostCommand : Command
    {
        public int Id { get; private set; }

        public ApproveSentPostCommand(int id)
        {
            Id = id;
        }
    }
}
