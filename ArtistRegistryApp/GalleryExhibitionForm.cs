using ArtistRegistry.Standard.Common;
using ArtistRegistry.Standard.Data;
using ArtistRegistry.Standard.Data.Providers;
using JurorRegistry.Standard.Data.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistRegistryApp
{
	public partial class GalleryExhibitionForm : Form
	{
		private Gallery _gallery;
		private GalleryExhibition _galleryExhibition;
		private GalleryExhibitionProvider _provider;

		public GalleryExhibitionForm(Gallery gallery, GalleryExhibition galleryExhibition)
		{
			_gallery = gallery;
			_galleryExhibition = galleryExhibition;
			_provider = new GalleryExhibitionProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			InitializeComponent();
		}

		private async void GalleryExhibitionForm_Load(object sender, EventArgs e)
		{
			lblGallery.Text = _gallery.Name;

			if (_galleryExhibition.GalleryExhibitionId < 0)
			{
				dateTimePickerStart.Value = DateTime.Today;
				dateTimePickerEnd.Value = DateTime.Today;

			}
			else
			{
				dateTimePickerStart.Value = _galleryExhibition.StartDate;
				dateTimePickerEnd.Value = _galleryExhibition.EndDate;
				tbArtCallUrl.Text = _galleryExhibition.ArtCallUrl;
				tbEntryDeadline.Text = _galleryExhibition.EntryDealineString;
				tbExhibitionName.Text = _galleryExhibition.Name;
				tbProspectusUrl.Text = _galleryExhibition.ProspectusUrl;
				tbNotes.Text = _galleryExhibition.Notes;

			}

			await FillArtistListBoxAsync();
			await FillJurorListBoxAsync();

			EnableControls();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private async void btnAddArtist_Click(object sender, EventArgs e)
		{
			if (this._galleryExhibition.GalleryExhibitionId <= 0) return;

			ContactSearchForm form = new ContactSearchForm();
			if (form.ShowDialog() == DialogResult.OK)
			{
				int contactId = form.Contact.ContactId;

				GalleryExhibitionArtistProvider provider = new GalleryExhibitionArtistProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
				ArtistProvider artistProvider = new ArtistProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
				int? existing = await provider.GetByIdAsync(contactId, this._galleryExhibition.GalleryExhibitionId);
				if (existing != null) return;
				{
					await provider.InsertGalleryExhibitionArtistAsync(contactId, this._galleryExhibition.GalleryExhibitionId);
					await artistProvider.UpsertArtist(contactId);
				}
			}

			await FillArtistListBoxAsync();
		}

		private async void btnRemoveArtist_Click(object sender, EventArgs e)
		{
			try
			{
				int selected = lbxArtists.SelectedIndex;
				if (selected < 0) return;
				Contact contact = lbxArtists.Items[selected] as Contact;
				GalleryExhibitionArtistProvider provider = new GalleryExhibitionArtistProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
				await provider.DeleteByIdAsync(this._galleryExhibition.GalleryExhibitionId, contact.ContactId);
				lbxArtists.Items.RemoveAt(selected);
				await FillArtistListBoxAsync();
				EnableControls();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private async void btnSave_Click(object sender, EventArgs e)
		{
			try
			{
				await SaveGalleryExhibition();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private async Task SaveGalleryExhibition()
		{
			_galleryExhibition.StartDate = dateTimePickerStart.Value;
			_galleryExhibition.EndDate = dateTimePickerEnd.Value;
			_galleryExhibition.ArtCallUrl = tbArtCallUrl.Text;
			_galleryExhibition.EntryDealineString = tbEntryDeadline.Text;
			_galleryExhibition.Name = tbExhibitionName.Text;
			_galleryExhibition.ProspectusUrl = tbProspectusUrl.Text;
			_galleryExhibition.Notes = tbNotes.Text;
			_galleryExhibition.EntryStatus = null;


			if (_galleryExhibition.GalleryExhibitionId <= 0)
			{
				_galleryExhibition.GalleryExhibitionId = await _provider.InsertGalleryExhibitionAsync(_galleryExhibition);
			}
			else
			{
				await _provider.UpdateGalleryExhibitionAsync(_galleryExhibition);
			}
			EnableControls();
		}


		private void HandleException(Exception ex)
		{
			MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			EnableControls();
		}

		private void EnableControls()
		{
			btnAddArtist.Enabled = _galleryExhibition?.GalleryExhibitionId >= 0;
			btnRemoveArtist.Enabled = lbxArtists.SelectedIndex >= 0;
			btnAddJuror.Enabled = _galleryExhibition?.GalleryExhibitionId >= 0;
			btnRemoveJuror.Enabled = lbxJurors.SelectedIndex >= 0;
		}

		private async Task FillArtistListBoxAsync()
		{
			if (_galleryExhibition.GalleryExhibitionId <= 0) return;
			lbxArtists.Items.Clear();

			ContactProvider contactProvider = new ContactProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);

			string sql = $"SELECT c.* from [dbo].[Contact] as c join dbo.GalleryExhibitionArtist as gae on gae.ContactId = c.ContactId where gae.GalleryExhibitionId = {_galleryExhibition.GalleryExhibitionId} order by c.ContactId;";

			List<Contact> contactList = await contactProvider.GetContactsByQueryAsync(sql);
			foreach (var contact in contactList)
			{
				lbxArtists.Items.Add(contact);
			}

			EnableControls();
		}

		private async Task FillJurorListBoxAsync()
		{
			if (_galleryExhibition.GalleryExhibitionId <= 0) return;
			lbxJurors.Items.Clear();

			ContactProvider contactProvider = new ContactProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);

			string sql = $"SELECT c.* from [dbo].[Contact] as c join dbo.GalleryExhibitionJuror as gae on gae.ContactId = c.ContactId where gae.GalleryExhibitionId = {_galleryExhibition.GalleryExhibitionId} order by c.ContactId;";

			List<Contact> contactList = await contactProvider.GetContactsByQueryAsync(sql);
			foreach (var contact in contactList)
			{
				lbxJurors.Items.Add(contact);
			}

			EnableControls();
		}

		private void lbxArtists_SelectedIndexChanged(object sender, EventArgs e)
		{
			EnableControls();
		}

		private void lbxJurors_SelectedIndexChanged(object sender, EventArgs e)
		{
			EnableControls();

		}

		private async void btnAddJuror_Click(object sender, EventArgs e)
		{
			if (this._galleryExhibition.GalleryExhibitionId <= 0) return;

			ContactSearchForm form = new ContactSearchForm();
			if (form.ShowDialog() == DialogResult.OK)
			{
				int contactId = form.Contact.ContactId;

				GalleryExhibitionJurorProvider provider = new GalleryExhibitionJurorProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
				JurorProvider jurorProvider = new JurorProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
				int? existing = await provider.GetByIdAsync(contactId, this._galleryExhibition.GalleryExhibitionId);
				if (existing != null) return;
				{
					await provider.InsertGalleryExhibitionJurorAsync(contactId, this._galleryExhibition.GalleryExhibitionId);
					await jurorProvider.UpsertJuror(contactId);
				}
			}

			await FillJurorListBoxAsync();

		}

		private async void btnRemoveJuror_Click(object sender, EventArgs e)
		{
			try
			{
				int selected = lbxJurors.SelectedIndex;
				if (selected < 0) return;
				Contact contact = lbxJurors.Items[selected] as Contact;
				GalleryExhibitionJurorProvider provider = new GalleryExhibitionJurorProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
				await provider.DeleteByIdAsync(this._galleryExhibition.GalleryExhibitionId, contact.ContactId);
				lbxJurors.Items.RemoveAt(selected);
				await FillJurorListBoxAsync();
				EnableControls();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}

		}
	}  // end of class
}  // end of namespace
