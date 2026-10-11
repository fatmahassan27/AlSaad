using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.Common.Exceptions
{
    public class ExternalServiceValidationException : Exception
    {
        public IReadOnlyList<string> Errors { get; }
        public bool IsDuplicate { get; }
        public int? ExistingId { get; }
        public ExternalServiceValidationException(IReadOnlyList<string> errors, bool isDuplicate = false, int? existingId = null)
            : base(errors.Count > 0 ? string.Join(" | ", errors) : "Validation failed.")
        {
            Errors = errors;
            IsDuplicate = isDuplicate;
            ExistingId = existingId;
        }
    }
}
