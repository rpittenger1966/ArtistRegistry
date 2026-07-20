using ArtistRegistry.Standard.Common;
using ArtistRegistry.Standard.Data;
using ArtistRegistry.Standard.Data.Providers;
using System.Data;
using System.Windows.Forms;

namespace ArtistRegistryApp
{
	public partial class MainForm : Form
	{
		private GalleryProvider _galleryProvider;
		private GalleryExhibitionProvider _galleryExhibitionProvider;
		private ContactProvider _contactProvider;
		private Gallery _selectedGallery;

		public MainForm()
		{
			InitializeComponent();
			_galleryProvider = new GalleryProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			_galleryExhibitionProvider = new GalleryExhibitionProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			_contactProvider = new ContactProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			_selectedGallery = null;
		}

		private async void MainForm_Load(object sender, EventArgs e)
		{
			try
			{
				await LoadGalleries(-1);
				await LoadContactSearchListBoxAsync(-1);
				EnableControls();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void HandleException(Exception ex)
		{
			MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void EnableControls()
		{
		}

		private async Task LoadGalleries(int id)
		{
			try
			{
				int selected = -1;
				lbxGalleries.Items.Clear();
				List<Gallery> galleryList = await _galleryProvider.GetGallerysAsync();
				foreach (var gallery in galleryList)
				{
					int index = lbxGalleries.Items.Add(gallery);
					if (gallery.GalleryId == id) selected = index;
				}

				if (selected >= 0)
				{
					lbxGalleries.SelectedIndex = selected;
				}
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private Gallery GetSelectedGallery()
		{
			try
			{
				int selected = lbxGalleries.SelectedIndex;
				if (selected < 0) return null;
				Gallery gallery = (Gallery)lbxGalleries.Items[selected];
				return gallery;
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
			return null;
		}

		private void lbxGalleries_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				Gallery gallery = GetSelectedGallery();
				DisplayGallery(gallery);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void DisplayGallery(Gallery gallery)
		{
			try
			{
				if (gallery is null)
				{
					int selected = lbxGalleries.SelectedIndex;
					if (selected < 0)
					{
						tbGalleryName.Text = "";
						tbGalleryAddress1.Text = "";
						tbGalleryAddress2.Text = "";
						tbGalleryCity.Text = "";
						tbGalleryState.Text = "";
						tbGalleryPostalCode.Text = "";
						tbGalleryPhone.Text = "";
						tbGalleryWebSite.Text = "";
						tbGalleryEmailAddress.Text = "";
						tbGalleryInstagram.Text = "";
						tbGalleryCountry.Text = "";
						_selectedGallery = null;
						EnableControls();
					}
					else
					{
						DisplayGallery(gallery);
					}
				}
				else
				{
					_selectedGallery = gallery;
					tbGalleryName.Text = gallery.Name;
					tbGalleryAddress1.Text = gallery.Address1;
					tbGalleryAddress2.Text = gallery.Address2;
					tbGalleryCity.Text = gallery.City;
					tbGalleryState.Text = gallery.State;
					tbGalleryPostalCode.Text = gallery.PostalCode;
					tbGalleryPhone.Text = gallery.Phone;
					tbGalleryWebSite.Text = gallery.WebSite;
					tbGalleryEmailAddress.Text = gallery.EmailAddress;
					tbGalleryInstagram.Text = gallery.Instagram;
					tbGalleryCountry.Text = gallery.Country;
				}

				FillGalleryExhibitionList();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void PopulateGallery(Gallery gallery)
		{
			gallery.Name = tbGalleryName.Text;
			gallery.Address1 = tbGalleryAddress1.Text;
			gallery.Address2 = tbGalleryAddress2.Text;
			gallery.City = tbGalleryCity.Text;
			gallery.State = tbGalleryState.Text;
			gallery.PostalCode = tbGalleryPostalCode.Text;
			gallery.Phone = tbGalleryPhone.Text;
			gallery.WebSite = tbGalleryWebSite.Text;
			gallery.EmailAddress = tbGalleryEmailAddress.Text;
			gallery.Instagram = tbGalleryInstagram.Text;
			gallery.Country = tbGalleryCountry.Text;
		}


		private void btnGalleryAdd_Click(object sender, EventArgs e)
		{
			try
			{
				lbxGalleries.SelectedIndex = -1;
				_selectedGallery = new Gallery();
				_selectedGallery.Country = "US";
				_selectedGallery.GalleryId = -1;

				DisplayGallery(_selectedGallery);

			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private async void btnGalleryUpdate_Click(object sender, EventArgs e)
		{
			try
			{
				if (_selectedGallery is null) return;

				PopulateGallery(_selectedGallery);

				if (_selectedGallery.GalleryId == -1)
				{
					_selectedGallery.GalleryId = await _galleryProvider.InsertGalleryAsync(_selectedGallery);
				}
				else
				{
					await _galleryProvider.UpdateGalleryAsync(_selectedGallery);
				}

				await LoadGalleries(_selectedGallery.GalleryId);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnAddExhibition_Click(object sender, EventArgs e)
		{
			try
			{
				if (_selectedGallery == null) throw new Exception("No gallery selected");

				GalleryExhibition galleryExhibition = new GalleryExhibition();
				galleryExhibition.GalleryExhibitionId = -1;
				galleryExhibition.GalleryId = _selectedGallery.GalleryId;

				GalleryExhibitionForm form = new GalleryExhibitionForm(_selectedGallery, galleryExhibition);
				if (form.ShowDialog() != DialogResult.OK) return;
				FillGalleryExhibitionList();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private async void FillGalleryExhibitionList()
		{
			try
			{
				if (_selectedGallery is null)
				{
					this.dataGridView_GalleryExhibition.DataSource = null;
				}
				else
				{
					string sql = $"SELECT * FROM [dbo].[GalleryExhibition] where GalleryId = {_selectedGallery.GalleryId} Order by [StartDate]";
					List<GalleryExhibition> list = await _galleryExhibitionProvider.GetGalleryExhibitionsByQueryAsync(sql);
					dataGridView_GalleryExhibition.DataSource = list;
				}
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}



		private async Task LoadContactSearchListBoxAsync(int selectedContact)
		{
			try
			{
				ContactQueryBuilder queryBuilder = new ContactQueryBuilder();
				string sql = queryBuilder.BuildQuery(tbContactNameSearch.Text);

				List<Contact> contactList = await _contactProvider.GetContactsByQueryAsync(sql);
				lbxContacts.Items.Clear();
				int selectedIndex = -1;
				foreach (var contact in contactList)
				{
					int index = lbxContacts.Items.Add(contact);
					if (contact.ContactId == selectedContact)
					{
						selectedIndex = index;
					}
				}
				lbxContacts.SelectedIndex = selectedIndex;

			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private async void tbContactNameSearch_TextChanged(object sender, EventArgs e)
		{
			await LoadContactSearchListBoxAsync(-1);
		}



		private void EditGalleryExhibition(GalleryExhibition galleryExhibition)
		{
			try
			{
				GalleryExhibitionForm form = new GalleryExhibitionForm(_selectedGallery, galleryExhibition);
				if (form.ShowDialog() != DialogResult.OK) return;
				FillGalleryExhibitionList();
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void dataGridView_GalleryExhibition_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			string s = e.RowIndex.ToString();
			if (_selectedGallery is null) return;

			DataGridViewRow row = dataGridView_GalleryExhibition.Rows[e.RowIndex];
			GalleryExhibition ge = row.DataBoundItem as GalleryExhibition;
			EditGalleryExhibition(ge);

			//			GalleryExhibitionProvider workSessionProvider = new GalleryExhibitionProvider(ConnectionStringFactory.GetConnectionString());
			//			List<GalleryExhibition> workSessionList = workSessionProvider.GetGalleryExhibitionsByQueryAsync();
			//			GalleryExhibition workSession = workSessionList[e.RowIndex];
			//			EditGalleryExhibition(workSession);

		}
	}  // end of class
}  // end of namespace
