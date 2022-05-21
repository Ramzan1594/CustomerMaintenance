using System;

namespace CustomerMaintenance
{
    // (Question 02) --------------------------------------------------------------
    // MODIFICATION DE LA CLASSE "Customer" EN CLASSE ABSTRAITE
    // (Question 06) --------------------------------------------------------------
    // IMPLEMENTATION DE L'INTERFACE "IComparable"
    public abstract class Customer : IComparable
	{
        private string firstName;
		private string lastName;
		private string email;

		public Customer()
		{}

		public Customer(string firstName, string lastName, string email)
		{
			this.FirstName = firstName;
			this.LastName  = lastName;
			this.Email     = email;
		}

		public string FirstName
		{
			get
			{
                return this.firstName;
			}
			set
			{
                if (value.Length > 50)
                {
                    throw new ArgumentException("Maximum length of first name is 50 characters.");
                }
                this.firstName = value;
			}
		}

		public string LastName
		{
			get
			{
                return this.lastName;
			}
			set
			{
                if (value.Length > 50)
                {
                    throw new ArgumentException("Maximum length of last name is 50 characters.");
                }
                this.lastName = value;
			}
		}

		public string Email
		{
			get
			{
				return this.email;
			}
			set
			{
                if (value.Length > 50)
                {
                    throw new ArgumentException("Maximum length of email address is 50 characters.");
                }
                this.email = value;
			}
		}
        // (Question 03) ***********************************************************************
        // REMPLACEMENT DE "GetDisplayText()" DANS LA CLASSE ABSTRAITE "Customer" PAR "ToString"
        /*public virtual string GetDisplayText()
        {
            return this.firstName + " " + this.lastName + ", " + this.email;
        }*/
        public override string ToString()
        {
            return this.firstName + "   " + this.lastName + ",   " + this.email;
        }

        // (Question 06) ***********************************************************************
        // IMPLEMENTER ICOMPARABLE ET COMPARETO 
        public int CompareTo(object obj)
        {
            if (!(obj is Customer))                                     // verifie si "Customer"
                throw new NotImplementedException();

            Customer other = (Customer)obj;
            String currentLastName = this.LastName.ToUpper().Trim();
            String otherLastName = other.LastName.ToUpper().Trim();
            
            if (currentLastName == otherLastName)                       //si nom de famille identique
            {
                String currentFirstName = this.FirstName.ToUpper().Trim();
                String otherFirstName = other.FirstName.ToUpper().Trim();
                return currentFirstName.CompareTo(otherFirstName);      // alors trie sur le prenom
            }
            return currentLastName.CompareTo(otherLastName);            //sinon trie sur le nom
        }
    }
}
