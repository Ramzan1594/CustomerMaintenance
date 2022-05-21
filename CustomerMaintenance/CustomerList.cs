using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomerMaintenance
{
    public class CustomerList
	{
        //(Question 05) ***********************************************
        //AJOUT DE LA VARIABLE SORTEDDICTIONNARY QUI A LE MAIL COMME CLE POUR RECUPERE UN CUSTOMER
        private List<Customer> customers;
        private SortedDictionary<string, Customer> lesCustomers;
        public delegate void ChangeHandler(CustomerList customers);
        public event         ChangeHandler Changed;

		public CustomerList()
		{
            this.customers = new List<Customer>();
            this.lesCustomers = new SortedDictionary<string, Customer>();
        }
        
        //(Question 05) ***********************************************
        //AJOUT D UN INDEX POUR RECUPERE UN CUSTOMER SELON LE MAIL ENTREE
        public Customer this[string mail]
        {
            get
            {
                Customer ret = null;

                foreach(Customer c in this.customers)
                {
                    if (c.Email == mail)
                    {
                        this.lesCustomers.Add(mail, c);         // ici pour chaque mail comme cle on aura un customer specifique
                        ret = c;
                        break;
                    }
                }
                return ret;
            }
            set
            {
                this.lesCustomers[mail] = value;
                this.Changed(this);
            }
        }

        public int Count
        {
            get
            {
                return this.customers.Count;
            }
        }

        public Customer this[int i]
		{
			get
			{
				return this.customers[i];
			}
			set
			{
				this.customers[i] = value;
				this.Changed(this);
			}
		}

        public void Fill()
        {
            this.customers = CustomerDB.GetCustomers();
        }
        
        public void Save()
        {
            CustomerDB.SaveCustomers(this.customers);
        }
        
		public void Add(Customer customer)
		{
			this.customers.Add(customer);
			this.Changed(this);
		}
        
		public void Remove(Customer customer)
		{
            this.customers.Remove(customer);
			this.Changed(this);
		}

        public static CustomerList operator + (CustomerList c1, Customer c)
		{
			c1.Add(c);
			return c1;
		}

		public static CustomerList operator - (CustomerList c1, Customer c)
		{
			c1.Remove(c);
			return c1;
		}

        // (Question 04) *************************************************************
        // AJOUT D UN ENUMERATEUR POUR POUVOIR UTILISER UN FOREACH DANS LA LIST
        public IEnumerator<Customer> GetEnumerator()
        {
            return this.customers.GetEnumerator();
        }
    }
}
