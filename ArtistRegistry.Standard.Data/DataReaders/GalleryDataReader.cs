using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class GalleryDataReader
	{

				static public ArtistRegistry.Standard.Data.Gallery BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.Gallery o = new ArtistRegistry.Standard.Data.Gallery();

			o.Address1 = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Address1");
			o.Address2 = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Address2");
			o.City = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "City");
			o.Country = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Country");
			o.CreateDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "CreateDate");
			o.DeviantArt = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "DeviantArt");
			o.EmailAddress = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "EmailAddress");
			o.Facebook = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Facebook");
			o.GalleryId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "GalleryId");
			o.Instagram = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Instagram");
			o.ModifyDate = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "ModifyDate");
			o.Name = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Name");
			o.Phone = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Phone");
			o.PostalCode = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "PostalCode");
			o.State = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "State");
			o.WebSite = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "WebSite");
			o.YouTube = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "YouTube");

			return o;
		}


	}  // end of class
}  // end of namespace
