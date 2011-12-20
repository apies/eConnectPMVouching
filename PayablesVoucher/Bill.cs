using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace PayablesVoucher
{
    class Bill
    {
        public IEnumerable<LineItem> XmlBillParse(string billpath)
        {
            XElement bill = XElement.Parse(billpath);

            foreach (XElement line in bill.Element("Breakdown_TotalCharges_Details").Elements("Breakdown_TotalCharges_Record"))
            {
                LineItem lineItem = new LineItem();
                lineItem.Amount = Convert.ToDecimal(bill.Element("Breakdown_Total_Chrgs").Value);
                lineItem.Description = bill.Element("Breakdown_TotalCharges_PhoneNumber").Value + bill.Element("Breakdown_TotalCharges_UserName").Value;
                lineItem.Distribution = "";
                yield return lineItem;
            }


        }
    }
}
