using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class DomainAgreements
    {
        public List<string> Tlds { get; set; }
        public bool Privacy { get; set; }
        public bool ForTransfer { get; set; }
    }
}
