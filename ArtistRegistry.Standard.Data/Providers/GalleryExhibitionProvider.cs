using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class GalleryExhibitionProvider : ProviderBase
	{
		public GalleryExhibitionProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertGalleryExhibitionAsync(GalleryExhibition entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertGalleryExhibitionAsync(con, entity);
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

		public async Task<int> InsertGalleryExhibitionAsync(SqlConnection con, GalleryExhibition entity)
		{
			string sql = @"INSERT INTO [dbo].[GalleryExhibition]
           ([GalleryId]
           ,[Name]
           ,[ArtCallUrl]
           ,[ProspectusUrl]
           ,[Notes]

           ,[StartDate]
           ,[EndDate]
           ,[EntryDeadline]
           ,[EntryStatus]
           ,[CreateDate])
     VALUES
           (@GalleryId
           ,@Name
           ,@ArtCallUrl
           ,@ProspectusUrl
           ,@Notes

           ,@StartDate
           ,@EndDate
           ,@EntryDeadline
           ,@EntryStatus
           ,getdate());";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("GalleryId", entity.GalleryId);
				command.Parameters.AddWithValue("Name", entity.Name);
				command.Parameters.AddWithValue("ArtCallUrl", entity.ArtCallUrl);
				command.Parameters.AddWithValue("ProspectusUrl", entity.ProspectusUrl);
				command.Parameters.AddWithValue("Notes", entity.Notes);

				command.Parameters.AddWithValue("StartDate", entity.StartDate);
				command.Parameters.AddWithValue("EndDate", entity.EndDate);

				if (entity.EntryDeadline.HasValue)
					command.Parameters.AddWithValue("EntryDeadline", entity.EntryDeadline);
				else
					command.Parameters.AddWithValue("EntryDeadline", DBNull.Value);

				if (entity.EntryStatus.HasValue)
					command.Parameters.AddWithValue("EntryStatus", entity.EntryStatus);
				else
					command.Parameters.AddWithValue("EntryStatus", DBNull.Value);
				object o = await command.ExecuteScalarAsync();

				int retval = Convert.ToInt32(o);
				return retval;
			}
		}

		public async Task<List<GalleryExhibition>> GetGalleryExhibitionsAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetGalleryExhibitionsAsync(con);
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

		public async Task<List<GalleryExhibition>> GetGalleryExhibitionsByQueryAsync(string sql)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetGalleryExhibitionsByQueryAsync(con, sql);
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

		public async Task<List<GalleryExhibition>> GetGalleryExhibitionsAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[GalleryExhibition] order by [Name]";

			List<GalleryExhibition> clientList = new List<GalleryExhibition>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						GalleryExhibition client = GalleryExhibitionDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}

		public async Task<List<GalleryExhibition>> GetGalleryExhibitionsByQueryAsync(SqlConnection con, string sql)
		{
			List<GalleryExhibition> clientList = new List<GalleryExhibition>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						GalleryExhibition client = GalleryExhibitionDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}



		public async Task<GalleryExhibition> GetByIdAsync(int? id)
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

		public async Task<GalleryExhibition> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[GalleryExhibition] where GalleryExhibitionId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							GalleryExhibition client = GalleryExhibitionDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateGalleryExhibitionAsync(GalleryExhibition entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateGalleryExhibitionAsync(con, entity);
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


		public async Task UpdateGalleryExhibitionAsync(SqlConnection con, GalleryExhibition entity)
		{
			string sql = @"UPDATE [dbo].[GalleryExhibition]
   SET [Name] = @Name
      ,[ArtCallUrl] = @ArtCallUrl
      ,[ProspectusUrl] = @ProspectusUrl
      ,[Notes] = @Notes
      ,[StartDate] = @StartDate
      ,[EndDate] = @EndDate
      ,[EntryDeadline] = @EntryDeadline
      ,[EntryStatus] = @EntryStatus
      ,[ModifyDate] = getdate()
 WHERE GalleryExhibitionId = @GalleryExhibitionId;";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("GalleryExhibitionId", entity.GalleryExhibitionId);

					command.Parameters.AddWithValue("Name", entity.Name);
					command.Parameters.AddWithValue("ArtCallUrl", entity.ArtCallUrl);
					command.Parameters.AddWithValue("ProspectusUrl", entity.ProspectusUrl);
					command.Parameters.AddWithValue("Notes", entity.Notes);

					command.Parameters.AddWithValue("StartDate", entity.StartDate);
					command.Parameters.AddWithValue("EndDate", entity.EndDate);

					if (entity.EntryDeadline.HasValue)
						command.Parameters.AddWithValue("EntryDeadline", entity.EntryDeadline);
					else
						command.Parameters.AddWithValue("EntryDeadline", DBNull.Value);

					if (entity.EntryStatus.HasValue)
						command.Parameters.AddWithValue("EntryStatus", entity.EntryStatus);
					else
						command.Parameters.AddWithValue("EntryStatus", DBNull.Value);
					object o = await command.ExecuteScalarAsync();

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update client {entity.GalleryExhibitionId}");
			}
		}



	}  // end of class
}  // end of namespace
