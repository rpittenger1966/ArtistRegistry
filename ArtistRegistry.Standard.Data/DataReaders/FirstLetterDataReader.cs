using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class FirstLetterDataReader
	{

				static public ArtistRegistry.Standard.Data.FirstLetter BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.FirstLetter o = new ArtistRegistry.Standard.Data.FirstLetter();

			o.FirstLetterId = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "FirstLetterId");
			o.LastUpdated = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "LastUpdated");
			o.PageCount = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableInt(reader, "PageCount");
			o.Url = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Url");

			return o;
		}


	}  // end of class
}  // end of namespace
