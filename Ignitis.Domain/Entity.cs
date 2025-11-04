using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ignitis.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTimeOffset Created { get; protected set; }
        public DateTimeOffset Modified { get; protected set; }

        public void Modify(DateTimeOffset modified)
        {
            Modified = modified;
        }

        protected void EntityCreated(DateTimeOffset now)
        {
            Created = now;
            Modified = now;
        }
    }
}
