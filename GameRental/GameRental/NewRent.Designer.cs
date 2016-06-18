namespace GameRental
{
    partial class NewRent
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
            this.lbxGamesList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxCustomersList = new System.Windows.Forms.ListBox();
            this.tbxRentDate = new System.Windows.Forms.TextBox();
            this.tbxRentDue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxGamesList
            // 
            this.lbxGamesList.FormattingEnabled = true;
            this.lbxGamesList.Location = new System.Drawing.Point(12, 28);
            this.lbxGamesList.Name = "lbxGamesList";
            this.lbxGamesList.Size = new System.Drawing.Size(428, 290);
            this.lbxGamesList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Games";
            // 
            // btnRent
            // 
            this.btnRent.Location = new System.Drawing.Point(12, 402);
            this.btnRent.Name = "btnRent";
            this.btnRent.Size = new System.Drawing.Size(174, 23);
            this.btnRent.TabIndex = 3;
            this.btnRent.Text = "Rent";
            this.btnRent.UseVisualStyleBackColor = true;
            this.btnRent.Click += new System.EventHandler(this.btnRent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Customer";
            // 
            // lbxCustomersList
            // 
            this.lbxCustomersList.FormattingEnabled = true;
            this.lbxCustomersList.Location = new System.Drawing.Point(474, 28);
            this.lbxCustomersList.Name = "lbxCustomersList";
            this.lbxCustomersList.Size = new System.Drawing.Size(428, 290);
            this.lbxCustomersList.TabIndex = 5;
            // 
            // tbxRentDate
            // 
            this.tbxRentDate.Location = new System.Drawing.Point(69, 329);
            this.tbxRentDate.Name = "tbxRentDate";
            this.tbxRentDate.Size = new System.Drawing.Size(161, 20);
            this.tbxRentDate.TabIndex = 6;
            // 
            // tbxRentDue
            // 
            this.tbxRentDue.Location = new System.Drawing.Point(69, 355);
            this.tbxRentDue.Name = "tbxRentDue";
            this.tbxRentDue.Size = new System.Drawing.Size(161, 20);
            this.tbxRentDue.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rent Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Rent Due";
            // 
            // NewRent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxRentDue);
            this.Controls.Add(this.tbxRentDate);
            this.Controls.Add(this.lbxCustomersList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxGamesList);
            this.Name = "NewRent";
            this.Text = "NewRent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxGamesList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxCustomersList;
        private System.Windows.Forms.TextBox tbxRentDate;
        private System.Windows.Forms.TextBox tbxRentDue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}