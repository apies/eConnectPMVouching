using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PayablesVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            Bill vBill = new Bill();
            IEnumerable<LineItem> lineItems = vBill.XmlBillParse(@"c:\sdump\vsbill.xml");
            foreach (LineItem lineItem in lineItems)
            {
                Console.WriteLine(lineItem.Description);
            }
        }
    }
}
