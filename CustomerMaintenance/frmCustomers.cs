using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CustomerMaintenance
{
    public partial class frmCustomers : Form
    {
        private CustomerList customers;
        
        public frmCustomers()
        {
            InitializeComponent();
            this.customers = new CustomerList();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            this.customers.Changed += new CustomerList.ChangeHandler(HandleChange);
            this.customers.Fill();
            this.FillCustomerListBox();
        }

        // (Question 03) ********************************************************************
        // REMPLACEMENT DE "GetDisplayText()" DANS LA CLASSE "frmCustomers" PAR SURCHARGE DE "ToString" HERITEE DE CUSTOMER 

        // (Question 04) ********************************************************************
        // REMPLACEMENT DE LA BOUCLE NORMALE PAR UNE BOUCLE FOREACH , GRACE A L ENUMERATEUR CREE DANS CUSTOMERLIST
        private void FillCustomerListBox()
        {
            this.lstCustomers.Items.Clear();
            
            foreach (Customer c in this.customers)
            {
                //GetDisplayText remplace par ToString 
                this.lstCustomers.Items.Add(c.ToString());
            }
        }
        // (Question 10) **************************************************************
        // OBSERVATEUR DU BOUTTON ADD NON HUMAN DU FORMULAIR CUSTOMER
        private void btnAddNonHuman_Click(object sender, EventArgs e)
        {
            Customer customer;
            frmAddWholeSaleNonHuman frmAddWholeSaleNonHumanForm = new frmAddWholeSaleNonHuman();
            customer = frmAddWholeSaleNonHumanForm.GetNewCustomer();
            if (customer != null)
            {
                customers.Add(customer);
            }
        }

        private void btnAddWholesale_Click(object sender, EventArgs e)
        {
            Customer customer;
            frmAddWholesale addWholesaleForm = new frmAddWholesale();
            customer = addWholesaleForm.GetNewCustomer();
            if (customer != null)
            {
                customers.Add(customer);
            }
        }

        private void btnAddRetail_Click(object sender, EventArgs e)
        {
            Customer     customer;
            frmAddRetail addRetailForm = new frmAddRetail();
            customer = addRetailForm.GetNewCustomer();
            if (customer != null)
            {
                customers.Add(customer);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstCustomers.SelectedIndex;
            int index = 0;
            if (i != -1)
            {
                foreach (Customer c in customers)
                {
                    if (c.ToString().Contains(lstCustomers.SelectedItem.ToString()))
                        i = index;
                    index++;
                }

                Customer customer = customers[i];
                string message = "Are you sure you want to delete "
                    + customer.FirstName + " " + customer.LastName + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Delete",
                    MessageBoxButtons.YesNo);
                if (button == DialogResult.Yes)
                {
                    customers -= customer;
                }
            }
        }

        private void HandleChange(CustomerList list)
        {
            this.customers.Save();
            this.FillCustomerListBox();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ( Question 11 ) *********************************************************************************************
        // OBSERVATEUR POUR LES 2 RADIO BOUTTONS 
        private void rbHommeFemme_Click(object sender, EventArgs e)
        {
            int edit = lstCustomers.SelectedIndex;     // var pour verifie si un index a ete selectionner

            if (edit != -1)    // si un index a ete selection
            {
                RetailCustomer customerN = (RetailCustomer)customers[edit];
                string message = "would you like to edit the gender of " + customerN.FirstName + " " + customerN.LastName + "?";
                DialogResult button = MessageBox.Show(message, "Confirm Edition mode", MessageBoxButtons.YesNo);

                if (button == DialogResult.Yes  )
                {
                    Char sex = (sender == rbHomme) ? 'M' : 'F';  
                    
                    customerN.Sexe = sex;
                    customers -= customerN;
                    customers += customerN;
                }
            }
            else            // si on appuis sans avoir selectionner d index
            {
                this.lstCustomers.Items.Clear();
                if (sender == rbHomme)
                {
                    int i = 0;
                    foreach (Customer c in customers)
                    {
                        if(c is RetailCustomer)
                        {
                            RetailCustomer customerN = (RetailCustomer)customers[i];
                            if (customerN.Sexe == 'M')
                                this.lstCustomers.Items.Add(c.ToString());
                        }
                        i++;
                    }
                }
                if (sender == rbFemme)
                {
                    int i = 0;
                    foreach (Customer c in customers)
                    {
                        if (c is RetailCustomer)
                        {
                            RetailCustomer customerN = (RetailCustomer)customers[i];
                            if (customerN.Sexe == 'F')
                                this.lstCustomers.Items.Add(c.ToString());
                        }
                        i++;
                    }
                }
            }
        }
        private void rbTous_Click(object sender, EventArgs e)
        {
            FillCustomerListBox();
        }

        private void dptBirthAndLicence_ValueChanged(object sender, EventArgs e)
        {
            int edit = lstCustomers.SelectedIndex;
            if(edit != -1)
            {
                if (sender == dtpDateNaissance)
                {
                    RetailCustomer customerN;
                    customerN = (RetailCustomer)customers[edit];


                    string message = "would you like to edit the birth day of " + customerN.FirstName + " " + customerN.LastName + "?";
                    DialogResult button = MessageBox.Show(message, "Confirm Edition mode", MessageBoxButtons.YesNo);

                    if (button == DialogResult.Yes)
                    {

                        DateTime birthD = Convert.ToDateTime(dtpDateNaissance.Text);

                        customerN.DateNaissance = birthD;
                        customers -= customerN;
                        customers += customerN;
                    }
                }
                if (sender == dptLicence)
                {
                    RetailCustomer customerN;
                    customerN = (RetailCustomer)customers[edit];


                    string message = "would you like to edit the licence expiration of " + customerN.FirstName + " " + customerN.LastName + "?";
                    DialogResult button = MessageBox.Show(message, "Confirm Edition mode", MessageBoxButtons.YesNo);

                    if (button == DialogResult.Yes)
                    {

                        DateTime licence = Convert.ToDateTime(dptLicence.Text);

                        customerN.ExpirationLicence = licence;
                        customers -= customerN;
                        customers += customerN;
                    }
                }
            }
            
        }
        
        // ( Question 12 )
        // OBSERVATEUR DU COMBOBOX
        private void cbTypeChoix_Select(object sender, EventArgs e)
        {
            this.lstCustomers.Items.Clear();
            switch (cbChoix.SelectedIndex)
            {
                case 0:
                    FillCustomerListBox();
                    break;
                case 1:
                    foreach (Customer c in customers)
                    {
                        if(c is RetailCustomer)
                            this.lstCustomers.Items.Add(c.ToString());
                    }
                    break;
                case 2:
                    foreach (Customer c in customers)
                    {
                        if (c is WholesaleCustomer && !(c is NonHumanWholesaleCustomer))
                            this.lstCustomers.Items.Add(c.ToString());
                    }
                    break;
                case 3:
                    foreach (Customer c in customers)
                    {
                        if (c is NonHumanWholesaleCustomer)
                            this.lstCustomers.Items.Add(c.ToString());
                    }
                    break;
            }
        }

        private void lstCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {}
        // ( Question 13 ) ******************************************************************
        // OBSERVATEUR DU BOUTTON STATS POUR CREE LE NOUVEAU FORMUALIRE frmStatistics
        private void btnStats_Click(object sender, EventArgs e)
        {
            frmStatistics frmStats = new frmStatistics();
        }
        
        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have to be in <All> section to be able to modify !");
        }
    }
}