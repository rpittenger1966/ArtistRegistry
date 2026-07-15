using ArtistRegistry.Standard.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistDetailsRegistry.Standard.Data.Providers
{
	public class ArtistDetailsProvider : ProviderBase
	{
		public ArtistDetailsProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task InsertArtistDetailsAsync(ArtistDetails entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await InsertArtistDetailsAsync(con, entity);
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

		public async Task InsertArtistDetailsAsync(SqlConnection con, ArtistDetails entity)
		{
			string sql = @"INSERT INTO [oar].[ArtistDetails]
           ([ContactId])
     VALUES
           (@ContactId, int,>);";


			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("ContactId", entity.FirstLetterId);

				await command.ExecuteNonQueryAsync();
			}
		}

		public async Task<List<ArtistDetails>> GetArtistDetailssAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetArtistDetailssAsync(con);
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

		public async Task<List<ArtistDetails>> GetArtistDetailssAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [oar].[ArtistDetails] order by [ContactId]";

			List<ArtistDetails> clientList = new List<ArtistDetails>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						ArtistDetails client = ArtistDetailsDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<ArtistDetails> GetByIdAsync(int? id)
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

		public async Task<ArtistDetails> GetByIdAsync(SqlConnection con, string firstLetterId, string slug)
		{

			string sql = $"SELECT * FROM [oar].[ArtistDetails] where FirstLetterId = {firstLetterId} and Slug='{slug}';";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							ArtistDetails client = ArtistDetailsDataReader.BuildFromDataReader(reader);
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

		//		public async Task UpdateArtistDetailsAsync(ArtistDetails entity)
		//		{
		//			SqlConnection con = null;

		//			try
		//			{
		//				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//				{
		//					await UpdateArtistDetailsAsync(con, entity);
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


		//		public async Task UpdateArtistDetailsAsync(SqlConnection con, ArtistDetails entity)
		//		{
		//			string sql = @"UPDATE [oar].[ArtistDetails]
		//   SET [Name] = @Name
		//      ,[ArtistDetailsTypeId] = @ArtistDetailsTypeId
		//      ,[ParentId] = @ParentId
		//      ,[StatusId] = @StatusId
		//      ,[LegalName] = @LegalName

		//      ,[ExternalIdentifier] = @ExternalIdentifier
		//      ,[ModifyBy] = @ModifyBy
		//      ,[ModifyDate] = GETUTCDATE()
		//      ,[TimeZone] = @TimeZone
		//      ,[ComDataConnectionString] = @ComDataConnectionString
		//      ,[ComDataShardCount] = @ComDataShardCount
		// WHERE ArtistDetailsId = @ArtistDetailsId
		//";

		//			try
		//			{
		//				using (SqlCommand command = new SqlCommand(sql, con))
		//				{
		//					command.Parameters.AddWithValue("ArtistDetailsId", entity.ArtistDetailsId);

		//					await command.ExecuteNonQueryAsync();
		//				}
		//			}
		//			catch (Exception ex)
		//			{
		//				throw new Exception($"Failed to update client {entity.ArtistDetailsId}");
		//			}
		//		}



	}  // end of class
}  // end of namespace
