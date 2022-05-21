using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    public partial class frmAddWholesale : Form
    {
        private Customer customer;

        public frmAddWholesale()
        {
            InitializeComponent();
            this.customer = null;
        }
        
        public Customer GetNewCustomer()
        {
            this.ShowDialog();
            return this.customer;
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (IsValidData())
            {
                this.customer = new WholesaleCustomer(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtCompany.Text);
                
                this.Close();
            }
        }

        private bool IsValidData()
        {
            return Validator.IsPresent(txtFirstName) && Validator.IsPresent(txtLastName)  && Validator.IsPresent(txtEmail)&&
                   Validator.IsValidEmail(txtEmail)  && Validator.IsPresent(txtCompany);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {}
    }
}