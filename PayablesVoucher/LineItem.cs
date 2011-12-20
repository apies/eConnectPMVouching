using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PayablesVoucher
{
    class LineItem
    {
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public string Distribution { get; set; }
    }
}
