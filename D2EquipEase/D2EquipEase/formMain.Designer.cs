namespace D2EquipEase
{
    partial class formMain
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
            this.buttonDisplayRecords = new System.Windows.Forms.Button();
            this.buttonNewBooking = new System.Windows.Forms.Button();
            this.buttonReturns = new System.Windows.Forms.Button();
            this.buttonReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDisplayRecords
            // 
            this.buttonDisplayRecords.Location = new System.Drawing.Point(171, 213);
            this.buttonDisplayRecords.Name = "buttonDisplayRecords";
            this.buttonDisplayRecords.Size = new System.Drawing.Size(203, 85);
            this.buttonDisplayRecords.TabIndex = 0;
            this.buttonDisplayRecords.Text = "Display Rental Records";
            this.buttonDisplayRecords.UseVisualStyleBackColor = true;
            this.buttonDisplayRecords.Click += new System.EventHandler(this.buttonDisplayRecords_Click);
            // 
            // buttonNewBooking
            // 
            this.buttonNewBooking.Location = new System.Drawing.Point(394, 213);
            this.buttonNewBooking.Name = "buttonNewBooking";
            this.buttonNewBooking.Size = new System.Drawing.Size(205, 85);
            this.buttonNewBooking.TabIndex = 1;
            this.buttonNewBooking.Text = "Create A New Booking";
            this.buttonNewBooking.UseVisualStyleBackColor = true;
            this.buttonNewBooking.Click += new System.EventHandler(this.buttonNewBooking_Click);
            // 
            // buttonReturns
            // 
            this.buttonReturns.Location = new System.Drawing.Point(394, 317);
            this.buttonReturns.Name = "buttonReturns";
            this.buttonReturns.Size = new System.Drawing.Size(205, 85);
            this.buttonReturns.TabIndex = 2;
            this.buttonReturns.Text = "Return Equipment";
            this.buttonReturns.UseVisualStyleBackColor = true;
            this.buttonReturns.Click += new System.EventHandler(this.buttonReturns_Click);
            // 
            // buttonReport
            // 
            this.buttonReport.Location = new System.Drawing.Point(171, 317);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(203, 85);
            this.buttonReport.TabIndex = 3;
            this.buttonReport.Text = "View Summary Reports";
            this.buttonReport.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(143, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "What Would You Like To Do ";
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 517);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReport);
            this.Controls.Add(this.buttonReturns);
            this.Controls.Add(this.buttonNewBooking);
            this.Controls.Add(this.buttonDisplayRecords);
            this.Name = "formMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDisplayRecords;
        private System.Windows.Forms.Button buttonNewBooking;
        private System.Windows.Forms.Button buttonReturns;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Label label1;
    }
}