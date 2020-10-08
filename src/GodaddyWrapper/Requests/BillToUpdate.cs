using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class BillToUpdate
    {
        public string TaxId { get; set; }
        public ContactUpdate Contact { get; set; }
    }
}
