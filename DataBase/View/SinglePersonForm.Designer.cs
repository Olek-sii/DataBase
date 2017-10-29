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
			this.btnOk = new System.Windows.Forms.Button();
			this.lblAge = new System.Windows.Forms.Label();
			this.tbAge = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.listView1 = new System.Windows.Forms.ListView();
			this.btnDeleteNumber = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnAddPhone
			// 
			this.btnAddPhone.Location = new System.Drawing.Point(357, 4);
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
			this.lblFn.Location = new System.Drawing.Point(12, 9);
			this.lblFn.Name = "lblFn";
			this.lblFn.Size = new System.Drawing.Size(60, 13);
			this.lblFn.TabIndex = 1;
			this.lblFn.Text = "First Name:";
			// 
			// lblLn
			// 
			this.lblLn.AutoSize = true;
			this.lblLn.Location = new System.Drawing.Point(12, 35);
			this.lblLn.Name = "lblLn";
			this.lblLn.Size = new System.Drawing.Size(58, 13);
			this.lblLn.TabIndex = 2;
			this.lblLn.Text = "Last Name";
			// 
			// tbFn
			// 
			this.tbFn.Location = new System.Drawing.Point(104, 6);
			this.tbFn.Name = "tbFn";
			this.tbFn.Size = new System.Drawing.Size(134, 20);
			this.tbFn.TabIndex = 3;
			// 
			// tbLn
			// 
			this.tbLn.Location = new System.Drawing.Point(104, 32);
			this.tbLn.Name = "tbLn";
			this.tbLn.Size = new System.Drawing.Size(134, 20);
			this.tbLn.TabIndex = 4;
			// 
			// tbNewPhone
			// 
			this.tbNewPhone.Location = new System.Drawing.Point(104, 83);
			this.tbNewPhone.Name = "tbNewPhone";
			this.tbNewPhone.Size = new System.Drawing.Size(134, 20);
			this.tbNewPhone.TabIndex = 6;
			// 
			// lblPhones
			// 
			this.lblPhones.AutoSize = true;
			this.lblPhones.Location = new System.Drawing.Point(2, 85);
			this.lblPhones.Name = "lblPhones";
			this.lblPhones.Size = new System.Drawing.Size(86, 13);
			this.lblPhones.TabIndex = 5;
			this.lblPhones.Text = "Phone Numbers:";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(118, 109);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(86, 23);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// lblAge
			// 
			this.lblAge.AutoSize = true;
			this.lblAge.Location = new System.Drawing.Point(25, 60);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(26, 13);
			this.lblAge.TabIndex = 8;
			this.lblAge.Text = "Age";
			// 
			// tbAge
			// 
			this.tbAge.Location = new System.Drawing.Point(104, 57);
			this.tbAge.Name = "tbAge";
			this.tbAge.Size = new System.Drawing.Size(134, 20);
			this.tbAge.TabIndex = 9;
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(210, 109);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(86, 23);
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// listView1
			// 
			this.listView1.LabelEdit = true;
			this.listView1.Location = new System.Drawing.Point(247, 6);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(104, 97);
			this.listView1.TabIndex = 11;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.List;
			this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// btnDeleteNumber
			// 
			this.btnDeleteNumber.Location = new System.Drawing.Point(357, 33);
			this.btnDeleteNumber.Name = "btnDeleteNumber";
			this.btnDeleteNumber.Size = new System.Drawing.Size(29, 22);
			this.btnDeleteNumber.TabIndex = 12;
			this.btnDeleteNumber.Text = "x";
			this.btnDeleteNumber.UseVisualStyleBackColor = true;
			this.btnDeleteNumber.Click += new System.EventHandler(this.btnDeleteNumber_Click);
			// 
			// SinglePersonForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(394, 139);
			this.Controls.Add(this.btnDeleteNumber);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tbAge);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.btnOk);
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
        private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Label lblAge;
		private System.Windows.Forms.TextBox tbAge;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Button btnDeleteNumber;
	}
}