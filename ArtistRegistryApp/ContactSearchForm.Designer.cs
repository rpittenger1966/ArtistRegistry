namespace ArtistRegistryApp
{
	partial class ContactSearchForm
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
			btnOk = new Button();
			btnCancel = new Button();
			listBox1 = new ListBox();
			groupBox1 = new GroupBox();
			label12 = new Label();
			cbxGender = new ComboBox();
			label1 = new Label();
			tbLastName = new TextBox();
			label31 = new Label();
			tbCountry = new TextBox();
			tbInstagram = new TextBox();
			tbWebSite = new TextBox();
			tbEmailAddress = new TextBox();
			tbPhone = new TextBox();
			tbPostalCode = new TextBox();
			tbState = new TextBox();
			tbCity = new TextBox();
			tbAddress2 = new TextBox();
			tbAddress1 = new TextBox();
			tbFirstName = new TextBox();
			label10 = new Label();
			label9 = new Label();
			label8 = new Label();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label11 = new Label();
			groupBox1.SuspendLayout();
			SuspendLayout();
			// 
			// btnOk
			// 
			btnOk.Location = new Point(556, 436);
			btnOk.Name = "btnOk";
			btnOk.Size = new Size(75, 23);
			btnOk.TabIndex = 2;
			btnOk.Text = "&OK";
			btnOk.UseVisualStyleBackColor = true;
			btnOk.Click += btnOk_Click;
			// 
			// btnCancel
			// 
			btnCancel.Location = new Point(637, 436);
			btnCancel.Name = "btnCancel";
			btnCancel.Size = new Size(75, 23);
			btnCancel.TabIndex = 3;
			btnCancel.Text = "&Cancel";
			btnCancel.UseVisualStyleBackColor = true;
			// 
			// listBox1
			// 
			listBox1.FormattingEnabled = true;
			listBox1.ItemHeight = 15;
			listBox1.Location = new Point(401, 12);
			listBox1.Name = "listBox1";
			listBox1.Size = new Size(306, 409);
			listBox1.TabIndex = 1;
			listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label12);
			groupBox1.Controls.Add(cbxGender);
			groupBox1.Controls.Add(label1);
			groupBox1.Controls.Add(tbLastName);
			groupBox1.Controls.Add(label31);
			groupBox1.Controls.Add(tbCountry);
			groupBox1.Controls.Add(tbInstagram);
			groupBox1.Controls.Add(tbWebSite);
			groupBox1.Controls.Add(tbEmailAddress);
			groupBox1.Controls.Add(tbPhone);
			groupBox1.Controls.Add(tbPostalCode);
			groupBox1.Controls.Add(tbState);
			groupBox1.Controls.Add(tbCity);
			groupBox1.Controls.Add(tbAddress2);
			groupBox1.Controls.Add(tbAddress1);
			groupBox1.Controls.Add(tbFirstName);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label11);
			groupBox1.Location = new Point(12, 12);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(368, 413);
			groupBox1.TabIndex = 0;
			groupBox1.TabStop = false;
			groupBox1.Text = "Address:";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(7, 99);
			label12.Name = "label12";
			label12.Size = new Size(48, 15);
			label12.TabIndex = 4;
			label12.Text = "Gender:";
			// 
			// cbxGender
			// 
			cbxGender.FormattingEnabled = true;
			cbxGender.Items.AddRange(new object[] { "M", "F" });
			cbxGender.Location = new Point(104, 96);
			cbxGender.Name = "cbxGender";
			cbxGender.Size = new Size(78, 23);
			cbxGender.TabIndex = 5;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(7, 61);
			label1.Name = "label1";
			label1.Size = new Size(66, 15);
			label1.TabIndex = 2;
			label1.Text = "Last Name:";
			// 
			// tbLastName
			// 
			tbLastName.Location = new Point(104, 58);
			tbLastName.Name = "tbLastName";
			tbLastName.Size = new Size(248, 23);
			tbLastName.TabIndex = 3;
			tbLastName.TextChanged += tbLastName_TextChanged;
			// 
			// label31
			// 
			label31.AutoSize = true;
			label31.Location = new Point(6, 375);
			label31.Name = "label31";
			label31.Size = new Size(53, 15);
			label31.TabIndex = 24;
			label31.Text = "Country:";
			// 
			// tbCountry
			// 
			tbCountry.Location = new Point(104, 372);
			tbCountry.Name = "tbCountry";
			tbCountry.Size = new Size(248, 23);
			tbCountry.TabIndex = 25;
			// 
			// tbInstagram
			// 
			tbInstagram.Location = new Point(104, 339);
			tbInstagram.Name = "tbInstagram";
			tbInstagram.Size = new Size(248, 23);
			tbInstagram.TabIndex = 23;
			// 
			// tbWebSite
			// 
			tbWebSite.Location = new Point(104, 310);
			tbWebSite.Name = "tbWebSite";
			tbWebSite.Size = new Size(248, 23);
			tbWebSite.TabIndex = 21;
			// 
			// tbEmailAddress
			// 
			tbEmailAddress.Location = new Point(104, 281);
			tbEmailAddress.Name = "tbEmailAddress";
			tbEmailAddress.Size = new Size(248, 23);
			tbEmailAddress.TabIndex = 19;
			// 
			// tbPhone
			// 
			tbPhone.Location = new Point(104, 252);
			tbPhone.Name = "tbPhone";
			tbPhone.Size = new Size(190, 23);
			tbPhone.TabIndex = 17;
			// 
			// tbPostalCode
			// 
			tbPostalCode.Location = new Point(268, 221);
			tbPostalCode.Name = "tbPostalCode";
			tbPostalCode.Size = new Size(84, 23);
			tbPostalCode.TabIndex = 15;
			// 
			// tbState
			// 
			tbState.Location = new Point(104, 221);
			tbState.Name = "tbState";
			tbState.Size = new Size(78, 23);
			tbState.TabIndex = 13;
			// 
			// tbCity
			// 
			tbCity.Location = new Point(104, 192);
			tbCity.Name = "tbCity";
			tbCity.Size = new Size(248, 23);
			tbCity.TabIndex = 11;
			// 
			// tbAddress2
			// 
			tbAddress2.Location = new Point(104, 163);
			tbAddress2.Name = "tbAddress2";
			tbAddress2.Size = new Size(248, 23);
			tbAddress2.TabIndex = 9;
			// 
			// tbAddress1
			// 
			tbAddress1.Location = new Point(104, 134);
			tbAddress1.Name = "tbAddress1";
			tbAddress1.Size = new Size(248, 23);
			tbAddress1.TabIndex = 7;
			// 
			// tbFirstName
			// 
			tbFirstName.Location = new Point(104, 29);
			tbFirstName.Name = "tbFirstName";
			tbFirstName.Size = new Size(248, 23);
			tbFirstName.TabIndex = 1;
			tbFirstName.TextChanged += tbFirstName_TextChanged;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(6, 281);
			label10.Name = "label10";
			label10.Size = new Size(84, 15);
			label10.TabIndex = 18;
			label10.Text = "Email Address:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(6, 313);
			label9.Name = "label9";
			label9.Size = new Size(56, 15);
			label9.TabIndex = 20;
			label9.Text = "Web Site:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(6, 342);
			label8.Name = "label8";
			label8.Size = new Size(63, 15);
			label8.TabIndex = 22;
			label8.Text = "Instagram:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(6, 255);
			label7.Name = "label7";
			label7.Size = new Size(44, 15);
			label7.TabIndex = 16;
			label7.Text = "Phone:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(189, 229);
			label6.Name = "label6";
			label6.Size = new Size(73, 15);
			label6.TabIndex = 14;
			label6.Text = "Postal Code:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(6, 229);
			label5.Name = "label5";
			label5.Size = new Size(36, 15);
			label5.TabIndex = 12;
			label5.Text = "State:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(6, 195);
			label4.Name = "label4";
			label4.Size = new Size(31, 15);
			label4.TabIndex = 10;
			label4.Text = "City:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(6, 166);
			label3.Name = "label3";
			label3.Size = new Size(61, 15);
			label3.TabIndex = 8;
			label3.Text = "Address 2:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 137);
			label2.Name = "label2";
			label2.Size = new Size(61, 15);
			label2.TabIndex = 6;
			label2.Text = "Address 1:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(6, 32);
			label11.Name = "label11";
			label11.Size = new Size(67, 15);
			label11.TabIndex = 0;
			label11.Text = "First Name:";
			// 
			// ContactSearchForm
			// 
			AcceptButton = btnOk;
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			CancelButton = btnCancel;
			ClientSize = new Size(724, 470);
			Controls.Add(groupBox1);
			Controls.Add(listBox1);
			Controls.Add(btnOk);
			Controls.Add(btnCancel);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "ContactSearchForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Contact Search";
			Load += ContactSearchForm_Load;
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button btnOk;
		private Button btnCancel;
		private ListBox listBox1;
		private GroupBox groupBox1;
		private Label label31;
		private TextBox tbCountry;
		private TextBox tbInstagram;
		private TextBox tbWebSite;
		private TextBox tbEmailAddress;
		private TextBox tbPhone;
		private TextBox tbPostalCode;
		private TextBox tbState;
		private TextBox tbCity;
		private TextBox tbAddress2;
		private TextBox tbAddress1;
		private TextBox tbFirstName;
		private Label label10;
		private Label label9;
		private Label label8;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label11;
		private Label label12;
		private ComboBox cbxGender;
		private Label label1;
		private TextBox tbLastName;
	}
}