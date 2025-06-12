using SharedKernel.Domain.BaseEntities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.BaseEntities
{
    public abstract class AuditableAggregateRoot<TId> : AuditableEntity<TId>, IAggregateRoot
        where TId : IEquatable<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new();

        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        protected AuditableAggregateRoot() { }

        protected AuditableAggregateRoot(TId id)
            : base(id) { }

        public void RaiseEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);

        public void ClearEvents() => _domainEvents.Clear();

        public void RemoveDomainEvent(IDomainEvent domainEvent) => _domainEvents.Remove(domainEvent);
    }
}
