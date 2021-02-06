using Leak.Domain.Core.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Commands.Category
{
    public class CategoryCommand : Command
    {
        public int Id { get; set; }

        public string CategoryTitle { get; set; }
    }
}
