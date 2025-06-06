using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.SharedKernel.Domain.BaseEntities.Contracts
{
    public interface IAuditable
    {
        string? CreatedBy { get; }
        DateTime CreatedOnUtc { get; }
        string? ModifiedBy { get; }
        DateTime? ModifiedOnUtc { get; }
    }
}
