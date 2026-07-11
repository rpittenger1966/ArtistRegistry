using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class GalleryExhibitionDataReader
	{

				static public ArtistRegistry.Standard.Data.GalleryExhibition BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.GalleryExhibition o = new ArtistRegistry.Standard.Data.GalleryExhibition();

			o.CreateDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "CreateDate");
			o.EndDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "EndDate");
			o.GalleryExhibitionId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "GalleryExhibitionId");
			o.GalleryId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "GalleryId");
			o.ModifyDate = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "ModifyDate");
			o.StartDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "StartDate");

			return o;
		}


	}  // end of class
}  // end of namespace
