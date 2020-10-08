using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartUpdateBulk
    {
        public List<CartListingAdd> Listings { get; set; }
        public List<CartItemUpdateBulk> Items { get; set; }
        public List<CartGroupUpdateBulk> Groups { get; set; }
        public List<CartDomainContacts> Contacts { get; set; }
        public List<CartItemTracking> Tracking { get; set; }
        public string ItemSourceCode { get; set; }
        public List<BillToUpdate> BillTo { get; set; }
    }
}
