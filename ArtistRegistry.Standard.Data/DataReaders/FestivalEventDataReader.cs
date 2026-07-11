using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class FestivalEventDataReader
	{

				static public ArtistRegistry.Standard.Data.FestivalEvent BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.FestivalEvent o = new ArtistRegistry.Standard.Data.FestivalEvent();

			o.CreateDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "CreateDate");
			o.EndDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "EndDate");
			o.FestivalEventId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "FestivalEventId");
			o.FestivalId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "FestivalId");
			o.ModifyDate = ArtistRegistry.Standard.Data.AdoHelper.ReadNullableDateTime(reader, "ModifyDate");
			o.StartDate = ArtistRegistry.Standard.Data.AdoHelper.ReadDateTime(reader, "StartDate");

			return o;
		}


	}  // end of class
}  // end of namespace
