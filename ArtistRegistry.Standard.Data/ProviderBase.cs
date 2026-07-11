using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data
{
	public class ProviderBase
	{
		protected string _connectionString;
		protected Guid _userId;

		protected ProviderBase(string connectionString)
		{
			_connectionString = connectionString;
			_userId = Guid.Empty;
		}

		protected ProviderBase(string connectionString, Guid userId)
		{
			_connectionString = connectionString;
			_userId = userId;
		}

		public string ChattershotConnectionString
		{
			get
			{
				return _connectionString;
			}
		}


		static protected string MaxLength(string input, int max)
		{
			if (String.IsNullOrEmpty(input)) return "";
			if (input.Length <= max) return input;
			return input.Substring(0, max);
		}

		protected async Task ExecuteQueryAsync(string sql, string errorMessage)
		{
			SqlConnection con = null;

			try
			{
				using (con = new SqlConnection(_connectionString))
				{
					con.Open();

					using (SqlCommand command = new SqlCommand(sql, con))
					{
						await command.ExecuteNonQueryAsync();
					}

					con.Close();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(errorMessage, ex);
			}
			finally
			{
				con?.Close();
			}
		}

		protected void ExecuteQuery(string sql, string errorMessage)
		{
			SqlConnection con = null;

			try
			{
				using (con = new SqlConnection(_connectionString))
				{
					con.Open();

					using (SqlCommand command = new SqlCommand(sql, con))
					{
						command.ExecuteNonQuery();
					}

					con.Close();
				}
			}
			catch (Exception ex)
			{
				throw new Exception(errorMessage, ex);
			}
			finally
			{
				con?.Close();
			}
		}


		static protected string BoolToSqlBit(bool b)
		{
			if (b) return "1";
			return "0";
		}
	}
}
