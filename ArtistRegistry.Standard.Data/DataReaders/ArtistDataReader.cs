using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class ArtistDataReader
	{

				static public ArtistRegistry.Standard.Data.Artist BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.Artist o = new ArtistRegistry.Standard.Data.Artist();

			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");

			return o;
		}


	}  // end of class
}  // end of namespace
