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
    public partial class frmAddRetail : Form
    {
        private Customer customer;

        public frmAddRetail()
        {
            InitializeComponent();
            this.customer = null;
        }

        public Customer GetNewCustomer()
        {
            this.ShowDialog();
            return this.customer;
        }
        // ( Question 11) ****************************************************************************
        // AJOUT DES 3 NOUVELLES VARIABLE DATENAISSANCE LICENCEEXPIRATION ET SEXE COMME PARAMETRES
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            // ( Question 14 ) J AI RETIRE LA CONDITION  IsValidData ANINSI QUE LA METHODE
            try
            {
                this.customer = new RetailCustomer(txtFirstName.Text, txtLastName.Text, txtEmail.Text, txtHomePhone.Text,
                    Convert.ToDateTime(txtBirthDate.Text), Convert.ToDateTime(txtLicenceDate.Text), Convert.ToChar(txtSex.Text));
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Entry error ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }
        // ( Question 11) ****************************************************************************
        // AJOUT DES TESTS POUR LES 3 NOUVELLES VARIABLE DATENAISSANCE LICENCEEXPIRATION ET SEXE
        // \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/
        // \/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/

        // ( Question 14 )
        // MODIFICATION DE LA QUESTION 11 POUR LA QUESTION 14
        // METHODE POUR RETIRE LE ERRORPROVIDER
        private void textBox_Validated(object sender, EventArgs e)
        {
            // If all conditions have been met, clear the ErrorProvider of errors.
            errorProvider1.SetError((TextBox)sender, "");  
        }
        // LES TEST DE VALIDATION POUR PASSER AU SUIVANT BOX ********************************************
        private void txtBox_Validating(object sender, CancelEventArgs e)
        {
            string errorMsg;
            switch (((TextBox)sender).Tag)
            {
                case "FirstName":    
                    if (!ValidFirstName(txtFirstName.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtFirstName.Select(0, txtFirstName.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtFirstName, errorMsg);
                    }
                    break;
                case "LastName":
                    if (!ValidLastName(txtLastName.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtFirstName.Select(0, txtLastName.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtLastName, errorMsg);
                    }
                    break;
                case "Email":
                    if (!ValidEmailAddress(txtEmail.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtEmail.Select(0, txtEmail.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtEmail, errorMsg);
                    }
                    break;
                case "HomePhone":
                    if (!ValidPhone(txtHomePhone.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtHomePhone.Select(0, txtHomePhone.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtHomePhone, errorMsg);
                    }
                    break;
                case "BirthDate":
                    if (!ValidBirthDate(txtBirthDate.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtBirthDate.Select(0, txtBirthDate.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtBirthDate, errorMsg);
                    }
                    break;
                case "LicenceDate":
                    if (!ValidLicence(txtLicenceDate.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtLicenceDate.Select(0, txtLicenceDate.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtLicenceDate, errorMsg);
                    }
                    break;
                case "Sex":
                    if (!ValidSex(txtSex.Text, out errorMsg))
                    {
                        // Cancel the event and select the text to be corrected by the user.
                        e.Cancel = true;
                        txtSex.Select(0, txtSex.Text.Length);
                        // Set the ErrorProvider error with the text to display. 
                        errorProvider1.SetError(txtSex, errorMsg);
                    }
                    break;                
            }
        }
        
        // LES METHODE AUQUELS ON FAIT APPEL POUR LES VALIDATIONS *************************************************************************
        public bool ValidFirstName(string firstName, out string errorMessage)
        {
            if (firstName.Length == 0)
            {
                errorMessage = "First name is required.";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }
        public bool ValidLastName(string lastName, out string errorMessage)
        {
            if (lastName.Length == 0)
            {
                errorMessage = "Last name is required.";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }
        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            // Confirm that the email address string is not empty.
            if (emailAddress.Length == 0)
            {
                errorMessage = "email address is required.";
                return false;
            }
            // Confirm that there is an "@" and a "." in the email address, and in the correct order.
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    errorMessage = "";
                    return true;
                }
            }
            errorMessage = "email address must be valid email address format.\n" + "For example 'someone@example.com' ";
            return false;
        }
        public bool ValidPhone(string phone, out string errorMessage)
        {
            bool ret = true;
            errorMessage = "";
            if (phone.Length == 0)
            {
                errorMessage = "Home phone is required.";
                ret = false;
            }
            // Confirmer qu il y a bien un champ
            else
            { 
                int number = 0;
                if (Int32.TryParse(phone, out number))
                    ret = true;
                else
                {
                    errorMessage = "Home phone must be an integer.";
                    ret = false;
                }
            }
            return ret;
        } 
        public bool ValidBirthDate(string date, out string errorMessage)
        {
            bool ret = true;
            errorMessage = "";
            if (date.Length == 0)
            {
                errorMessage = "Birth date is required.";
                ret = false;
            }
            // Confirmer qu il y a bien un champ
            else
            {
                DateTime now = DateTime.Today;
                TimeSpan timeBirth = now - Convert.ToDateTime(date);
                if(timeBirth.Days < 6574)
                {
                    errorMessage = "You must be 18";
                    ret = false;
                }   
            }
            return ret;
        }
        public bool ValidLicence(string date, out string errorMessage)
        {
            bool ret = true;
            errorMessage = "";
            if (date.Length == 0)
            {
                errorMessage = "Licence date is required.";
                ret = false;
            }
            else
            {
                DateTime now = DateTime.Today;
                TimeSpan time = Convert.ToDateTime(date) - now;
                if (time.Days > 1095)
                {
                    errorMessage = "A licence has a 3 years time of validation";
                    ret = false;
                }
            }
            return ret;
        }
        public bool ValidSex(string sex, out string errorMessage)
        {
            bool ret = true;
            errorMessage = "";
            if (sex.Length == 0)
            {
                errorMessage = "A gender is required.";
                ret = false;
            }
            else
            {

                if (sex.Length > 1)
                {
                    errorMessage = "The gender must be « M » or « F ».";
                    ret = false;
                }
                else
                {
                    if (Convert.ToChar(sex) != 'M' && Convert.ToChar(sex) != 'F')
                    {
                        errorMessage = "The gender must be « M » or « F ».";
                        ret = false;
                    }
                }
            }
            return ret;
        }
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\  Fin Question 14
        // /\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\/\
        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}