using POne.Core.CQRS;
using System;
using System.Collections.Generic;

namespace POne.Core.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime Creation { get; private set; }
        public DateTime? LastUpdate { get; protected set; }
        public bool IsDeleted { get; private set; }

        private readonly List<IEvent> _events = new();
        public IReadOnlyCollection<IEvent> Events => _events.AsReadOnly();

        protected Entity()
        {
            Id = Guid.NewGuid();
            Creation = DateTime.Now;
            IsDeleted = false;
        }

        public void AddEvent<T>(T param) where T : IEvent
        {
            _events.Add(param);
        }

        public void RemoveEvent<T>(T param) where T : IEvent
        {
            _events.Remove(param);
        }

        public void ClearEvents()
        {
            _events.Clear();
        }

        public void MarkAsDeleted()
        {
            IsDeleted = true;
        }
    }
}
