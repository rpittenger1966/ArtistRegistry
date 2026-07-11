using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class ArtistEntryDataReader
	{

				static public ArtistRegistry.Standard.Data.ArtistEntry BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.ArtistEntry o = new ArtistRegistry.Standard.Data.ArtistEntry();

			o.ContentFileName = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "ContentFileName");
			o.FirstLetterId = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "FirstLetterId");
			o.LastUpdated = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "LastUpdated");
			o.Slug = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Slug");
			o.Url = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Url");

			return o;
		}


	}  // end of class
}  // end of namespace
