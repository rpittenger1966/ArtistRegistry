namespace ArtistRegistryApp
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			tabControl1 = new TabControl();
			tabPageContacts = new TabPage();
			button5 = new Button();
			tbContactNameSearch = new TextBox();
			label32 = new Label();
			lbxContacts = new ListBox();
			groupBox3 = new GroupBox();
			button3 = new Button();
			button4 = new Button();
			textBox21 = new TextBox();
			textBox22 = new TextBox();
			textBox23 = new TextBox();
			textBox24 = new TextBox();
			textBox25 = new TextBox();
			textBox26 = new TextBox();
			textBox27 = new TextBox();
			textBox28 = new TextBox();
			textBox29 = new TextBox();
			textBox30 = new TextBox();
			label21 = new Label();
			label22 = new Label();
			label23 = new Label();
			label24 = new Label();
			label25 = new Label();
			label26 = new Label();
			label27 = new Label();
			label28 = new Label();
			label29 = new Label();
			label30 = new Label();
			tabPageGalleries = new TabPage();
			groupBox4 = new GroupBox();
			btnAddExhibition = new Button();
			dataGridView_GalleryExhibition = new DataGridView();
			groupBox1 = new GroupBox();
			label31 = new Label();
			tbGalleryCountry = new TextBox();
			btnGalleryAdd = new Button();
			btnGalleryUpdate = new Button();
			tbGalleryInstagram = new TextBox();
			tbGalleryWebSite = new TextBox();
			tbGalleryEmailAddress = new TextBox();
			tbGalleryPhone = new TextBox();
			tbGalleryPostalCode = new TextBox();
			tbGalleryState = new TextBox();
			tbGalleryCity = new TextBox();
			tbGalleryAddress2 = new TextBox();
			tbGalleryAddress1 = new TextBox();
			tbGalleryName = new TextBox();
			label10 = new Label();
			label9 = new Label();
			label8 = new Label();
			label7 = new Label();
			label6 = new Label();
			label5 = new Label();
			label4 = new Label();
			label3 = new Label();
			label2 = new Label();
			label1 = new Label();
			lbxGalleries = new ListBox();
			tabPageFestivals = new TabPage();
			groupBox2 = new GroupBox();
			button1 = new Button();
			button2 = new Button();
			textBox11 = new TextBox();
			textBox12 = new TextBox();
			textBox13 = new TextBox();
			textBox14 = new TextBox();
			textBox15 = new TextBox();
			textBox16 = new TextBox();
			textBox17 = new TextBox();
			textBox18 = new TextBox();
			textBox19 = new TextBox();
			textBox20 = new TextBox();
			label11 = new Label();
			label12 = new Label();
			label13 = new Label();
			label14 = new Label();
			label15 = new Label();
			label16 = new Label();
			label17 = new Label();
			label18 = new Label();
			label19 = new Label();
			label20 = new Label();
			tabPageLog = new TabPage();
			tabPageArtPieces = new TabPage();
			tabPageExhibitions = new TabPage();
			btnClose = new Button();
			tabControl1.SuspendLayout();
			tabPageContacts.SuspendLayout();
			groupBox3.SuspendLayout();
			tabPageGalleries.SuspendLayout();
			groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridView_GalleryExhibition).BeginInit();
			groupBox1.SuspendLayout();
			tabPageFestivals.SuspendLayout();
			groupBox2.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPageContacts);
			tabControl1.Controls.Add(tabPageGalleries);
			tabControl1.Controls.Add(tabPageFestivals);
			tabControl1.Controls.Add(tabPageLog);
			tabControl1.Controls.Add(tabPageArtPieces);
			tabControl1.Controls.Add(tabPageExhibitions);
			tabControl1.Location = new Point(12, 53);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(1273, 891);
			tabControl1.TabIndex = 0;
			// 
			// tabPageContacts
			// 
			tabPageContacts.Controls.Add(button5);
			tabPageContacts.Controls.Add(tbContactNameSearch);
			tabPageContacts.Controls.Add(label32);
			tabPageContacts.Controls.Add(lbxContacts);
			tabPageContacts.Controls.Add(groupBox3);
			tabPageContacts.Location = new Point(4, 24);
			tabPageContacts.Name = "tabPageContacts";
			tabPageContacts.Padding = new Padding(3);
			tabPageContacts.Size = new Size(1265, 863);
			tabPageContacts.TabIndex = 0;
			tabPageContacts.Text = "Contacts";
			tabPageContacts.UseVisualStyleBackColor = true;
			// 
			// button5
			// 
			button5.Location = new Point(485, 246);
			button5.Name = "button5";
			button5.Size = new Size(22, 23);
			button5.TabIndex = 13;
			button5.Text = "button5";
			button5.UseVisualStyleBackColor = true;
			// 
			// tbContactNameSearch
			// 
			tbContactNameSearch.Location = new Point(105, 30);
			tbContactNameSearch.Name = "tbContactNameSearch";
			tbContactNameSearch.Size = new Size(210, 23);
			tbContactNameSearch.TabIndex = 12;
			tbContactNameSearch.TextChanged += tbContactNameSearch_TextChanged;
			// 
			// label32
			// 
			label32.AutoSize = true;
			label32.Location = new Point(25, 33);
			label32.Name = "label32";
			label32.Size = new Size(74, 15);
			label32.TabIndex = 11;
			label32.Text = "NameSearch";
			// 
			// lbxContacts
			// 
			lbxContacts.FormattingEnabled = true;
			lbxContacts.ItemHeight = 15;
			lbxContacts.Location = new Point(25, 59);
			lbxContacts.Name = "lbxContacts";
			lbxContacts.Size = new Size(292, 679);
			lbxContacts.TabIndex = 10;
			// 
			// groupBox3
			// 
			groupBox3.Controls.Add(button3);
			groupBox3.Controls.Add(button4);
			groupBox3.Controls.Add(textBox21);
			groupBox3.Controls.Add(textBox22);
			groupBox3.Controls.Add(textBox23);
			groupBox3.Controls.Add(textBox24);
			groupBox3.Controls.Add(textBox25);
			groupBox3.Controls.Add(textBox26);
			groupBox3.Controls.Add(textBox27);
			groupBox3.Controls.Add(textBox28);
			groupBox3.Controls.Add(textBox29);
			groupBox3.Controls.Add(textBox30);
			groupBox3.Controls.Add(label21);
			groupBox3.Controls.Add(label22);
			groupBox3.Controls.Add(label23);
			groupBox3.Controls.Add(label24);
			groupBox3.Controls.Add(label25);
			groupBox3.Controls.Add(label26);
			groupBox3.Controls.Add(label27);
			groupBox3.Controls.Add(label28);
			groupBox3.Controls.Add(label29);
			groupBox3.Controls.Add(label30);
			groupBox3.Location = new Point(818, 43);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new Size(368, 340);
			groupBox3.TabIndex = 9;
			groupBox3.TabStop = false;
			groupBox3.Text = "Address:";
			// 
			// button3
			// 
			button3.Location = new Point(196, 296);
			button3.Name = "button3";
			button3.Size = new Size(75, 23);
			button3.TabIndex = 29;
			button3.Text = "Add Gallery";
			button3.UseVisualStyleBackColor = true;
			// 
			// button4
			// 
			button4.Location = new Point(277, 296);
			button4.Name = "button4";
			button4.Size = new Size(75, 23);
			button4.TabIndex = 28;
			button4.Text = "Update Gallery";
			button4.UseVisualStyleBackColor = true;
			// 
			// textBox21
			// 
			textBox21.Location = new Point(104, 263);
			textBox21.Name = "textBox21";
			textBox21.Size = new Size(248, 23);
			textBox21.TabIndex = 27;
			// 
			// textBox22
			// 
			textBox22.Location = new Point(104, 234);
			textBox22.Name = "textBox22";
			textBox22.Size = new Size(248, 23);
			textBox22.TabIndex = 26;
			// 
			// textBox23
			// 
			textBox23.Location = new Point(104, 205);
			textBox23.Name = "textBox23";
			textBox23.Size = new Size(248, 23);
			textBox23.TabIndex = 25;
			// 
			// textBox24
			// 
			textBox24.Location = new Point(104, 176);
			textBox24.Name = "textBox24";
			textBox24.Size = new Size(190, 23);
			textBox24.TabIndex = 24;
			// 
			// textBox25
			// 
			textBox25.Location = new Point(268, 145);
			textBox25.Name = "textBox25";
			textBox25.Size = new Size(84, 23);
			textBox25.TabIndex = 23;
			// 
			// textBox26
			// 
			textBox26.Location = new Point(104, 145);
			textBox26.Name = "textBox26";
			textBox26.Size = new Size(78, 23);
			textBox26.TabIndex = 22;
			// 
			// textBox27
			// 
			textBox27.Location = new Point(104, 116);
			textBox27.Name = "textBox27";
			textBox27.Size = new Size(248, 23);
			textBox27.TabIndex = 21;
			// 
			// textBox28
			// 
			textBox28.Location = new Point(104, 87);
			textBox28.Name = "textBox28";
			textBox28.Size = new Size(248, 23);
			textBox28.TabIndex = 20;
			// 
			// textBox29
			// 
			textBox29.Location = new Point(104, 58);
			textBox29.Name = "textBox29";
			textBox29.Size = new Size(248, 23);
			textBox29.TabIndex = 19;
			// 
			// textBox30
			// 
			textBox30.Location = new Point(104, 29);
			textBox30.Name = "textBox30";
			textBox30.Size = new Size(248, 23);
			textBox30.TabIndex = 18;
			// 
			// label21
			// 
			label21.AutoSize = true;
			label21.Location = new Point(6, 205);
			label21.Name = "label21";
			label21.Size = new Size(84, 15);
			label21.TabIndex = 17;
			label21.Text = "Email Address:";
			// 
			// label22
			// 
			label22.AutoSize = true;
			label22.Location = new Point(6, 237);
			label22.Name = "label22";
			label22.Size = new Size(56, 15);
			label22.TabIndex = 16;
			label22.Text = "Web Site:";
			// 
			// label23
			// 
			label23.AutoSize = true;
			label23.Location = new Point(6, 266);
			label23.Name = "label23";
			label23.Size = new Size(63, 15);
			label23.TabIndex = 15;
			label23.Text = "Instagram:";
			// 
			// label24
			// 
			label24.AutoSize = true;
			label24.Location = new Point(6, 179);
			label24.Name = "label24";
			label24.Size = new Size(44, 15);
			label24.TabIndex = 14;
			label24.Text = "Phone:";
			// 
			// label25
			// 
			label25.AutoSize = true;
			label25.Location = new Point(189, 153);
			label25.Name = "label25";
			label25.Size = new Size(73, 15);
			label25.TabIndex = 13;
			label25.Text = "Postal Code:";
			// 
			// label26
			// 
			label26.AutoSize = true;
			label26.Location = new Point(6, 153);
			label26.Name = "label26";
			label26.Size = new Size(36, 15);
			label26.TabIndex = 12;
			label26.Text = "State:";
			// 
			// label27
			// 
			label27.AutoSize = true;
			label27.Location = new Point(6, 119);
			label27.Name = "label27";
			label27.Size = new Size(31, 15);
			label27.TabIndex = 11;
			label27.Text = "City:";
			// 
			// label28
			// 
			label28.AutoSize = true;
			label28.Location = new Point(6, 90);
			label28.Name = "label28";
			label28.Size = new Size(61, 15);
			label28.TabIndex = 10;
			label28.Text = "Address 2:";
			// 
			// label29
			// 
			label29.AutoSize = true;
			label29.Location = new Point(6, 61);
			label29.Name = "label29";
			label29.Size = new Size(61, 15);
			label29.TabIndex = 9;
			label29.Text = "Address 1:";
			// 
			// label30
			// 
			label30.AutoSize = true;
			label30.Location = new Point(6, 32);
			label30.Name = "label30";
			label30.Size = new Size(42, 15);
			label30.TabIndex = 8;
			label30.Text = "Name:";
			// 
			// tabPageGalleries
			// 
			tabPageGalleries.Controls.Add(groupBox4);
			tabPageGalleries.Controls.Add(groupBox1);
			tabPageGalleries.Controls.Add(lbxGalleries);
			tabPageGalleries.Location = new Point(4, 24);
			tabPageGalleries.Name = "tabPageGalleries";
			tabPageGalleries.Padding = new Padding(3);
			tabPageGalleries.Size = new Size(1265, 863);
			tabPageGalleries.TabIndex = 1;
			tabPageGalleries.Text = "Galleries";
			tabPageGalleries.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			groupBox4.Controls.Add(btnAddExhibition);
			groupBox4.Controls.Add(dataGridView_GalleryExhibition);
			groupBox4.Location = new Point(18, 431);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new Size(687, 380);
			groupBox4.TabIndex = 10;
			groupBox4.TabStop = false;
			groupBox4.Text = "Exhibitions:";
			// 
			// btnAddExhibition
			// 
			btnAddExhibition.Location = new Point(515, 337);
			btnAddExhibition.Name = "btnAddExhibition";
			btnAddExhibition.Size = new Size(160, 23);
			btnAddExhibition.TabIndex = 11;
			btnAddExhibition.Text = "Add Exhibition...";
			btnAddExhibition.UseVisualStyleBackColor = true;
			btnAddExhibition.Click += btnAddExhibition_Click;
			// 
			// dataGridView_GalleryExhibition
			// 
			dataGridView_GalleryExhibition.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView_GalleryExhibition.Location = new Point(6, 22);
			dataGridView_GalleryExhibition.Name = "dataGridView_GalleryExhibition";
			dataGridView_GalleryExhibition.Size = new Size(669, 296);
			dataGridView_GalleryExhibition.TabIndex = 10;
			dataGridView_GalleryExhibition.CellContentDoubleClick += dataGridView_GalleryExhibition_CellContentDoubleClick;
			// 
			// groupBox1
			// 
			groupBox1.Controls.Add(label31);
			groupBox1.Controls.Add(tbGalleryCountry);
			groupBox1.Controls.Add(btnGalleryAdd);
			groupBox1.Controls.Add(btnGalleryUpdate);
			groupBox1.Controls.Add(tbGalleryInstagram);
			groupBox1.Controls.Add(tbGalleryWebSite);
			groupBox1.Controls.Add(tbGalleryEmailAddress);
			groupBox1.Controls.Add(tbGalleryPhone);
			groupBox1.Controls.Add(tbGalleryPostalCode);
			groupBox1.Controls.Add(tbGalleryState);
			groupBox1.Controls.Add(tbGalleryCity);
			groupBox1.Controls.Add(tbGalleryAddress2);
			groupBox1.Controls.Add(tbGalleryAddress1);
			groupBox1.Controls.Add(tbGalleryName);
			groupBox1.Controls.Add(label10);
			groupBox1.Controls.Add(label9);
			groupBox1.Controls.Add(label8);
			groupBox1.Controls.Add(label7);
			groupBox1.Controls.Add(label6);
			groupBox1.Controls.Add(label5);
			groupBox1.Controls.Add(label4);
			groupBox1.Controls.Add(label3);
			groupBox1.Controls.Add(label2);
			groupBox1.Controls.Add(label1);
			groupBox1.Location = new Point(325, 37);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new Size(368, 371);
			groupBox1.TabIndex = 8;
			groupBox1.TabStop = false;
			groupBox1.Text = "Address:";
			// 
			// label31
			// 
			label31.AutoSize = true;
			label31.Location = new Point(6, 299);
			label31.Name = "label31";
			label31.Size = new Size(53, 15);
			label31.TabIndex = 31;
			label31.Text = "Country:";
			// 
			// tbGalleryCountry
			// 
			tbGalleryCountry.Location = new Point(104, 296);
			tbGalleryCountry.Name = "tbGalleryCountry";
			tbGalleryCountry.Size = new Size(248, 23);
			tbGalleryCountry.TabIndex = 30;
			// 
			// btnGalleryAdd
			// 
			btnGalleryAdd.Location = new Point(104, 333);
			btnGalleryAdd.Name = "btnGalleryAdd";
			btnGalleryAdd.Size = new Size(112, 23);
			btnGalleryAdd.TabIndex = 29;
			btnGalleryAdd.Text = "Add Gallery";
			btnGalleryAdd.UseVisualStyleBackColor = true;
			btnGalleryAdd.Click += btnGalleryAdd_Click;
			// 
			// btnGalleryUpdate
			// 
			btnGalleryUpdate.Location = new Point(236, 333);
			btnGalleryUpdate.Name = "btnGalleryUpdate";
			btnGalleryUpdate.Size = new Size(116, 23);
			btnGalleryUpdate.TabIndex = 28;
			btnGalleryUpdate.Text = "Update Gallery";
			btnGalleryUpdate.UseVisualStyleBackColor = true;
			btnGalleryUpdate.Click += btnGalleryUpdate_Click;
			// 
			// tbGalleryInstagram
			// 
			tbGalleryInstagram.Location = new Point(104, 263);
			tbGalleryInstagram.Name = "tbGalleryInstagram";
			tbGalleryInstagram.Size = new Size(248, 23);
			tbGalleryInstagram.TabIndex = 27;
			// 
			// tbGalleryWebSite
			// 
			tbGalleryWebSite.Location = new Point(104, 234);
			tbGalleryWebSite.Name = "tbGalleryWebSite";
			tbGalleryWebSite.Size = new Size(248, 23);
			tbGalleryWebSite.TabIndex = 26;
			// 
			// tbGalleryEmailAddress
			// 
			tbGalleryEmailAddress.Location = new Point(104, 205);
			tbGalleryEmailAddress.Name = "tbGalleryEmailAddress";
			tbGalleryEmailAddress.Size = new Size(248, 23);
			tbGalleryEmailAddress.TabIndex = 25;
			// 
			// tbGalleryPhone
			// 
			tbGalleryPhone.Location = new Point(104, 176);
			tbGalleryPhone.Name = "tbGalleryPhone";
			tbGalleryPhone.Size = new Size(190, 23);
			tbGalleryPhone.TabIndex = 24;
			// 
			// tbGalleryPostalCode
			// 
			tbGalleryPostalCode.Location = new Point(268, 145);
			tbGalleryPostalCode.Name = "tbGalleryPostalCode";
			tbGalleryPostalCode.Size = new Size(84, 23);
			tbGalleryPostalCode.TabIndex = 23;
			// 
			// tbGalleryState
			// 
			tbGalleryState.Location = new Point(104, 145);
			tbGalleryState.Name = "tbGalleryState";
			tbGalleryState.Size = new Size(78, 23);
			tbGalleryState.TabIndex = 22;
			// 
			// tbGalleryCity
			// 
			tbGalleryCity.Location = new Point(104, 116);
			tbGalleryCity.Name = "tbGalleryCity";
			tbGalleryCity.Size = new Size(248, 23);
			tbGalleryCity.TabIndex = 21;
			// 
			// tbGalleryAddress2
			// 
			tbGalleryAddress2.Location = new Point(104, 87);
			tbGalleryAddress2.Name = "tbGalleryAddress2";
			tbGalleryAddress2.Size = new Size(248, 23);
			tbGalleryAddress2.TabIndex = 20;
			// 
			// tbGalleryAddress1
			// 
			tbGalleryAddress1.Location = new Point(104, 58);
			tbGalleryAddress1.Name = "tbGalleryAddress1";
			tbGalleryAddress1.Size = new Size(248, 23);
			tbGalleryAddress1.TabIndex = 19;
			// 
			// tbGalleryName
			// 
			tbGalleryName.Location = new Point(104, 29);
			tbGalleryName.Name = "tbGalleryName";
			tbGalleryName.Size = new Size(248, 23);
			tbGalleryName.TabIndex = 18;
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new Point(6, 205);
			label10.Name = "label10";
			label10.Size = new Size(84, 15);
			label10.TabIndex = 17;
			label10.Text = "Email Address:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new Point(6, 237);
			label9.Name = "label9";
			label9.Size = new Size(56, 15);
			label9.TabIndex = 16;
			label9.Text = "Web Site:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(6, 266);
			label8.Name = "label8";
			label8.Size = new Size(63, 15);
			label8.TabIndex = 15;
			label8.Text = "Instagram:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(6, 179);
			label7.Name = "label7";
			label7.Size = new Size(44, 15);
			label7.TabIndex = 14;
			label7.Text = "Phone:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(189, 153);
			label6.Name = "label6";
			label6.Size = new Size(73, 15);
			label6.TabIndex = 13;
			label6.Text = "Postal Code:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(6, 153);
			label5.Name = "label5";
			label5.Size = new Size(36, 15);
			label5.TabIndex = 12;
			label5.Text = "State:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(6, 119);
			label4.Name = "label4";
			label4.Size = new Size(31, 15);
			label4.TabIndex = 11;
			label4.Text = "City:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(6, 90);
			label3.Name = "label3";
			label3.Size = new Size(61, 15);
			label3.TabIndex = 10;
			label3.Text = "Address 2:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(6, 61);
			label2.Name = "label2";
			label2.Size = new Size(61, 15);
			label2.TabIndex = 9;
			label2.Text = "Address 1:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(6, 32);
			label1.Name = "label1";
			label1.Size = new Size(42, 15);
			label1.TabIndex = 8;
			label1.Text = "Name:";
			// 
			// lbxGalleries
			// 
			lbxGalleries.FormattingEnabled = true;
			lbxGalleries.ItemHeight = 15;
			lbxGalleries.Location = new Point(18, 37);
			lbxGalleries.Name = "lbxGalleries";
			lbxGalleries.Size = new Size(283, 364);
			lbxGalleries.TabIndex = 0;
			lbxGalleries.SelectedIndexChanged += lbxGalleries_SelectedIndexChanged;
			// 
			// tabPageFestivals
			// 
			tabPageFestivals.Controls.Add(groupBox2);
			tabPageFestivals.Location = new Point(4, 24);
			tabPageFestivals.Name = "tabPageFestivals";
			tabPageFestivals.Padding = new Padding(3);
			tabPageFestivals.Size = new Size(1265, 863);
			tabPageFestivals.TabIndex = 2;
			tabPageFestivals.Text = "Festivals";
			tabPageFestivals.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			groupBox2.Controls.Add(button1);
			groupBox2.Controls.Add(button2);
			groupBox2.Controls.Add(textBox11);
			groupBox2.Controls.Add(textBox12);
			groupBox2.Controls.Add(textBox13);
			groupBox2.Controls.Add(textBox14);
			groupBox2.Controls.Add(textBox15);
			groupBox2.Controls.Add(textBox16);
			groupBox2.Controls.Add(textBox17);
			groupBox2.Controls.Add(textBox18);
			groupBox2.Controls.Add(textBox19);
			groupBox2.Controls.Add(textBox20);
			groupBox2.Controls.Add(label11);
			groupBox2.Controls.Add(label12);
			groupBox2.Controls.Add(label13);
			groupBox2.Controls.Add(label14);
			groupBox2.Controls.Add(label15);
			groupBox2.Controls.Add(label16);
			groupBox2.Controls.Add(label17);
			groupBox2.Controls.Add(label18);
			groupBox2.Controls.Add(label19);
			groupBox2.Controls.Add(label20);
			groupBox2.Location = new Point(448, 261);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new Size(368, 340);
			groupBox2.TabIndex = 9;
			groupBox2.TabStop = false;
			groupBox2.Text = "Address:";
			// 
			// button1
			// 
			button1.Location = new Point(196, 296);
			button1.Name = "button1";
			button1.Size = new Size(75, 23);
			button1.TabIndex = 29;
			button1.Text = "Add Gallery";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Location = new Point(277, 296);
			button2.Name = "button2";
			button2.Size = new Size(75, 23);
			button2.TabIndex = 28;
			button2.Text = "Update Gallery";
			button2.UseVisualStyleBackColor = true;
			// 
			// textBox11
			// 
			textBox11.Location = new Point(104, 263);
			textBox11.Name = "textBox11";
			textBox11.Size = new Size(248, 23);
			textBox11.TabIndex = 27;
			// 
			// textBox12
			// 
			textBox12.Location = new Point(104, 234);
			textBox12.Name = "textBox12";
			textBox12.Size = new Size(248, 23);
			textBox12.TabIndex = 26;
			// 
			// textBox13
			// 
			textBox13.Location = new Point(104, 205);
			textBox13.Name = "textBox13";
			textBox13.Size = new Size(248, 23);
			textBox13.TabIndex = 25;
			// 
			// textBox14
			// 
			textBox14.Location = new Point(104, 176);
			textBox14.Name = "textBox14";
			textBox14.Size = new Size(190, 23);
			textBox14.TabIndex = 24;
			// 
			// textBox15
			// 
			textBox15.Location = new Point(268, 145);
			textBox15.Name = "textBox15";
			textBox15.Size = new Size(84, 23);
			textBox15.TabIndex = 23;
			// 
			// textBox16
			// 
			textBox16.Location = new Point(104, 145);
			textBox16.Name = "textBox16";
			textBox16.Size = new Size(78, 23);
			textBox16.TabIndex = 22;
			// 
			// textBox17
			// 
			textBox17.Location = new Point(104, 116);
			textBox17.Name = "textBox17";
			textBox17.Size = new Size(248, 23);
			textBox17.TabIndex = 21;
			// 
			// textBox18
			// 
			textBox18.Location = new Point(104, 87);
			textBox18.Name = "textBox18";
			textBox18.Size = new Size(248, 23);
			textBox18.TabIndex = 20;
			// 
			// textBox19
			// 
			textBox19.Location = new Point(104, 58);
			textBox19.Name = "textBox19";
			textBox19.Size = new Size(248, 23);
			textBox19.TabIndex = 19;
			// 
			// textBox20
			// 
			textBox20.Location = new Point(104, 29);
			textBox20.Name = "textBox20";
			textBox20.Size = new Size(248, 23);
			textBox20.TabIndex = 18;
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new Point(6, 205);
			label11.Name = "label11";
			label11.Size = new Size(84, 15);
			label11.TabIndex = 17;
			label11.Text = "Email Address:";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new Point(6, 237);
			label12.Name = "label12";
			label12.Size = new Size(56, 15);
			label12.TabIndex = 16;
			label12.Text = "Web Site:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new Point(6, 266);
			label13.Name = "label13";
			label13.Size = new Size(63, 15);
			label13.TabIndex = 15;
			label13.Text = "Instagram:";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new Point(6, 179);
			label14.Name = "label14";
			label14.Size = new Size(44, 15);
			label14.TabIndex = 14;
			label14.Text = "Phone:";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new Point(189, 153);
			label15.Name = "label15";
			label15.Size = new Size(73, 15);
			label15.TabIndex = 13;
			label15.Text = "Postal Code:";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new Point(6, 153);
			label16.Name = "label16";
			label16.Size = new Size(36, 15);
			label16.TabIndex = 12;
			label16.Text = "State:";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new Point(6, 119);
			label17.Name = "label17";
			label17.Size = new Size(31, 15);
			label17.TabIndex = 11;
			label17.Text = "City:";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new Point(6, 90);
			label18.Name = "label18";
			label18.Size = new Size(61, 15);
			label18.TabIndex = 10;
			label18.Text = "Address 2:";
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new Point(6, 61);
			label19.Name = "label19";
			label19.Size = new Size(61, 15);
			label19.TabIndex = 9;
			label19.Text = "Address 1:";
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new Point(6, 32);
			label20.Name = "label20";
			label20.Size = new Size(42, 15);
			label20.TabIndex = 8;
			label20.Text = "Name:";
			// 
			// tabPageLog
			// 
			tabPageLog.Location = new Point(4, 24);
			tabPageLog.Name = "tabPageLog";
			tabPageLog.Padding = new Padding(3);
			tabPageLog.Size = new Size(1265, 863);
			tabPageLog.TabIndex = 3;
			tabPageLog.Text = "Log";
			tabPageLog.UseVisualStyleBackColor = true;
			// 
			// tabPageArtPieces
			// 
			tabPageArtPieces.Location = new Point(4, 24);
			tabPageArtPieces.Name = "tabPageArtPieces";
			tabPageArtPieces.Padding = new Padding(3);
			tabPageArtPieces.Size = new Size(1265, 863);
			tabPageArtPieces.TabIndex = 4;
			tabPageArtPieces.Text = "Art Pieces";
			tabPageArtPieces.UseVisualStyleBackColor = true;
			// 
			// tabPageExhibitions
			// 
			tabPageExhibitions.Location = new Point(4, 24);
			tabPageExhibitions.Name = "tabPageExhibitions";
			tabPageExhibitions.Padding = new Padding(3);
			tabPageExhibitions.Size = new Size(1265, 863);
			tabPageExhibitions.TabIndex = 5;
			tabPageExhibitions.Text = "Exhibitions";
			tabPageExhibitions.UseVisualStyleBackColor = true;
			// 
			// btnClose
			// 
			btnClose.Location = new Point(879, 972);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(92, 30);
			btnClose.TabIndex = 1;
			btnClose.Text = "&Close";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1297, 1027);
			Controls.Add(btnClose);
			Controls.Add(tabControl1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			Icon = (Icon)resources.GetObject("$this.Icon");
			MaximizeBox = false;
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Artist Registry";
			Load += MainForm_Load;
			tabControl1.ResumeLayout(false);
			tabPageContacts.ResumeLayout(false);
			tabPageContacts.PerformLayout();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			tabPageGalleries.ResumeLayout(false);
			groupBox4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dataGridView_GalleryExhibition).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox1.PerformLayout();
			tabPageFestivals.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			groupBox2.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabPageContacts;
		private TabPage tabPageGalleries;
		private TabPage tabPageFestivals;
		private Button btnClose;
		private TabPage tabPageLog;
		private ListBox lbxGalleries;
		private TabPage tabPageArtPieces;
		private TabPage tabPageExhibitions;
		private GroupBox groupBox1;
		private Label label10;
		private Label label9;
		private Label label8;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private Button btnGalleryAdd;
		private Button btnGalleryUpdate;
		private TextBox tbGalleryInstagram;
		private TextBox tbGalleryWebSite;
		private TextBox tbGalleryEmailAddress;
		private TextBox tbGalleryPhone;
		private TextBox tbGalleryPostalCode;
		private TextBox tbGalleryState;
		private TextBox tbGalleryCity;
		private TextBox tbGalleryAddress2;
		private TextBox tbGalleryAddress1;
		private TextBox tbGalleryName;
		private GroupBox groupBox3;
		private Button button3;
		private Button button4;
		private TextBox textBox21;
		private TextBox textBox22;
		private TextBox textBox23;
		private TextBox textBox24;
		private TextBox textBox25;
		private TextBox textBox26;
		private TextBox textBox27;
		private TextBox textBox28;
		private TextBox textBox29;
		private TextBox textBox30;
		private Label label21;
		private Label label22;
		private Label label23;
		private Label label24;
		private Label label25;
		private Label label26;
		private Label label27;
		private Label label28;
		private Label label29;
		private Label label30;
		private GroupBox groupBox2;
		private Button button1;
		private Button button2;
		private TextBox textBox11;
		private TextBox textBox12;
		private TextBox textBox13;
		private TextBox textBox14;
		private TextBox textBox15;
		private TextBox textBox16;
		private TextBox textBox17;
		private TextBox textBox18;
		private TextBox textBox19;
		private TextBox textBox20;
		private Label label11;
		private Label label12;
		private Label label13;
		private Label label14;
		private Label label15;
		private Label label16;
		private Label label17;
		private Label label18;
		private Label label19;
		private Label label20;
		private Label label31;
		private TextBox tbGalleryCountry;
		private GroupBox groupBox4;
		private Button btnAddExhibition;
		private DataGridView dataGridView_GalleryExhibition;
		private Button button5;
		private TextBox tbContactNameSearch;
		private Label label32;
		private ListBox lbxContacts;
	}
}
