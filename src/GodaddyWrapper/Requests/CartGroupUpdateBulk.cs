using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodaddyWrapper.Requests
{
    public class CartGroupUpdateBulk
    {
        public string GroupKey { get; set; }
        public List<CartItemUpdateBulk> Items { get; set; }
    }
}
