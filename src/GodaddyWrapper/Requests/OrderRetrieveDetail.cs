using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class OrderRetrieveDetail
    {
        [Required]
        public string orderId { get; set; }
    }
}
