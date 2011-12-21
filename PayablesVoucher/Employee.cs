using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Dynamics.GP.eConnect;

namespace PayablesVoucher
{
    class Employee
    {



        ///Will probably implement a more complex constructer at some point.
        /*public Employee(int count)
        {
            count = 0;
            XElement blob = GPQue();
            Employee pemployeesAll = new Employee();
            IEnumerable<Employee> employeeAll = pemployeesAll.MakeModel(blob);

        }*/

        public Employee()
        {


        }


        //public XElement blob { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Department { get; set; }
        public string LastName { get; set; }
        public string TaosCell { get; set; }
        public string EmployeeID { get; set; }
        public string SalesForceID { get; set; }
        public string LastFirstMIName { get; set; }
        public string FirstLastName { get; set; }
        public string MiddleInitial { get; set; }
        public string TaosCellPhone { get; set; }

        public IEnumerable<Employee> employeeAll { get; set; }
        public XElement blob { get; set; }

        public Dictionary<string, string> deptCodes { get; set; }

        public Dictionary<string, string> DeptCode(string internalcode, string externalcode)
        {

            Dictionary<string, string> deptDictionary = new Dictionary<string, string>();



            deptDictionary.Add("ACCT", "25-" + internalcode + "-10-110-01");
            deptDictionary.Add("ADMIN", "25-" + internalcode + "-10-140-01");
            deptDictionary.Add("AMBO", "25-" + internalcode + "-40-210-06");
            deptDictionary.Add("AMID", "25-" + internalcode + "-30-210-01");
            deptDictionary.Add("AMSC", "25-" + internalcode + "-20-210-01");
            deptDictionary.Add("ARCMGT", "25-" + externalcode + "-80-900-01");
            deptDictionary.Add("CNTADM", "25-" + internalcode + "-10-135-01");
            deptDictionary.Add("CNTAVD", "25-" + externalcode + "-20-800-01");
            deptDictionary.Add("CNTRBO", "25-" + externalcode + "-40-500-06");
            deptDictionary.Add("CNTRCO", "25-" + externalcode + "-20-500-08");
            deptDictionary.Add("CNTRCT", "25-" + externalcode + "-20-500-01");
            deptDictionary.Add("CNTRID", "25-" + externalcode + "-20-500-06");
            deptDictionary.Add("CNTRMN", "25-" + externalcode + "-20-500-07");
            deptDictionary.Add("CNTRNC", "25-" + externalcode + "-40-500-03");
            deptDictionary.Add("CNTRSF", "25-" + externalcode + "-20-500-05");
            deptDictionary.Add("CNTRTX", "25-" + externalcode + "-20-500-03");
            deptDictionary.Add("DMBO", "25-" + internalcode + "-20-215-06");
            deptDictionary.Add("EXEC", "25-" + internalcode + "-10-100-01");
            deptDictionary.Add("EXECEN", "25-" + internalcode + "-10-100-04");
            deptDictionary.Add("FNANCE", "25-" + internalcode + "-10-130-01");
            deptDictionary.Add("HR", "25-" + internalcode + "-10-120-01");
            deptDictionary.Add("HR ID", "25-" + internalcode + "-10-120-06");
            deptDictionary.Add("INFRBO", "25-" + externalcode + "-30-700-06");
            deptDictionary.Add("INPRBO", "25-" + internalcode + "-30-290-06");
            deptDictionary.Add("INSRBO", "25-" + externalcode + "-30-300-06");
            deptDictionary.Add("INSRSC", "25-" + externalcode + "-30-300-01");
            deptDictionary.Add("MGDEXC", "25-" + internalcode + "-30-280-01");
            deptDictionary.Add("MIS", "25-" + internalcode + "-10-160-01");
            deptDictionary.Add("MKTSAL", "25-" + internalcode + "-20-205-01");
            deptDictionary.Add("MRKT", "25-" + internalcode + "-10-170-01");
            deptDictionary.Add("OCIOSC", "25-" + externalcode + "-60-800-01");
            deptDictionary.Add("OPEXEC", "25-" + internalcode + "-10-139-01");
            deptDictionary.Add("PRJMGT", "25-" + internalcode + "-20-229-01");
            deptDictionary.Add("RCRTBO", "25-" + internalcode + "-10-220-06");
            deptDictionary.Add("RCRTEN", "25-" + internalcode + "-10-220-04");
            deptDictionary.Add("RCRTM", "25-" + internalcode + "-20-220-01");
            deptDictionary.Add("RCRTME", "25-" + internalcode + "-10-228-01");
            deptDictionary.Add("RCRTU", "25-" + internalcode + "-10-222-01");
            deptDictionary.Add("RCRUIT", "25-" + internalcode + "-10-220-01");
            deptDictionary.Add("RMBO", "25-" + internalcode + "-10-222-06");
            deptDictionary.Add("SALEBO", "25-" + internalcode + "-40-200-06");
            deptDictionary.Add("SALEMG", "25-" + internalcode + "-20-209-01");
            deptDictionary.Add("SALES", "25-" + internalcode + "-20-200-01");
            deptDictionary.Add("SMSC", "25-" + internalcode + "-20-235-01");
            deptDictionary.Add("TRANBO", "25-" + externalcode + "-30-310-06");
            deptDictionary.Add("TSG", "25-" + internalcode + "-20-230-01");
            deptDictionary.Add("SALEEN", "25-" + internalcode + "-20-234-01");
            deptDictionary.Add("TSGMGS", "25-" + externalcode + "-60-600-01");
            deptDictionary.Add("CNTRNY", "25-" + externalcode + "-20-500-02");
            deptDictionary.Add("SMID", "25-" + internalcode + "-20-235-06");
            deptDictionary.Add("SMP&A", "25-" + internalcode + "-80-235-01");
            deptDictionary.Add("INPRMG", "25-" + internalcode + "-30-295-06");
            deptDictionary.Add("AMWC", "25-" + internalcode + "-20-210-99");
            deptDictionary.Add("CNTCT2", "25-" + internalcode + "-40-500-01");
            deptDictionary.Add("SOLENG", "25-" + internalcode + "-20-234-01");
            deptDictionary.Add("ADMNID", "25-" + internalcode + "-10-140-06");
            deptDictionary.Add("", "MISSING");


            return deptDictionary;



        }












