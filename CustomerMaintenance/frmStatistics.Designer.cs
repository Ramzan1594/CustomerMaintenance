namespace CustomerMaintenance
{
    partial class frmStatistics
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
        // ( Question 13 ) *****************************************************************************
        // MISE EN PLACE DU CODE POUR LES ELEMENT GRAPHIQUE
        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.ListBox lstStats;
        //private System.Windows.Forms.Button btnClose;

        private void InitializeComponent()
        {
            /*this.label1 = new System.Windows.Forms.Label();
            this.lstStats = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CUSTOMERS";
            // 
            // lstStats
            // 
            this.lstStats.FormattingEnabled = true;
            this.lstStats.Location = new System.Drawing.Point(12, 25);
            this.lstStats.Name = "lstStats";
            this.lstStats.Size = new System.Drawing.Size(375, 173);
            this.lstStats.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(313, 210);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmStatistics
            // */
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.ControlBox = false;
            //this.Controls.Add(this.label1);
            //this.Controls.Add(this.lstStats);
            //this.Controls.Add(this.btnClose);
            this.Name = "frmStatistics";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statitics Data of Customers";
            this.Load += new System.EventHandler(this.frmStatisticss_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}