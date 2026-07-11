using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class FestivalEventArtistDataReader
	{

				static public ArtistRegistry.Standard.Data.FestivalEventArtist BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.FestivalEventArtist o = new ArtistRegistry.Standard.Data.FestivalEventArtist();

			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");
			o.FestivalEventId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "FestivalEventId");

			return o;
		}


	}  // end of class
}  // end of namespace
