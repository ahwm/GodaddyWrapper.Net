using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Responses
{
    public class CartResponse
    {
        public string Currency { get; set; }
        public List<object> AgreementKeys { get; set; }
        public List<CartItemResponse> Items { get; set; }
        public List<CartGroupResponse> Groups { get; set; }
        public List<CartDomainContactsResponse> Contacts { get; set; }
        public string ItemSourceCode { get; set; }
        public CartPricingResponse Pricing { get; set; }
        public string ItemSourceCodeDetail { get; set; }
        public BillToResponse BillTo { get; set; }

    }
}
