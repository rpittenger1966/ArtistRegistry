using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class GalleryExhibitionPrizeDataReader
	{

				static public ArtistRegistry.Standard.Data.GalleryExhibitionPrize BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.GalleryExhibitionPrize o = new ArtistRegistry.Standard.Data.GalleryExhibitionPrize();

			o.ArtPieceId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ArtPieceId");
			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");
			o.GalleryExhibitionId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "GalleryExhibitionId");
			o.GalleryExhibitionPrizeId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "GalleryExhibitionPrizeId");
			o.PrizeId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "PrizeId");

			return o;
		}


	}  // end of class
}  // end of namespace
