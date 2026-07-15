using ArtistRegistry.Standard.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class FirstLetterProvider : ProviderBase
	{
		public FirstLetterProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		//public async Task<int> InsertFirstLetterAsync(FirstLetter entity)
		//{
		//	SqlConnection con = null;

		//	try
		//	{
		//		using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//		{
		//			return await InsertFirstLetterAsync(con, entity);
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//	finally
		//	{
		//		con?.Close();
		//	}
		//}

		//public async Task<int> InsertFirstLetterAsync(SqlConnection con, FirstLetter entity)
		//{
		//	string sql = @"INSERT INTO [oar].[FirstLetter]
  //         ([ContactId])
  //   VALUES
  //         (@ContactId, int,>);";

		//	sql = sql + "SELECT SCOPE_IDENTITY();";

		//	using (SqlCommand command = new SqlCommand(sql, con))
		//	{
		//		command.Parameters.AddWithValue("ContactId", entity.ContactId);

		//		object o = await command.ExecuteScalarAsync();

		//		int retval = Convert.ToInt32(o);
		//		return retval;
		//	}
		//}

		public async Task<List<FirstLetter>> GetFirstLettersAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetFirstLettersAsync(con);
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				con?.Close();
			}
		}

		public async Task<List<FirstLetter>> GetFirstLettersAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [oar].[FirstLetter] order by [FirstLetterId]";

			List<FirstLetter> clientList = new List<FirstLetter>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						FirstLetter client = FirstLetterDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<FirstLetter> GetByIdAsync(string id)
		{
			if (id == null) return null;

			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetByIdAsync(id);
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				con?.Close();
			}
		}

		public async Task<FirstLetter> GetByIdAsync(SqlConnection con, string id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [oar].[FirstLetter] where FirstLetterId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							FirstLetter client = FirstLetterDataReader.BuildFromDataReader(reader);
							return client;
						}
					}
				}

				return null;
			}
			catch
			{
				throw;
			}
			finally
			{
				con?.Close();
			}
		}

		public async Task UpdateFirstLetterAsync(FirstLetter entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateFirstLetterAsync(con, entity);
				}
			}
			catch
			{
				throw;
			}
			finally
			{
				con?.Close();
			}
		}


		public async Task UpdateFirstLetterAsync(SqlConnection con, FirstLetter entity)
		{
			string sql = @" UPDATE [oar].[FirstLetter]
		SET [Url] = @Url
		,[PageCount] = @PageCount
		,[LastUpdated] = getdate()
		 WHERE FirstLetterId = @FirstLetterId
		";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("FirstLetterId", entity.FirstLetterId);
					command.Parameters.AddWithValue("Url", entity.UrlCalculated);
					if (entity.PageCount.HasValue)
						command.Parameters.AddWithValue("PageCount", entity.PageCount);
					else
						command.Parameters.AddWithValue("PageCount", DBNull.Value);
					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update first letter {entity.FirstLetterId}");
			}
		}



	}  // end of class
}  // end of namespace
