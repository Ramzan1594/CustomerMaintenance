using System;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public class CustomerDB
	{
        //(QUESTION 01)**************************************************************
        //METTRE LA VARIABLE PATH STATIQUE ET LUI CREE UN CONSTRUCTEUR.
        static private string Path;

        static CustomerDB()
        {
            CustomerDB.Path = Properties.Settings.Default.ChemFich;
        }
        
        public static List<Customer> GetCustomers()
        {
            List<Customer> customers = new List<Customer>();
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace  = true;
            settings.IgnoreComments    = true;
            XmlReader xmlIn = XmlReader.Create(Path, settings);

            if (xmlIn.ReadToDescendant("Customer"))
            {
                do
                {
                    xmlIn.ReadStartElement("Customer");
                    string type = xmlIn.ReadElementContentAsString(); 
                    if (type == "Wholesale")
                        customers.Add(ReadWholesale(xmlIn));
                    else 
                        if (type == "Retail")
                            customers.Add(ReadRetail(xmlIn));
                    // (Question 09) **********************************************************************
                    // MODIFICATION DANS LE "if" DE "GetCustomers" POUR "NonHumanWholeSaleCustomer"
                    else
                    {
                        if (type == "NonHumanWholesale")
                        {
                            customers.Add(ReadNonHumanWholesale(xmlIn));
                        }
                    }
                }
                while (xmlIn.ReadToNextSibling("Customer"));
            }
            xmlIn.Close();
            // (Question 06) ***********************************************************************
            // OPERATION DE TRIE IMPLEMENTER PAR ICOMPARABLE
            customers.Sort();               
            return customers;
        }
        
        // (Question 09) ********************************************************************
        // AJOUT D'UNE METHODE DE LECTURE DANS LA DB POUR "NonHumanWholeSaleCustomer"
        private static NonHumanWholesaleCustomer ReadNonHumanWholesale(XmlReader xmlIn)
        {
            NonHumanWholesaleCustomer customer = new NonHumanWholesaleCustomer();

            customer.FirstName = xmlIn.ReadElementContentAsString();
            customer.LastName = xmlIn.ReadElementContentAsString();
            customer.Email = xmlIn.ReadElementContentAsString();
            customer.Company = xmlIn.ReadElementContentAsString();
            customer.Galaxy = xmlIn.ReadElementContentAsString();
            customer.LightYear = Convert.ToDecimal(xmlIn.ReadElementContentAsString());
            return customer;
        }

        private static WholesaleCustomer ReadWholesale(XmlReader xmlIn)
        {
            WholesaleCustomer customer = new WholesaleCustomer();
            customer.FirstName = xmlIn.ReadElementContentAsString();
            customer.LastName  = xmlIn.ReadElementContentAsString();
            customer.Email     = xmlIn.ReadElementContentAsString();
            customer.Company   = xmlIn.ReadElementContentAsString();
            return customer;
        }

        private static RetailCustomer ReadRetail(XmlReader xmlIn)
        {
            RetailCustomer customer = new RetailCustomer();        
            customer.FirstName = xmlIn.ReadElementContentAsString();
            customer.LastName  = xmlIn.ReadElementContentAsString();
            customer.Email     = xmlIn.ReadElementContentAsString();
            customer.HomePhone = xmlIn.ReadElementContentAsString();
            // ( Question 11 ) **********************************************************************
            //  AJOUT DES VARIABLE DATENAISSANCE EXPIRATIONLICENCE SEXE
            customer.DateNaissance     = Convert.ToDateTime(xmlIn.ReadElementContentAsString());
            customer.ExpirationLicence = Convert.ToDateTime(xmlIn.ReadElementContentAsString());
            customer.Sexe              = Convert.ToChar(xmlIn.ReadElementContentAsString());
            return customer;
        }
        
        public static void SaveCustomers(List<Customer> customers)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = ("    ");

            XmlWriter xmlOut = XmlWriter.Create(Path, settings);

            xmlOut.WriteStartDocument();
            xmlOut.WriteStartElement("Customers");

            foreach (Customer customer in customers)
            {
                // (Question 09) **************************************************************************
                // MODIFICATION DANS LE "if" DE "SaveCustomers" POUR "NonHumanWholeSaleCustomer"
                if (customer is NonHumanWholesaleCustomer)
                {
                    WriteNonHumanWholesale((NonHumanWholesaleCustomer)customer, xmlOut);
                }
                else
                    if (customer is WholesaleCustomer)
                    WriteWholesale((WholesaleCustomer)customer, xmlOut);
                else
                    if (customer is RetailCustomer)
                    WriteRetail((RetailCustomer)customer, xmlOut);
            }
            xmlOut.WriteEndElement();
            xmlOut.Close();
        }

        // (Question 09)**********************************************************************************
        // AJOUT DE LA METHODE D'ECRITURE D'UN CUSTOMER EXTRATERRESTRE DANS LA DB "NonHumanWholeSale"
        private static void WriteNonHumanWholesale(NonHumanWholesaleCustomer customer, XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement("Customer");
            xmlOut.WriteElementString("Type", "NonHumanWholesale");
            xmlOut.WriteElementString("FirstName", customer.FirstName);
            xmlOut.WriteElementString("LastName", customer.LastName);
            xmlOut.WriteElementString("Email", customer.Email);
            xmlOut.WriteElementString("Company", customer.Company);
            xmlOut.WriteElementString("Galaxy", customer.Galaxy);
            xmlOut.WriteElementString("LightYear", customer.LightYear.ToString());
            xmlOut.WriteEndElement();
        }

        private static void WriteWholesale(WholesaleCustomer customer, XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement("Customer");
            xmlOut.WriteElementString("Type", "Wholesale");
            xmlOut.WriteElementString("FirstName", customer.FirstName);
            xmlOut.WriteElementString("LastName",  customer.LastName);
            xmlOut.WriteElementString("Email",     customer.Email);
            xmlOut.WriteElementString("Company",   customer.Company);
            xmlOut.WriteEndElement   ();
        }

        private static void WriteRetail(RetailCustomer customer, XmlWriter xmlOut)
        {
            xmlOut.WriteStartElement ("Customer");
            xmlOut.WriteElementString("Type", "Retail"); 
            xmlOut.WriteElementString("FirstName", customer.FirstName);
            xmlOut.WriteElementString("LastName",  customer.LastName);
            xmlOut.WriteElementString("Email",     customer.Email);
            xmlOut.WriteElementString("HomePhone", customer.HomePhone);
            // ( Question 11 ) **********************************************************************
            //  AJOUT DES VARIABLE DATENAISSANCE EXPIRATIONLICENCE SEXE
            xmlOut.WriteElementString("DateNaissance", Convert.ToString(customer.DateNaissance));
            xmlOut.WriteElementString("ExpirationLicence", Convert.ToString(customer.ExpirationLicence));
            xmlOut.WriteElementString("Sexe", Convert.ToString(customer.Sexe));
            xmlOut.WriteEndElement();
        }
	}
}
