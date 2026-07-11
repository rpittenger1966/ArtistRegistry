using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class FestivalProvider : ProviderBase
	{
		public FestivalProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertFestivalAsync(Festival entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertFestivalAsync(con, entity);
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

		public async Task<int> InsertFestivalAsync(SqlConnection con, Festival entity)
		{
			string sql = @"INSERT INTO [dbo].[Festival]
           ([Name]
           ,[FestivalTypeId]
           ,[ParentId]
           ,[StatusId]
           ,[LegalName]
           ,[ExternalIdentifier]
           ,[TimeZone])
     VALUES
           (@Name
           ,@FestivalTypeId
           ,@ParentId
           ,@StatusId
           ,@LegalName
           ,@ExternalIdentifier
           ,@TimeZone);";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("Name", entity.Name);

				object o = await command.ExecuteScalarAsync();

				int retval = Convert.ToInt32(o);
				return retval;
			}
		}

		public async Task<List<Festival>> GetFestivalsAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetFestivalsAsync(con);
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

		public async Task<List<Festival>> GetFestivalsAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[Festival] order by [Name]";

			List<Festival> clientList = new List<Festival>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						Festival client = FestivalDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<Festival> GetByIdAsync(int? id)
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

		public async Task<Festival> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[Festival] where FestivalId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							Festival client = FestivalDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateFestivalAsync(Festival entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateFestivalAsync(con, entity);
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


		public async Task UpdateFestivalAsync(SqlConnection con, Festival entity)
		{
			string sql = @"UPDATE [dbo].[Festival]
   SET [Name] = @Name
      ,[FestivalTypeId] = @FestivalTypeId
      ,[ParentId] = @ParentId
      ,[StatusId] = @StatusId
      ,[LegalName] = @LegalName

      ,[ExternalIdentifier] = @ExternalIdentifier
      ,[ModifyBy] = @ModifyBy
      ,[ModifyDate] = GETUTCDATE()
      ,[TimeZone] = @TimeZone
      ,[ComDataConnectionString] = @ComDataConnectionString
      ,[ComDataShardCount] = @ComDataShardCount
 WHERE FestivalId = @FestivalId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("FestivalId", entity.FestivalId);

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update client {entity.FestivalId}");
			}
		}



	}  // end of class
}  // end of namespace