        public IEnumerable<Employee> MakeModel(XElement blob)
        {

            foreach (XElement employee in blob.Elements("eConnect").Elements("Employee"))
            {
                Employee xEmployee = new Employee();
                Func<string, string> middleinitialize = s =>
                {
                    if (employee.Element("MIDLNAME").Value == "")
                    {
                        s = "";
                        return s;
                    }
                    else
                    {
                        s = employee.Element("MIDLNAME").Value.Substring(0, 1) + ".";
                        return s;
                    }
                };


                xEmployee.Department = employee.Element("DEPRTMNT").Value;
                xEmployee.EmployeeID = employee.Element("EMPLOYID").Value;
                xEmployee.FirstName = employee.Element("FRSTNAME").Value;
                xEmployee.LastName = employee.Element("LASTNAME").Value;

                xEmployee.MiddleInitial = middleinitialize(employee.Element("MIDLNAME").Value);
                xEmployee.LastFirstMIName = employee.Element("LASTNAME").Value + ", " +
                               employee.Element("FRSTNAME").Value + " " +
                                middleinitialize(employee.Element("MIDLNAME").Value);
                xEmployee.TaosCell = employee.Element("Address").Element("PHONE3").Value;


                xEmployee.SalesForceID = employee.Element("USERDEF2").Value;
                yield return xEmployee;

            }
        }

