using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class ArtistDetailsDataReader
	{

				static public ArtistRegistry.Standard.Data.ArtistDetails BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.ArtistDetails o = new ArtistRegistry.Standard.Data.ArtistDetails();

			o.ContentFileName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "ContentFileName");
			o.FamilyName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "FamilyName");
			o.FirstLetterId = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "FirstLetterId");
			o.FullName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "FullName");
			o.GivenName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "GivenName");
			o.LastUpdated = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "LastUpdated");
			o.Slug = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Slug");
			o.Url = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Url");

			return o;
		}


	}  // end of class
}  // end of namespace
