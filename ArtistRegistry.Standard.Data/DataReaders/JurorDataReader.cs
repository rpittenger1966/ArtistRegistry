using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	/*  this is automatically generated code from Code Generator app - do not modify */


	public class JurorDataReader
	{

				static public ArtistRegistry.Standard.Data.Juror BuildFromDataReader(Microsoft.Data.SqlClient.SqlDataReader reader)
		{
			ArtistRegistry.Standard.Data.Juror o = new ArtistRegistry.Standard.Data.Juror();

			o.ContactId = ArtistRegistry.Standard.Data.AdoHelper.ReadInt(reader, "ContactId");

			return o;
		}


	}  // end of class
}  // end of namespace