        public Employee MakeOneModel(XElement blob)
        {
            XElement blob2 = blob.Element("eConnect").Element("Employee");
            Employee e = new Employee();
            Func<string, string> middleinitialize = s =>
            {
                if (blob2.Element("MIDLNAME").Value == "")
                {
                    s = "";
                    return s;
                }
                else
                {
                    s = blob2.Element("MIDLNAME").Value.Substring(0, 1) + ".";
                    return s;
                }
            };


            e.Department = blob2.Element("DEPRTMNT").Value;
            e.EmployeeID = blob2.Element("EMPLOYID").Value;
            e.FirstName = blob2.Element("FRSTNAME").Value;
            e.LastName = blob2.Element("LASTNAME").Value;

            e.MiddleInitial = middleinitialize(blob2.Element("MIDLNAME").Value);
            e.LastFirstMIName = blob2.Element("LASTNAME").Value + ", " +
                          blob2.Element("FRSTNAME").Value + " " +
                            middleinitialize(blob2.Element("MIDLNAME").Value);
            e.TaosCell = blob2.Element("Address").Element("PHONE3").Value;


            e.SalesForceID = blob2.Element("USERDEF2").Value;
            return e;




        }


        //[STAThread]
        public XElement GPQue()
        {

            string pasheet;

            var xpasheet = new XElement("eConnect",
                new XElement("RQeConnectOutType",
                    new XElement("eConnectProcessInfo",
                      new XElement("Outgoing", "TRUE"),
                      new XElement("MessageID", "Employee")),
                    new XElement("eConnectOut",
                      new XElement("DOCTYPE", "Employee"),
                      new XElement("OUTPUTTYPE", "2"),
                      new XElement("FORLOAD", "0"),
                      new XElement("FORLIST", "1"),
                      new XElement("ACTION", "0"),
                      new XElement("ROWCOUNT", "25"),
                      new XElement("REMOVE", "0"))));

            pasheet = xpasheet.ToString();

            // Create a connection string to specify the Microsoft Dynamics GP server and database
            // Change the data source and initial catalog to specify your server and database
            string sConnectionString = @"data source=VM-GPD01;initial catalog=TMI;integrated security=SSPI;persist security info=False;packet size=4096";

            // Create an eConnectMethods object
            eConnectMethods requester = new eConnectMethods();

            // Call the eConnect_Requester method of the eConnectMethods object to retrieve specified XML data
            string reqDoc = requester.eConnect_Requester(sConnectionString, EnumTypes.ConnectionStringType.SqlClient, pasheet);

            // Display the result of the eConnect_Requester method call
            //Console.Write(reqDoc);


            XElement blob = XElement.Parse(reqDoc);
            return blob;


        }

        ///////
        //// GPQueOverLoad to Just get One Employee

        public XElement GPQue(string employeeID)
        {


            string pasheet;

            var xpasheet = new XElement("eConnect",
                new XElement("RQeConnectOutType",
                    new XElement("eConnectProcessInfo",
                      new XElement("Outgoing", "TRUE"),
                      new XElement("MessageID", "Employee")),
                    new XElement("eConnectOut",
                      new XElement("DOCTYPE", "Employee"),
                      new XElement("INDEX1FROM", employeeID),
                      new XElement("INDEX1TO", employeeID),
                      new XElement("OUTPUTTYPE", "2"),
                      new XElement("FORLOAD", "0"),
                      new XElement("FORLIST", "1"),
                      new XElement("ACTION", "0"),
                      new XElement("ROWCOUNT", "1"),
                      new XElement("REMOVE", "0"))));

            pasheet = xpasheet.ToString();

            // Create a connection string to specify the Microsoft Dynamics GP server and database
            // Change the data source and initial catalog to specify your server and database
            string sConnectionString = @"data source=VM-GPD01;initial catalog=TMI;integrated security=SSPI;persist security info=False;packet size=4096";

            // Create an eConnectMethods object
            eConnectMethods requester = new eConnectMethods();

            // Call the eConnect_Requester method of the eConnectMethods object to retrieve specified XML data
            string reqDoc = requester.eConnect_Requester(sConnectionString, EnumTypes.ConnectionStringType.SqlClient, pasheet);

            // Display the result of the eConnect_Requester method call
            //Console.Write(reqDoc);


            XElement blob = XElement.Parse(reqDoc);
            return blob;
        }
    }
}