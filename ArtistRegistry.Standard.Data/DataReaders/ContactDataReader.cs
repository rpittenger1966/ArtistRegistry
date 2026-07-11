using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class ContactDataReader
	{

				static public ArtistRegistry.Standard.Data.Contact BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.Contact o = new ArtistRegistry.Standard.Data.Contact();

			o.Address1 = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Address1");
			o.Address2 = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Address2");
			o.BirthYear = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableInt(reader, "BirthYear");
			o.City = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "City");
			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");
			o.Country = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Country");
			o.CreateDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "CreateDate");
			o.DeviantArt = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "DeviantArt");
			o.Email = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Email");
			o.Facebook = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Facebook");
			o.FullName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "FullName");
			o.Gender = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Gender");
			o.Generation = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Generation");
			o.InitialSource = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "InitialSource");
			o.Instagram = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Instagram");
			o.LastName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "LastName");
			o.ModifyDate = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "ModifyDate");
			o.OhioArtistREgistry = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "OhioArtistREgistry");
			o.Phone = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Phone");
			o.PostalCode = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "PostalCode");
			o.State = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "State");
			o.StatusId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "StatusId");
			o.WebSite = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "WebSite");
			o.YouTube = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "YouTube");

			return o;
		}


	}  // end of class
}  // end of namespace
