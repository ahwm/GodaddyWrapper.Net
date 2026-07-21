using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GodaddyWrapper.Base
{
    /// <summary>
    /// Thrown when a request object fails DataAnnotations validation before it is sent to GoDaddy.
    /// </summary>
    public class GodaddyValidationException : Exception
    {
        /// <summary>
        /// The individual validation failures that produced this exception.
        /// </summary>
        public IReadOnlyList<ValidationResult> ValidationResults { get; }

        public GodaddyValidationException(IReadOnlyList<ValidationResult> validationResults)
            : base(string.Join("\n", (validationResults ?? new List<ValidationResult>()).Select(c => c.ErrorMessage)))
        {
            ValidationResults = validationResults ?? new List<ValidationResult>();
        }
    }
}
