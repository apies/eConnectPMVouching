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

        public XElement MakeXmlVoucher(IEnumerable<LineItem> lineItems)
        {





            Decimal totalAmount = (from lineItem in lineItems
                                   select lineItem.Amount).Sum();



            var xPayable = new XElement("eConnect",
               new XElement("PMTransactionType",
                 new XElement("taPMTransactionInsert",
                   new XElement("BACHNUMB", "ALP 11/10/2011"),
                   new XElement("VCHNUMWK", "ALAN PIES AMEX 11/11/2011"),
                   new XElement("VENDORID", "AME102"),
                   new XElement("DOCNUMBR", "ALAN PIES AMEX 11/11/2011"),
                   new XElement("DOCTYPE", "1"),
                   new XElement("DOCAMNT", totalAmount),
                   new XElement("CHRGAMNT", totalAmount),
                   new XElement("DOCDATE", "10/17/2011"),
                   new XElement("PRCHAMNT", totalAmount),
                   new XElement("CREATEDIST", "0")),
                   new XElement("taPMDistribution_Items",
                 from lineItem in lineItems
                 select new XElement("taPMDistribution",
                   new XElement("DOCTYPE", "1"),
                   new XElement("VCHRNMBR", "ALAN PIES AMEX 11/11/2011"),
                   new XElement("VENDORID", "AME102"),
                   new XElement("DEBITAMT", lineItem.Amount),
                   new XElement("DistRef", lineItem.Description),
                   new XElement("CRDTAMT", "0"),
                   new XElement("ACTNUMST", lineItem.Distribution)))));
            return xPayable;


        }


        public void PushtoGP(XElement payablex)
        {

            eConnectMethods e = new eConnectMethods();
            string payableVoucher = payablex.ToString();

            // Specify the Microsoft Dynamics GP server and database in the connection string
            string sConnectionString = @"data source=sc-gpd;initial catalog=tmi;integrated security=SSPI;persist security info=False;packet size=4096";

            // Create an XML Document object for the schema
            XmlDocument XsdDoc = new XmlDocument();

            // Default path to the eConnect.xsd file
            // Change the filepath if the eConnect 10.0.0.0 SDK is installed in a location other than the default.
            XsdDoc.Load(@"\Program files\Common Files\Microsoft Shared\eConnect 10\XML Sample Documents\Incoming XSD Schemas\eConnect.xsd");

            // Create a string representing the eConnect schema
            string sXsdSchema = XsdDoc.OuterXml;

            // Pass in xsdSchema to validate against.
            e.eConnect_EntryPoint(sConnectionString, EnumTypes.ConnectionStringType.SqlClient, payableVoucher, EnumTypes.SchemaValidationType.XSD, sXsdSchema);
        }
    }
}
