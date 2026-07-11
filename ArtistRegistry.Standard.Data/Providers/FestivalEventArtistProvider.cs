using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class FestivalEventArtistProvider : ProviderBase
	{
		public FestivalEventArtistProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertFestivalEventArtistAsync(FestivalEventArtist entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertFestivalEventArtistAsync(con, entity);
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

		public async Task<int> InsertFestivalEventArtistAsync(SqlConnection con, FestivalEventArtist entity)
		{
			string sql = @"INSERT INTO [dbo].[FestivalEventArtist]
           ([Name]
           ,[FestivalEventArtistTypeId]
           ,[ParentId]
           ,[StatusId]
           ,[LegalName]
           ,[ExternalIdentifier]
           ,[TimeZone])
     VALUES
           (@Name
           ,@FestivalEventArtistTypeId
           ,@ParentId
           ,@StatusId
           ,@LegalName
           ,@ExternalIdentifier
           ,@TimeZone);";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("FullName", entity.FestivalEventId);

				object o = await command.ExecuteScalarAsync();

				int retval = Convert.ToInt32(o);
				return retval;
			}
		}

		public async Task<List<FestivalEventArtist>> GetFestivalEventArtistsAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetFestivalEventArtistsAsync(con);
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

		public async Task<List<FestivalEventArtist>> GetFestivalEventArtistsAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[FestivalEventArtist] order by [Name]";

			List<FestivalEventArtist> clientList = new List<FestivalEventArtist>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						FestivalEventArtist client = FestivalEventArtistDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<FestivalEventArtist> GetByIdAsync(int? id)
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

		public async Task<FestivalEventArtist> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[FestivalEventArtist] where FestivalEventArtistId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							FestivalEventArtist client = FestivalEventArtistDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateFestivalEventArtistAsync(FestivalEventArtist entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateFestivalEventArtistAsync(con, entity);
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


		public async Task UpdateFestivalEventArtistAsync(SqlConnection con, FestivalEventArtist entity)
		{
			string sql = @"UPDATE [dbo].[FestivalEventArtist]
   SET [Name] = @Name
      ,[FestivalEventArtistTypeId] = @FestivalEventArtistTypeId
      ,[ParentId] = @ParentId
      ,[StatusId] = @StatusId
      ,[LegalName] = @LegalName

      ,[ExternalIdentifier] = @ExternalIdentifier
      ,[ModifyBy] = @ModifyBy
      ,[ModifyDate] = GETUTCDATE()
      ,[TimeZone] = @TimeZone
      ,[ComDataConnectionString] = @ComDataConnectionString
      ,[ComDataShardCount] = @ComDataShardCount
 WHERE FestivalEventArtistId = @FestivalEventArtistId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("FestivalEventArtistId", entity.FestivalEventId);

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update client {entity.FestivalEventId}");
			}
		}



	}  // end of class
}  // end of namespace
