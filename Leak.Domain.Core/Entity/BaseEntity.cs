using System;
using System.Collections.Generic;
using System.Text;

namespace Leak.Domain.Core.Entity
{
    public abstract class BaseEntity<TKey> : IEntity
    {
        public TKey Id { get; set; }
    }
}
