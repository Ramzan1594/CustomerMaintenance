namespace CustomerMaintenance
{
    partial class frmCustomers
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDelete = new System.Windows.Forms.Button();
            this.lstCustomers = new System.Windows.Forms.ListBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddRetail = new System.Windows.Forms.Button();
            this.btnAddWholesale = new System.Windows.Forms.Button();
            this.btnNonHuman = new System.Windows.Forms.Button();
            this.rbHomme = new System.Windows.Forms.RadioButton();
            this.rbFemme = new System.Windows.Forms.RadioButton();
            this.rbTous = new System.Windows.Forms.RadioButton();
            this.dtpDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.cbChoix = new System.Windows.Forms.ComboBox();
            this.btnStats = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dptLicence = new System.Windows.Forms.DateTimePicker();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(564, 162);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lstCustomers
            // 
            this.lstCustomers.Location = new System.Drawing.Point(12, 30);
            this.lstCustomers.Name = "lstCustomers";
            this.lstCustomers.Size = new System.Drawing.Size(546, 147);
            this.lstCustomers.TabIndex = 5;
            this.lstCustomers.SelectedIndexChanged += new System.EventHandler(this.lstCustomers_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(564, 190);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(96, 23);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Customers:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnAddRetail
            // 
            this.btnAddRetail.Location = new System.Drawing.Point(564, 58);
            this.btnAddRetail.Name = "btnAddRetail";
            this.btnAddRetail.Size = new System.Drawing.Size(96, 24);
            this.btnAddRetail.TabIndex = 11;
            this.btnAddRetail.Text = "Add &Retail";
            this.btnAddRetail.Click += new System.EventHandler(this.btnAddRetail_Click);
            // 
            // btnAddWholesale
            // 
            this.btnAddWholesale.Location = new System.Drawing.Point(564, 28);
            this.btnAddWholesale.Name = "btnAddWholesale";
            this.btnAddWholesale.Size = new System.Drawing.Size(96, 24);
            this.btnAddWholesale.TabIndex = 10;
            this.btnAddWholesale.Text = "Add &Wholesale";
            this.btnAddWholesale.Click += new System.EventHandler(this.btnAddWholesale_Click);
            // 
            // btnNonHuman
            // 
            this.btnNonHuman.Location = new System.Drawing.Point(564, 88);
            this.btnNonHuman.Name = "btnNonHuman";
            this.btnNonHuman.Size = new System.Drawing.Size(96, 23);
            this.btnNonHuman.TabIndex = 12;
            this.btnNonHuman.Text = "Add &NonHuman";
            this.btnNonHuman.UseVisualStyleBackColor = true;
            this.btnNonHuman.Click += new System.EventHandler(this.btnAddNonHuman_Click);
            // 
            // rbHomme
            // 
            this.rbHomme.AutoSize = true;
            this.rbHomme.Location = new System.Drawing.Point(73, 192);
            this.rbHomme.Name = "rbHomme";
            this.rbHomme.Size = new System.Drawing.Size(46, 17);
            this.rbHomme.TabIndex = 13;
            this.rbHomme.Text = "Man";
            this.rbHomme.UseVisualStyleBackColor = true;
            this.rbHomme.Click += new System.EventHandler(this.rbHommeFemme_Click);
            // 
            // rbFemme
            // 
            this.rbFemme.AutoSize = true;
            this.rbFemme.Location = new System.Drawing.Point(140, 192);
            this.rbFemme.Name = "rbFemme";
            this.rbFemme.Size = new System.Drawing.Size(62, 17);
            this.rbFemme.TabIndex = 14;
            this.rbFemme.Text = "Women";
            this.rbFemme.UseVisualStyleBackColor = true;
            this.rbFemme.Click += new System.EventHandler(this.rbHommeFemme_Click);
            // 
            // rbTous
            // 
            this.rbTous.AutoSize = true;
            this.rbTous.Checked = true;
            this.rbTous.Location = new System.Drawing.Point(16, 192);
            this.rbTous.Name = "rbTous";
            this.rbTous.Size = new System.Drawing.Size(36, 17);
            this.rbTous.TabIndex = 15;
            this.rbTous.TabStop = true;
            this.rbTous.Text = "All";
            this.rbTous.UseVisualStyleBackColor = true;
            this.rbTous.Click += new System.EventHandler(this.rbTous_Click);
            // 
            // dtpDateNaissance
            // 
            this.dtpDateNaissance.CustomFormat = "yyyy-MM-dd";
            this.dtpDateNaissance.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateNaissance.Location = new System.Drawing.Point(332, 192);
            this.dtpDateNaissance.Name = "dtpDateNaissance";
            this.dtpDateNaissance.Size = new System.Drawing.Size(81, 20);
            this.dtpDateNaissance.TabIndex = 16;
            this.dtpDateNaissance.Validated += new System.EventHandler(this.dptBirthAndLicence_ValueChanged);
            // 
            // cbChoix
            // 
            this.cbChoix.FormattingEnabled = true;
            this.cbChoix.Items.AddRange(new object[] {
            "All",
            "Only retail",
            "Only human wholesale",
            "Only nonhuman wholesale"});
            this.cbChoix.Location = new System.Drawing.Point(207, 191);
            this.cbChoix.Name = "cbChoix";
            this.cbChoix.Size = new System.Drawing.Size(87, 21);
            this.cbChoix.TabIndex = 17;
            this.cbChoix.Text = "All";
            this.cbChoix.SelectedIndexChanged += new System.EventHandler(this.cbTypeChoix_Select);
            // 
            // btnStats
            // 
            this.btnStats.Location = new System.Drawing.Point(564, 117);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(96, 23);
            this.btnStats.TabIndex = 18;
            this.btnStats.Text = "&Stats";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(300, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Birth";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(419, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Licence";
            // 
            // dptLicence
            // 
            this.dptLicence.CustomFormat = "yyyy-MM-dd";
            this.dptLicence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dptLicence.Location = new System.Drawing.Point(464, 192);
            this.dptLicence.Name = "dptLicence";
            this.dptLicence.Size = new System.Drawing.Size(94, 20);
            this.dptLicence.TabIndex = 21;
            this.dptLicence.Validated += new System.EventHandler(this.dptBirthAndLicence_ValueChanged);
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(617, 3);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(43, 23);
            this.btnHelp.TabIndex = 22;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(672, 221);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.dptLicence);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStats);
            this.Controls.Add(this.cbChoix);
            this.Controls.Add(this.dtpDateNaissance);
            this.Controls.Add(this.rbTous);
            this.Controls.Add(this.rbFemme);
            this.Controls.Add(this.rbHomme);
            this.Controls.Add(this.btnNonHuman);
            this.Controls.Add(this.btnAddRetail);
            this.Controls.Add(this.btnAddWholesale);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstCustomers);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Name = "frmCustomers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customer Maintenance";
            this.Load += new System.EventHandler(this.frmCustomers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ListBox lstCustomers;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddRetail;
        private System.Windows.Forms.Button btnAddWholesale;
        private System.Windows.Forms.Button btnNonHuman;
        private System.Windows.Forms.RadioButton rbHomme;
        private System.Windows.Forms.RadioButton rbFemme;
        private System.Windows.Forms.RadioButton rbTous;
        private System.Windows.Forms.DateTimePicker dtpDateNaissance;
        private System.Windows.Forms.ComboBox cbChoix;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dptLicence;
        private System.Windows.Forms.Button btnHelp;
    }
}