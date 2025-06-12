using SharedKernel.Domain.BaseEntities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Domain.BaseEntities
{
    public class AuditableEntity<TId> : Entity<TId>, IAuditable
       where TId : IEquatable<TId>
    {
        protected AuditableEntity() { }

        protected AuditableEntity(TId id)
            : base(id) { }

        public string? CreatedBy { get; protected set; }
        public DateTime CreatedOnUtc { get; protected set; }
        public string? ModifiedBy { get; protected set; }
        public DateTime? ModifiedOnUtc { get; protected set; }
    }
}
