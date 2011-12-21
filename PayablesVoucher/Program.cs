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
            IEnumerable<LineItem> lineItems = vBill.CsvBillParse(@"c:\dump\vBill.csv");
            /*foreach (LineItem lineItem in lineItems)
            {
                
                Console.WriteLine("{0} {1}",lineItem.Description, lineItem.Amount);
               // Console.ReadKey();
              
            } */


           string nowDate = DateTime.Today.ToShortDateString();
            
            Voucher pmVoucher = new Voucher();
            XElement xVoucher = pmVoucher.MakeXmlVoucher(lineItems, "Verizon" + nowDate, "Verizon" + nowDate);
            xVoucher.Save(@"c:\dump\Voucher.xml");

            Console.WriteLine(xVoucher.ToString());

            Console.ReadKey();
        }
    }
}
