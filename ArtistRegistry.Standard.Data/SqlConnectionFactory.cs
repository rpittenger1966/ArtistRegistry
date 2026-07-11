using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistRegistry.Standard.Data
{
	public class SqlConnectionFactory
	{
		static public SqlConnection GetSqlConnection(string connectionString)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();
			return con;
		}

		static public SqlConnection GetSqlConnection(ProviderBase providerBase)
		{
			SqlConnection con = new SqlConnection(providerBase.ChattershotConnectionString);
			return con;
		}

	}
}
