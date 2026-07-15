using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistRegistry.Standard.Common
{
	public class ConnectionStringFactory
	{
		static public string GetConnectionString()
		{
			return "Server=(local);Database=ArtistRegistry;Trusted_Connection=True;TrustServerCertificate=True;";
		}
	}
}
