﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SharedKernel.Domain.BaseEntities
{
    public sealed record ValidationError : Error
    {
        public ValidationError(Error[] errors)
            : base("General.Validation", "One or more validation errors occurred", ErrorType.Validation)
        {
            Errors = errors;
        }

        public Error[] Errors { get; }

        public static ValidationError FromResults(IEnumerable<Result> results) =>
            new(results.Where(r => r.IsFailure).Select(r => r.Error).ToArray());
    }
}
