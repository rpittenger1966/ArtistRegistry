using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class ArtistProvider : ProviderBase
	{
		public ArtistProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task UpsertArtist(int contactId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					int? existing = await GetByIdAsync(con, contactId);
					if (existing == null)
					{
						await InsertArtistAsync(con, contactId);
					}
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


		public async Task InsertArtistAsync(int contactId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await InsertArtistAsync(con, contactId);
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

		public async Task InsertArtistAsync(SqlConnection con, int contactId)
		{
			string sql = @"INSERT INTO [dbo].[Artist]
           ([ContactId])
     VALUES
           (@ContactId);";


			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("ContactId", contactId);

				await command.ExecuteScalarAsync();
			}
		}

		//public async Task<List<Artist>> GetArtistsAsync()
		//{
		//	SqlConnection con = null;

		//	try
		//	{
		//		using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//		{
		//			return await GetArtistsAsync(con);
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

		//public async Task<List<Artist>> GetArtistsAsync(SqlConnection con)
		//{
		//	string sql = "SELECT * FROM [dbo].[Artist] order by [ContactId]";

		//	List<Artist> clientList = new List<Artist>();

		//	using (SqlCommand command = new SqlCommand(sql, con))
		//	{
		//		using (SqlDataReader reader = await command.ExecuteReaderAsync())
		//		{
		//			while (reader.Read())
		//			{
		//				Artist client = ArtistDataReader.BuildFromDataReader(reader);
		//				if (client != null)
		//				{
		//					clientList.Add(client);
		//				}
		//			}
		//		}
		//	}

		//	return clientList;
		//}


		public async Task<int?> GetByIdAsync(int? id)
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

		public async Task<int?> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT [ContactId] FROM [dbo].[Artist] where ContactId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						if (reader.Read())
						{
							int existing = AdoReader.ReadInteger(reader, 0);
							return existing;
						}
					}
				}

				return null;
			}
			catch
			{
				throw;
			}
		}

//		public async Task UpdateArtistAsync(Artist entity)
//		{
//			SqlConnection con = null;

//			try
//			{
//				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
//				{
//					await UpdateArtistAsync(con, entity);
//				}
//			}
//			catch
//			{
//				throw;
//			}
//			finally
//			{
//				con?.Close();
//			}
//		}


//		public async Task UpdateArtistAsync(SqlConnection con, Artist entity)
//		{
//			string sql = @"UPDATE [dbo].[Artist]
//   SET [Name] = @Name
//      ,[ArtistTypeId] = @ArtistTypeId
//      ,[ParentId] = @ParentId
//      ,[StatusId] = @StatusId
//      ,[LegalName] = @LegalName

//      ,[ExternalIdentifier] = @ExternalIdentifier
//      ,[ModifyBy] = @ModifyBy
//      ,[ModifyDate] = GETUTCDATE()
//      ,[TimeZone] = @TimeZone
//      ,[ComDataConnectionString] = @ComDataConnectionString
//      ,[ComDataShardCount] = @ComDataShardCount
// WHERE ArtistId = @ArtistId
//";

//			try
//			{
//				using (SqlCommand command = new SqlCommand(sql, con))
//				{
//					command.Parameters.AddWithValue("ArtistId", entity.ArtistId);

//					await command.ExecuteNonQueryAsync();
//				}
//			}
//			catch (Exception ex)
//			{
//				throw new Exception($"Failed to update client {entity.ArtistId}");
//			}
//		}



	}  // end of class
}  // end of namespace
