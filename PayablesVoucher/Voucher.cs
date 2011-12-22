using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Dynamics.GP.eConnect;
using System.Xml;

namespace PayablesVoucher
{
    class Voucher
    {

        public XElement MakeXmlVoucher(IEnumerable<LineItem> lineItems,string batchnum, string vouchnum)
        {





            Decimal totalAmount = (from lineItem in lineItems
                                   select lineItem.Amount).Sum();



            var xPayable = new XElement("eConnect",
               new XElement("PMTransactionType",
                 new XElement("taPMTransactionInsert",
                   new XElement("BACHNUMB", batchnum),
                   new XElement("VCHNUMWK", vouchnum),
                   new XElement("VENDORID", "AME102"),
                   new XElement("DOCNUMBR", vouchnum),
                   new XElement("DOCTYPE", "1"),
                   new XElement("DOCAMNT", totalAmount),
                   new XElement("CHRGAMNT", totalAmount),
                   new XElement("DOCDATE", "10/17/2011"),
                   new XElement("PRCHAMNT", totalAmount),
                   new XElement("CREATEDIST", "0")),
                 new XElement("taPMDistribution_Items",
                   new XElement("taPMDistribution",
                   new XElement("DOCTYPE", "1"),
                   new XElement("VCHRNMBR", vouchnum),
                   new XElement("VENDORID", "AME102"),
                   new XElement("DEBITAMT", "0"),
                   new XElement("DistRef", ""),
                   new XElement("DISTTYPE", "2"),
                   new XElement("CRDTAMT", totalAmount),
                   new XElement("ACTNUMST", "25-2010-10-000-01")),
                 from lineItem in lineItems
                 select new XElement("taPMDistribution",
                   new XElement("DOCTYPE", "1"),
                   new XElement("VCHRNMBR", vouchnum),
                   new XElement("VENDORID", "AME102"),
                   new XElement("DEBITAMT", lineItem.Amount),
                   new XElement("DistRef", lineItem.Description),
                   new XElement("CRDTAMT", "0"),
                   new XElement("DISTTYPE", "6"),
                   new XElement("ACTNUMST", lineItem.Distribution)))));
            return xPayable;


        }


        public void PushtoGP(XElement payablex)
        {

            eConnectMethods e = new eConnectMethods();
            string payableVoucher = payablex.ToString();

            // Specify the Microsoft Dynamics GP server and database in the connection string
            string sConnectionString = @"data source=sc-gpd;initial catalog=TMI;integrated security=SSPI;persist security info=False;packet size=4096";

            // Create an XML Document object for the schema
            XmlDocument XsdDoc = new XmlDocument();

            // Default path to the eConnect.xsd file
            // Change the filepath if the eConnect 10.0.0.0 SDK is installed in a location other than the default.
            XsdDoc.Load(@"C:\Program Files (x86)\Common Files\Microsoft Shared\eConnect 10\XML Sample Documents\Incoming XSD Schemas\eConnect.xsd");
           
            // Create a string representing the eConnect schema
            string sXsdSchema = XsdDoc.OuterXml;

            // Pass in xsdSchema to validate against.
            e.eConnect_EntryPoint(sConnectionString, EnumTypes.ConnectionStringType.SqlClient, payableVoucher, EnumTypes.SchemaValidationType.XSD, sXsdSchema);
        }
    }
}
