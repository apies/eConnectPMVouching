using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using CsvHelper;

namespace PayablesVoucher
{
    class Bill
    {
        public IEnumerable<LineItem> XmlBillParse(string billpath)
        {
          

            XElement bill = XElement.Parse(billpath); 

            foreach (XElement line in bill.Elements("Breakdown_TotalCharges_Details xmlns:fo=\"http://www.w3.org/1999/XSL/Format\"").Elements("Breakdown_TotalCharges_Record"))
            {
                LineItem lineItem = new LineItem();
                lineItem.Amount = Convert.ToDecimal(bill.Element("Breakdown_Total_Chrgs").Value);
                lineItem.Description = bill.Element("Breakdown_TotalCharges_PhoneNumber").Value + bill.Element("Breakdown_TotalCharges_UserName").Value;
                lineItem.Distribution = "";
                yield return lineItem;
            }


        }


        public IEnumerable<LineItem> CsvBillParse(string path)
        {
            var sr = new StreamReader(path);
            var csvReader = new CsvReader(sr);

            while (csvReader.Read())
            {

                if (csvReader.GetField("User_ID") != null && csvReader.GetField("User_ID") != "")
                {
                    LineItem lineItem = new LineItem();
                    lineItem.Amount = Convert.ToDecimal(csvReader.GetField("Total_Current_Chgs").Substring(1));
                    lineItem.Description = csvReader.GetField("User_Name") + csvReader.GetField("Wireless Number");
                    //lineItem.Distribution = CodeLookup(csvReader.GetField("User_ID"));
                    lineItem.Distribution = csvReader.GetField("Cost_Center");
                    yield return lineItem;
                }

            }
            
        }


        public string CodeLookup(string employeeid)
        {
            Employee employee = new Employee();
            XElement xEmployee = employee.GPQue(employeeid);
            employee = employee.MakeOneModel(xEmployee);
            string employeeDept = employee.Department;
            Dictionary<string, string> deptDictionary = employee.DeptCode("7700", "6700");
            string deptCode = deptDictionary[employeeDept];

            return deptCode;

        }


    }
}
