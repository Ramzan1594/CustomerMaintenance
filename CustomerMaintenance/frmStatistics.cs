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
    public partial class frmStatistics : Form
    {
        // ( Question 13 ) **********************************************************************
        // FORMULAIRE POUR LES STATS CONCERNANT LES CUSTOMERS
        private CustomerList customers;
        private int numRetail;
        private int expiredRetail;
        private int expiringRetail;
        private int numWholesale;
        private int numNonhumanWholesale;
        // ( Question 13 ) *****************************************************************************
        // MISE EN PLACE DU CODE POUR LES ELEMENT GRAPHIQUE
        Label label1 = new Label();
        ListBox lstStats = new ListBox();
        Button btnClose = new Button();

            

        public frmStatistics()
        {
            InitializeComponent();
            //( Question 13 )
            Initialisation();
            this.customers = new CustomerList();
            this.customers.Fill();
            this.countCustomerTypeAndFillList();
            this.ShowDialog();

        }
        // ( Question 13 ) ******************************************************************************
        // METHODE D INITIALISATION
        public void Initialisation()
        {
            this.Controls.Add(label1);
            this.Controls.Add(lstStats);
            this.Controls.Add(btnClose);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(75, 13);
            label1.TabIndex = 0;
            label1.Text = "CUSTOMERS";
            // 
            // lstStats
            // 
            lstStats.FormattingEnabled = true;
            lstStats.Location = new System.Drawing.Point(12, 25);
            lstStats.Name = "lstStats";
            lstStats.Size = new System.Drawing.Size(375, 173);
            lstStats.TabIndex = 4;
            // 
            // btnClose
            // 
            btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnClose.Location = new System.Drawing.Point(313, 210);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(75, 23);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStatistics
            // */
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = btnClose;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.ControlBox = false;
            this.Name = "frmStatistics";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statitics Data of Customers";
            this.Load += new System.EventHandler(this.frmStatisticss_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }


        private void countCustomerTypeAndFillList()
        {
            DateTime now = DateTime.Today;

            string[] array = new string[3];
            foreach (Customer c in this.customers)
            {
                if (c is RetailCustomer)
                {
                    RetailCustomer retail = (RetailCustomer)c;
                    TimeSpan time = retail.ExpirationLicence - now;
                    numRetail++;
                    if (retail.ExpirationLicence < now)
                        expiredRetail++;
                    if (time.Days < 95 && time.Days >= 0)
                        expiringRetail++;
                }
                if (c is WholesaleCustomer && !(c is NonHumanWholesaleCustomer))
                    numWholesale++;
                if (c is NonHumanWholesaleCustomer)
                    numNonhumanWholesale++;
            }
            array[0] = "Number of Retail customers : " + numRetail + "    Expired customers : " + expiredRetail +
                                "    Expiring customers " + expiringRetail;
            array[1] += "Number of Whole sale customers : " + numWholesale;
            array[2] += "Number of Non human whole sale customers : " + numNonhumanWholesale;

            foreach (string value in array)
                lstStats.Items.Add(value);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lstStats_SelectedIndexChanged(object sender, EventArgs e)
        { }

        private void frmStatisticss_Load(object sender, EventArgs e)
        { }
    }
}