namespace D2EquipEase
{
    partial class formReturn
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
            this.buttonMain = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxReturn = new System.Windows.Forms.ComboBox();
            this.numericUpDownEquipmentID = new System.Windows.Forms.NumericUpDown();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipmentID)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMain
            // 
            this.buttonMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMain.Location = new System.Drawing.Point(647, 372);
            this.buttonMain.Name = "buttonMain";
            this.buttonMain.Size = new System.Drawing.Size(141, 66);
            this.buttonMain.TabIndex = 1;
            this.buttonMain.Text = "Return To Main Page";
            this.buttonMain.UseVisualStyleBackColor = true;
            this.buttonMain.Click += new System.EventHandler(this.buttonMain_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.192F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(646, 48);
            this.label1.TabIndex = 2;
            this.label1.Text = "What Would You Like To Return";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Equipment ID:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(183, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Return Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.096F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(205, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Return To:";
            // 
            // comboBoxReturn
            // 
            this.comboBoxReturn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxReturn.FormattingEnabled = true;
            this.comboBoxReturn.Location = new System.Drawing.Point(324, 247);
            this.comboBoxReturn.Name = "comboBoxReturn";
            this.comboBoxReturn.Size = new System.Drawing.Size(186, 24);
            this.comboBoxReturn.TabIndex = 7;
            // 
            // numericUpDownEquipmentID
            // 
            this.numericUpDownEquipmentID.Location = new System.Drawing.Point(324, 138);
            this.numericUpDownEquipmentID.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownEquipmentID.Name = "numericUpDownEquipmentID";
            this.numericUpDownEquipmentID.Size = new System.Drawing.Size(186, 22);
            this.numericUpDownEquipmentID.TabIndex = 8;
            // 
            // buttonReturn
            // 
            this.buttonReturn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.792F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReturn.Location = new System.Drawing.Point(336, 286);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.Size = new System.Drawing.Size(141, 66);
            this.buttonReturn.TabIndex = 9;
            this.buttonReturn.Text = "Return Equipment";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(324, 195);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.ReadOnly = true;
            this.textBoxTime.Size = new System.Drawing.Size(185, 22);
            this.textBoxTime.TabIndex = 10;
            // 
            // formReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.numericUpDownEquipmentID);
            this.Controls.Add(this.comboBoxReturn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMain);
            this.Name = "formReturn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Returns";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEquipmentID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxReturn;
        private System.Windows.Forms.NumericUpDown numericUpDownEquipmentID;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}