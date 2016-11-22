using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Attributes
{
    [AttributeUsage(AttributeTargets.Property |
AttributeTargets.Field, AllowMultiple = false)]
    sealed internal class DNSRecordTypeAttribtue : ValidationAttribute
    {
        public List<string> ValidValue = new List<string> { "AA", "AAAA", "CNAME", "MX", "NS", "SOA", "SRV", "TXT" };
        public override bool IsValid(object value)
        {
            if (value == null)
                return true;
            if (ValidValue.FirstOrDefault(c => c == value.ToString().ToUpper()) == null)
                return false;
            else
                return true;
        }
    }
}
