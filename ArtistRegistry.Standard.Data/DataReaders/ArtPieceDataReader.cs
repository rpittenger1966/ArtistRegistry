using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class ArtPieceDataReader
	{

				static public ArtistRegistry.Standard.Data.ArtPiece BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.ArtPiece o = new ArtistRegistry.Standard.Data.ArtPiece();

			o.ArtPieceId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ArtPieceId");
			o.Category = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Category");
			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");
			o.CreateDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "CreateDate");
			o.Medium = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Medium");
			o.ModifyDate = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "ModifyDate");
			o.Price = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableInt(reader, "Price");
			o.Size = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Size");
			o.Title = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Title");

			return o;
		}


	}  // end of class
}  // end of namespace
