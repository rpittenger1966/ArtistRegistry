using ArtistRegistry.Standard.Common;
using ArtistRegistry.Standard.Data;
using ArtistRegistry.Standard.Data.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistRegistryApp
{
	public partial class ContactSearchForm : Form
	{
		public Contact Contact { get; set; }
		private ContactProvider _provider;
		private bool _firstNameChangeEnabled;
		private bool _lastNameChanngeEnabled;

		public ContactSearchForm()
		{
			InitializeComponent();
			_provider = new ContactProvider(ConnectionStringFactory.GetConnectionString(), Guid.Empty);
			Contact = new Contact();
			_firstNameChangeEnabled = true;
			_lastNameChanngeEnabled = true;
		}

		private void ContactSearchForm_Load(object sender, EventArgs e)
		{
			DisplayContact(this.Contact);


		}

		private async Task FillListBox(string sql)
		{
			try
			{
				listBox1.Items.Clear();
				List<Contact> contactList = await _provider.GetContactsByQueryAsync(sql);
				foreach (Contact c in contactList)
				{
					listBox1.Items.Add(c);
				}
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (listBox1.SelectedIndex < 0)
				{
					this.Contact = new Contact();
				}
				else
				{
					this.Contact = listBox1.Items[listBox1.SelectedIndex] as Contact;
					_firstNameChangeEnabled = false;
					_lastNameChanngeEnabled = false;
					DisplayContact(this.Contact);
					_firstNameChangeEnabled = true;
					_lastNameChanngeEnabled = true;
				}

			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}


		private async void tbLastName_TextChanged(object sender, EventArgs e)
		{
			if (!_lastNameChanngeEnabled) return;
			ContactQueryBuilder builder = new ContactQueryBuilder();
			string sql = builder.BuildFirstNameLastNameQuery(tbFirstName.Text, tbLastName.Text);
			await FillListBox(sql);
		}

		private void DisplayContact(Contact contact)
		{
			tbFirstName.Text = contact.FirstName;
			tbLastName.Text = contact.LastName;
			cbxGender.Text = contact.Gender;

			tbAddress1.Text = contact.Address1;
			tbAddress2.Text = contact.Address2;
			tbCity.Text = contact.City;
			tbState.Text = contact.State;
			tbPostalCode.Text = contact.PostalCode;

			tbCountry.Text = contact.Country;
			tbEmailAddress.Text = contact.Email;
			tbInstagram.Text = contact.Instagram;
			tbPhone.Text = contact.Phone;
			tbWebSite.Text = contact.WebSite;

			this.Contact = contact;

		}

		private void UpdateContact(Contact contact)
		{
			contact.FirstName = tbFirstName.Text;
			contact.LastName = tbLastName.Text;
			contact.Gender = cbxGender.Text;

			contact.Address1 = tbAddress1.Text;
			contact.Address2 = tbAddress2.Text;
			contact.City = tbCity.Text;
			contact.State = tbState.Text;
			contact.PostalCode = tbPostalCode.Text;

			contact.Country = tbCountry.Text;
			contact.Email = tbEmailAddress.Text;
			contact.Instagram = tbInstagram.Text;
			contact.Phone = tbPhone.Text;
			contact.WebSite = tbWebSite.Text;

			this.Contact = contact;

		}


		private void HandleException(Exception ex)
		{
			MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private async void tbFirstName_TextChanged(object sender, EventArgs e)
		{
			if (!_firstNameChangeEnabled) return;
			ContactQueryBuilder builder = new ContactQueryBuilder();
			string sql = builder.BuildFirstNameLastNameQuery(tbFirstName.Text, tbLastName.Text);
			await FillListBox(sql);
		}

		private async void btnOk_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.Contact == null) this.Contact = new Contact();
				UpdateContact(this.Contact);

				if (this.Contact.ContactId == 0)
				{
					this.Contact.ContactId = await _provider.InsertContactAsync(this.Contact);
				}
				else
				{
					await _provider.UpdateContactAsync(this.Contact);
				}

				DialogResult = DialogResult.OK;
			}
			catch (Exception ex)
			{
				this.DialogResult = DialogResult.None;
				HandleException(ex);
			}
		}
	}  // end of class
}  // end of namespace
