using System;

namespace CustomerMaintenance
{
    public class WholesaleCustomer : Customer
	{

        private string company;

		public WholesaleCustomer()
		{
		}

        //Constructeur
        public WholesaleCustomer(string lastName, string firstName, string email, string company) : base(lastName, firstName, email)
        {
            this.company = company;
        }

        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }
        // (Question 03) ********************************************************************
        // REMPLACEMENT DE "GetDisplayText()" DANS LA CLASSE "WholesaleCustomer"
        // PAR SURCHARGE DE "ToString" HERITEE DE CUSTOMER --> ABSTRAITE
        /*public override string GetDisplayText()
        {
            return base.GetDisplayText() + " (" + this.company + ")";
        }*/
        public override string ToString()
        {
            return base.ToString() + "   (" + this.company + ")";
        }
    }
}
