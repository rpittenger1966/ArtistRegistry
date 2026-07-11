using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class FestivalEventProvider : ProviderBase
	{
		public FestivalEventProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertFestivalEventAsync(FestivalEvent entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertFestivalEventAsync(con, entity);
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

		public async Task<int> InsertFestivalEventAsync(SqlConnection con, FestivalEvent entity)
		{
			string sql = @"INSERT INTO [dbo].[FestivalEvent]
           ([Name]
           ,[FestivalEventTypeId]
           ,[ParentId]
           ,[StatusId]
           ,[LegalName]
           ,[ExternalIdentifier]
           ,[TimeZone])
     VALUES
           (@Name
           ,@FestivalEventTypeId
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

		public async Task<List<FestivalEvent>> GetFestivalEventsAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetFestivalEventsAsync(con);
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

		public async Task<List<FestivalEvent>> GetFestivalEventsAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[FestivalEvent] order by [Name]";

			List<FestivalEvent> clientList = new List<FestivalEvent>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						FestivalEvent client = FestivalEventDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<FestivalEvent> GetByIdAsync(int? id)
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

		public async Task<FestivalEvent> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[FestivalEvent] where FestivalEventId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							FestivalEvent client = FestivalEventDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateFestivalEventAsync(FestivalEvent entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateFestivalEventAsync(con, entity);
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


		public async Task UpdateFestivalEventAsync(SqlConnection con, FestivalEvent entity)
		{
			string sql = @"UPDATE [dbo].[FestivalEvent]
   SET [Name] = @Name
      ,[FestivalEventTypeId] = @FestivalEventTypeId
      ,[ParentId] = @ParentId
      ,[StatusId] = @StatusId
      ,[LegalName] = @LegalName

      ,[ExternalIdentifier] = @ExternalIdentifier
      ,[ModifyBy] = @ModifyBy
      ,[ModifyDate] = GETUTCDATE()
      ,[TimeZone] = @TimeZone
      ,[ComDataConnectionString] = @ComDataConnectionString
      ,[ComDataShardCount] = @ComDataShardCount
 WHERE FestivalEventId = @FestivalEventId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("FestivalEventId", entity.FestivalEventId);

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
