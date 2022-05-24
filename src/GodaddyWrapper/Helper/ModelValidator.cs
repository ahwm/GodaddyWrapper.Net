using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace GodaddyWrapper.Helper
{
    internal static class ModelValidator
    {
        public static bool IsValid(object value, out List<ValidationResult> results)
        {
            ValidationContext context = new ValidationContext(value, null, null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(value, context, results, true);
        }
    }
}
