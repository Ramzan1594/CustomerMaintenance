using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public class RetailCustomer : Customer
    {

        private string homePhone;
        //( Question 11 ) **********************************************************************
        // LES 3 NOUVELLES VARIABLES DATENAISSANCE , SEXE ET DATE EXPIRATION  LICENCE  
        private DateTime dateNaissance;
        private DateTime expirationLicence;
        private Char sexe;
        
        public RetailCustomer()
        {
        }
        //( Question 11 ) **********************************************************************
        // AJOUT DES 3 PARAMETRES DATENAISSANCE , SEXE ET DATE EXPIRATION  LICENCE 
        public RetailCustomer(string lastName, string firstName, string email, string homePhone, DateTime dateNaissance, 
                             DateTime expirationLicence, Char sexe) : base(lastName, firstName, email)
        {
            this.HomePhone = homePhone;
            this.DateNaissance = dateNaissance;
            this.ExpirationLicence = expirationLicence;
            this.Sexe = sexe;
        }

        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }
            set
            {
                this.homePhone = value;
            }
        }

        //( Question 11 ) **********************************************************************
        // LES 3 PROPRIETE DATENAISSANCE , SEXE ET DATE EXPIRATION  LICENCE 
        public DateTime DateNaissance
        {
            get
            {
                return this.dateNaissance;
            }
            set
            {
                DateTime now = DateTime.Today;
                TimeSpan time = now - value;
                if(time.Days <  6574)
                    throw new Exception("You must be 18 ans.");
                this.dateNaissance = value;
            }
        }

        public DateTime ExpirationLicence
        {
            get
            {
                return this.expirationLicence;
            }
            set
            {
                DateTime now = DateTime.Today;
                TimeSpan time = now - value;
                if (time.Days > 1095)
                    throw new Exception("A licence has a periode of 3 years of time validation");
                this.expirationLicence = value;
            }
        }

        public Char Sexe
        {
            get
            {
                return this.sexe;
            }
            set
            {
                if( value != 'M' && value != 'F')
                        throw new Exception("The gender must be « M » or « F »"); 

                 this.sexe = value;
            }
        }

        // (Question 03) ***********************************************************************
        // REMPLACEMENT DE "GetDisplayText()" DANS LA CLASSE "RetailCustomer"
        // PAR SURCHARGE DE "ToString" HERITEE DE CUSTOMER --> ABSTRAITE
        /*public override string GetDisplayText()
        {
            return base.GetDisplayText() + " ph: " + this.homePhone;
        }*/
        public override string ToString()
        {
            return base.ToString() + "   ph: " + this.homePhone + "   BirthD: "+
                this.dateNaissance.ToString("yyyy-MM-dd") + "   Licence: " + this.expirationLicence.ToString("yyyy-MM-dd") + 
                "   Sex:" + this.sexe;
        }
    }
}
