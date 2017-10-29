namespace DataBase.View {
	partial class SinglePersonForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnAddPhone = new System.Windows.Forms.Button();
			this.lblFn = new System.Windows.Forms.Label();
			this.lblLn = new System.Windows.Forms.Label();
			this.tbFn = new System.Windows.Forms.TextBox();
			this.tbLn = new System.Windows.Forms.TextBox();
			this.tbNewPhone = new System.Windows.Forms.TextBox();
			this.lblPhones = new System.Windows.Forms.Label();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.lblAge = new System.Windows.Forms.Label();
			this.tbAge = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnAddPhone
			// 
			this.btnAddPhone.Location = new System.Drawing.Point(278, 119);
			this.btnAddPhone.Name = "btnAddPhone";
			this.btnAddPhone.Size = new System.Drawing.Size(29, 22);
			this.btnAddPhone.TabIndex = 0;
			this.btnAddPhone.Text = "+";
			this.btnAddPhone.UseVisualStyleBackColor = true;
			this.btnAddPhone.Click += new System.EventHandler(this.button1_Click);
			// 
			// lblFn
			// 
			this.lblFn.AutoSize = true;
			this.lblFn.Location = new System.Drawing.Point(25, 19);
			this.lblFn.Name = "lblFn";
			this.lblFn.Size = new System.Drawing.Size(60, 13);
			this.lblFn.TabIndex = 1;
			this.lblFn.Text = "First Name:";
			// 
			// lblLn
			// 
			this.lblLn.AutoSize = true;
			this.lblLn.Location = new System.Drawing.Point(25, 57);
			this.lblLn.Name = "lblLn";
			this.lblLn.Size = new System.Drawing.Size(58, 13);
			this.lblLn.TabIndex = 2;
			this.lblLn.Text = "Last Name";
			// 
			// tbFn
			// 
			this.tbFn.Location = new System.Drawing.Point(126, 16);
			this.tbFn.Name = "tbFn";
			this.tbFn.Size = new System.Drawing.Size(134, 20);
			this.tbFn.TabIndex = 3;
			// 
			// tbLn
			// 
			this.tbLn.Location = new System.Drawing.Point(126, 54);
			this.tbLn.Name = "tbLn";
			this.tbLn.Size = new System.Drawing.Size(134, 20);
			this.tbLn.TabIndex = 4;
			// 
			// tbNewPhone
			// 
			this.tbNewPhone.Location = new System.Drawing.Point(126, 121);
			this.tbNewPhone.Name = "tbNewPhone";
			this.tbNewPhone.Size = new System.Drawing.Size(134, 20);
			this.tbNewPhone.TabIndex = 6;
			// 
			// lblPhones
			// 
			this.lblPhones.AutoSize = true;
			this.lblPhones.Location = new System.Drawing.Point(25, 124);
			this.lblPhones.Name = "lblPhones";
			this.lblPhones.Size = new System.Drawing.Size(86, 13);
			this.lblPhones.TabIndex = 5;
			this.lblPhones.Text = "Phone Numbers:";
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(349, 12);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 58);
			this.btnUpdate.TabIndex = 7;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(27, 93);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(26, 13);
			this.lblAge.TabIndex = 8;
			this.lblAge.Text = "Age";
			// 
			// tbAge
			// 
			this.tbAge.Location = new System.Drawing.Point(126, 90);
			this.tbAge.Name = "tbAge";
			this.tbAge.Size = new System.Drawing.Size(134, 20);
			this.tbAge.TabIndex = 9;
			// 
			// SinglePersonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(447, 222);
			this.Controls.Add(this.tbAge);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.btnUpdate);
			this.Controls.Add(this.tbNewPhone);
			this.Controls.Add(this.lblPhones);
			this.Controls.Add(this.tbLn);
			this.Controls.Add(this.tbFn);
			this.Controls.Add(this.lblLn);
			this.Controls.Add(this.lblFn);
			this.Controls.Add(this.btnAddPhone);
			this.Name = "SinglePersonForm";
			this.Text = "SinglePersonForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnAddPhone;
        private System.Windows.Forms.Label lblFn;
        private System.Windows.Forms.Label lblLn;
        private System.Windows.Forms.TextBox tbFn;
        private System.Windows.Forms.TextBox tbLn;
        private System.Windows.Forms.TextBox tbNewPhone;
        private System.Windows.Forms.Label lblPhones;
        private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.TextBox tbAge;
	}
}