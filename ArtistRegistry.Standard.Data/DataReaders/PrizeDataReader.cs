using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class PrizeDataReader
	{

				static public ArtistRegistry.Standard.Data.Prize BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.Prize o = new ArtistRegistry.Standard.Data.Prize();

			o.Name = ArtistRegistry.Standard.Data.AdoHelper.ReadString(reader, "Name");
			o.PrizeId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "PrizeId");

			return o;
		}


	}  // end of class
}  // end of namespace
