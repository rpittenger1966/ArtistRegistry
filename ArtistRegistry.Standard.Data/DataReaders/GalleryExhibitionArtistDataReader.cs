using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class GalleryExhibitionArtistDataReader
	{

				static public ArtistRegistry.Standard.Data.GalleryExhibitionArtist BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.GalleryExhibitionArtist o = new ArtistRegistry.Standard.Data.GalleryExhibitionArtist();

			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");
			o.GalleryExhibitionId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "GalleryExhibitionId");

			return o;
		}


	}  // end of class
}  // end of namespace
