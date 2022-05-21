using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMaintenance
{
    // ( Question 10)
    // CREATION DE LA CLASSE FORMULAIRE frmAddWholeSaleNonHuman
    public partial class frmAddWholeSaleNonHuman : Form
    {
        private Customer customer;

        public frmAddWholeSaleNonHuman()
        {
            InitializeComponent();
            this.customer = null;
        }

        public Customer GetNewCustomer()
        {
            this.ShowDialog();
            return this.customer;
        }
        
        private bool IsValidData(){
            //  !!!!! J AI MODIFIE CECI
            return Validator.IsPresent(txtFirstName) && Validator.IsPresent(txtLastName) && Validator.IsPresent(txtEmail) &&
                   Validator.IsValidEmail(txtEmail) && Validator.IsPresent(txtCompany) && Validator.IsPresent(txtGalaxy);
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                try     //  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!  J AVAIS OUBLIE DE METTRE LE TRY CATCH !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                {
                    this.customer = NonHumanWholesaleCustomer.Instancier(txtFirstName.Text, txtLastName.Text, txtEmail.Text,
                                                   txtCompany.Text, txtGalaxy.Text, txtLightYear.Text);
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Entry error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
