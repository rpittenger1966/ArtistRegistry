namespace ArtistRegistryApp
{
	partial class GalleryExhibitionForm
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
			label1 = new Label();
			dateTimePickerStart = new DateTimePicker();
			dateTimePickerEnd = new DateTimePicker();
			label2 = new Label();
			lblGallery = new Label();
			label3 = new Label();
			tbExhibitionName = new TextBox();
			btnSave = new Button();
			btnClose = new Button();
			btnAddArtist = new Button();
			lbxArtists = new ListBox();
			btnRemoveArtist = new Button();
			label4 = new Label();
			label5 = new Label();
			label6 = new Label();
			label7 = new Label();
			tbArtCallUrl = new TextBox();
			tbProspectusUrl = new TextBox();
			tbEntryDeadline = new TextBox();
			cbxEntryStatus = new ComboBox();
			label8 = new Label();
			tbNotes = new TextBox();
			btnRemoveJuror = new Button();
			lbxJurors = new ListBox();
			btnAddJuror = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 90);
			label1.Name = "label1";
			label1.Size = new Size(61, 15);
			label1.TabIndex = 1;
			label1.Text = "Start Date:";
			// 
			// dateTimePickerStart
			// 
			dateTimePickerStart.Location = new Point(153, 84);
			dateTimePickerStart.Name = "dateTimePickerStart";
			dateTimePickerStart.Size = new Size(200, 23);
			dateTimePickerStart.TabIndex = 2;
			// 
			// dateTimePickerEnd
			// 
			dateTimePickerEnd.Location = new Point(153, 113);
			dateTimePickerEnd.Name = "dateTimePickerEnd";
			dateTimePickerEnd.Size = new Size(200, 23);
			dateTimePickerEnd.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 119);
			label2.Name = "label2";
			label2.Size = new Size(57, 15);
			label2.TabIndex = 4;
			label2.Text = "End Date:";
			// 
			// lblGallery
			// 
			lblGallery.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
			lblGallery.Location = new Point(12, 9);
			lblGallery.Name = "lblGallery";
			lblGallery.Size = new Size(520, 39);
			lblGallery.TabIndex = 5;
			lblGallery.Text = "label3";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(12, 58);
			label3.Name = "label3";
			label3.Size = new Size(98, 15);
			label3.TabIndex = 6;
			label3.Text = "Exhibition Name:";
			// 
			// tbExhibitionName
			// 
			tbExhibitionName.Location = new Point(153, 55);
			tbExhibitionName.Name = "tbExhibitionName";
			tbExhibitionName.Size = new Size(379, 23);
			tbExhibitionName.TabIndex = 7;
			// 
			// btnSave
			// 
			btnSave.Location = new Point(377, 636);
			btnSave.Name = "btnSave";
			btnSave.Size = new Size(75, 23);
			btnSave.TabIndex = 8;
			btnSave.Text = "Save";
			btnSave.UseVisualStyleBackColor = true;
			btnSave.Click += btnSave_Click;
			// 
			// btnClose
			// 
			btnClose.Location = new Point(458, 636);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(75, 23);
			btnClose.TabIndex = 9;
			btnClose.Text = "Close";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// btnAddArtist
			// 
			btnAddArtist.Location = new Point(371, 407);
			btnAddArtist.Name = "btnAddArtist";
			btnAddArtist.Size = new Size(162, 23);
			btnAddArtist.TabIndex = 10;
			btnAddArtist.Text = "Add Artist...";
			btnAddArtist.UseVisualStyleBackColor = true;
			btnAddArtist.Click += btnAddArtist_Click;
			// 
			// lbxArtists
			// 
			lbxArtists.FormattingEnabled = true;
			lbxArtists.ItemHeight = 15;
			lbxArtists.Location = new Point(13, 407);
			lbxArtists.Name = "lbxArtists";
			lbxArtists.Size = new Size(341, 109);
			lbxArtists.TabIndex = 11;
			lbxArtists.SelectedIndexChanged += lbxArtists_SelectedIndexChanged;
			// 
			// btnRemoveArtist
			// 
			btnRemoveArtist.Location = new Point(371, 436);
			btnRemoveArtist.Name = "btnRemoveArtist";
			btnRemoveArtist.Size = new Size(162, 23);
			btnRemoveArtist.TabIndex = 12;
			btnRemoveArtist.Text = "Remove Artist";
			btnRemoveArtist.UseVisualStyleBackColor = true;
			btnRemoveArtist.Click += btnRemoveArtist_Click;
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(12, 145);
			label4.Name = "label4";
			label4.Size = new Size(73, 15);
			label4.TabIndex = 13;
			label4.Text = "Art Call URL:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 174);
			label5.Name = "label5";
			label5.Size = new Size(92, 15);
			label5.TabIndex = 14;
			label5.Text = "Prospectus URL:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new Point(12, 203);
			label6.Name = "label6";
			label6.Size = new Size(86, 15);
			label6.TabIndex = 15;
			label6.Text = "Entry Deadline:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new Point(13, 233);
			label7.Name = "label7";
			label7.Size = new Size(72, 15);
			label7.TabIndex = 16;
			label7.Text = "Entry Status:";
			// 
			// tbArtCallUrl
			// 
			tbArtCallUrl.Location = new Point(153, 142);
			tbArtCallUrl.Name = "tbArtCallUrl";
			tbArtCallUrl.Size = new Size(359, 23);
			tbArtCallUrl.TabIndex = 17;
			// 
			// tbProspectusUrl
			// 
			tbProspectusUrl.Location = new Point(153, 171);
			tbProspectusUrl.Name = "tbProspectusUrl";
			tbProspectusUrl.Size = new Size(359, 23);
			tbProspectusUrl.TabIndex = 18;
			// 
			// tbEntryDeadline
			// 
			tbEntryDeadline.Location = new Point(153, 200);
			tbEntryDeadline.Name = "tbEntryDeadline";
			tbEntryDeadline.Size = new Size(200, 23);
			tbEntryDeadline.TabIndex = 19;
			// 
			// cbxEntryStatus
			// 
			cbxEntryStatus.DropDownStyle = ComboBoxStyle.DropDownList;
			cbxEntryStatus.FormattingEnabled = true;
			cbxEntryStatus.Location = new Point(153, 230);
			cbxEntryStatus.Name = "cbxEntryStatus";
			cbxEntryStatus.Size = new Size(200, 23);
			cbxEntryStatus.TabIndex = 20;
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new Point(13, 269);
			label8.Name = "label8";
			label8.Size = new Size(41, 15);
			label8.TabIndex = 21;
			label8.Text = "Notes:";
			// 
			// tbNotes
			// 
			tbNotes.AcceptsReturn = true;
			tbNotes.Location = new Point(153, 269);
			tbNotes.Multiline = true;
			tbNotes.Name = "tbNotes";
			tbNotes.Size = new Size(359, 121);
			tbNotes.TabIndex = 22;
			// 
			// btnRemoveJuror
			// 
			btnRemoveJuror.Location = new Point(370, 551);
			btnRemoveJuror.Name = "btnRemoveJuror";
			btnRemoveJuror.Size = new Size(162, 23);
			btnRemoveJuror.TabIndex = 25;
			btnRemoveJuror.Text = "Remove Juror";
			btnRemoveJuror.UseVisualStyleBackColor = true;
			btnRemoveJuror.Click += btnRemoveJuror_Click;
			// 
			// lbxJurors
			// 
			lbxJurors.FormattingEnabled = true;
			lbxJurors.ItemHeight = 15;
			lbxJurors.Location = new Point(12, 522);
			lbxJurors.Name = "lbxJurors";
			lbxJurors.Size = new Size(341, 109);
			lbxJurors.TabIndex = 24;
			lbxJurors.SelectedIndexChanged += lbxJurors_SelectedIndexChanged;
			// 
			// btnAddJuror
			// 
			btnAddJuror.Location = new Point(370, 522);
			btnAddJuror.Name = "btnAddJuror";
			btnAddJuror.Size = new Size(162, 23);
			btnAddJuror.TabIndex = 23;
			btnAddJuror.Text = "Add Juror...";
			btnAddJuror.UseVisualStyleBackColor = true;
			btnAddJuror.Click += btnAddJuror_Click;
			// 
			// GalleryExhibitionForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(543, 678);
			Controls.Add(btnRemoveJuror);
			Controls.Add(lbxJurors);
			Controls.Add(btnAddJuror);
			Controls.Add(tbNotes);
			Controls.Add(label8);
			Controls.Add(cbxEntryStatus);
			Controls.Add(tbEntryDeadline);
			Controls.Add(tbProspectusUrl);
			Controls.Add(tbArtCallUrl);
			Controls.Add(label7);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(btnRemoveArtist);
			Controls.Add(lbxArtists);
			Controls.Add(btnAddArtist);
			Controls.Add(btnClose);
			Controls.Add(btnSave);
			Controls.Add(tbExhibitionName);
			Controls.Add(label3);
			Controls.Add(lblGallery);
			Controls.Add(label2);
			Controls.Add(dateTimePickerEnd);
			Controls.Add(dateTimePickerStart);
			Controls.Add(label1);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "GalleryExhibitionForm";
			ShowIcon = false;
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterParent;
			Text = "Gallery Exhibition";
			Load += GalleryExhibitionForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private Label label1;
		private DateTimePicker dateTimePickerStart;
		private DateTimePicker dateTimePickerEnd;
		private Label label2;
		private Label lblGallery;
		private Label label3;
		private TextBox tbExhibitionName;
		private Button btnSave;
		private Button btnClose;
		private Button btnAddArtist;
		private ListBox lbxArtists;
		private Button btnRemoveArtist;
		private Label label4;
		private Label label5;
		private Label label6;
		private Label label7;
		private TextBox tbArtCallUrl;
		private TextBox tbProspectusUrl;
		private TextBox tbEntryDeadline;
		private ComboBox cbxEntryStatus;
		private Label label8;
		private TextBox tbNotes;
		private Button btnRemoveJuror;
		private ListBox lbxJurors;
		private Button btnAddJuror;
	}
}