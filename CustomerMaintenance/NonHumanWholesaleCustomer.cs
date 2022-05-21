using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    class NonHumanWholesaleCustomer : WholesaleCustomer
    // (Question 07) *******************************************************************
    // AJOUT D'UNE CLASSE DE CUSTOMER EXTRATERRESTRE « NonHumanWholesaleCustomer » AVEC LES 2 VARIABLE GALAXY ET LIGHTYEAR
    {
        // ( Question 08 ) ********************************************************************
        // CREATION D UNE METHODE STATIC POUR LA CREATION DE NonHumanWholesaleCustomer
        public static NonHumanWholesaleCustomer Instancier(string lastName, string firstName, string email, string company, 
                                                            string galaxy, string lightYear)
        {
            NonHumanWholesaleCustomer ret;
            if (lightYear.Equals(""))
                ret = new NonHumanWholesaleCustomer(lastName, firstName, email, company, galaxy);
            else
                ret = new NonHumanWholesaleCustomer(lastName, firstName, email, company, galaxy, Convert.ToDecimal(lightYear));
            return ret;
        }
        private string galaxy;
        private decimal lightYear;

        //Constructeur  
        public NonHumanWholesaleCustomer(){}
        // (Question 08) *******************************************************************
        // AJOUT DES 2 CONSTRUCTEURS DEMANDE, 1 AVEC 2 PARAMETRES , L AUTRE AVEC 1 SEUL
        private NonHumanWholesaleCustomer(string lastName, string firstName, string email, string company, string galaxy, decimal lightYear)
               : base(lastName, firstName, email, company)
        {
                this.Galaxy = galaxy;
                this.LightYear = lightYear;
        }

        private NonHumanWholesaleCustomer(string lastName, string firstName, string email, string company, string galaxy)
               : this(lastName, firstName, email, company, galaxy, 3.5m)
        {}
        
        // (Question 08) *******************************************************************
        // AJOUT DES 2 PROPRIETE GALAXY ET LIGHYEAR
        //Propriete
        public string Galaxy
        {
            get
            {
                return this.galaxy;
            }
            set
            {
                if ((Regex.Match(value, "^G[0-9]{8}$|^[0-9]{8}$").Success) == false)
                    throw new Exception("A galaxy code must start with G followed by 8 digits");
                this.galaxy = value;
            }
        }

        public decimal LightYear
        {
            get
            {
                return this.lightYear;
            }
            set
            {
                if (value < 2.5m)
                    throw new Exception("The distance can not be lesser than 2.5 light years");
                this.lightYear = value;
            }
        }

        // (Question 03) *******************************************************************
        // SURCHARGE DE "ToString" HERITEE DE CUSTOMER --> ABSTRAITE
        public override string ToString()
        {
            return base.ToString() + "   " + this.galaxy + ",   " + this.lightYear + "  Light years";
        }
    }
}
