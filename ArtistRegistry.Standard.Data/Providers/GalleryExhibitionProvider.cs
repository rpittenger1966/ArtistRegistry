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
           ([Name]
           ,[GalleryExhibitionTypeId]
           ,[ParentId]
           ,[StatusId]
           ,[LegalName]
           ,[ExternalIdentifier]
           ,[TimeZone])
     VALUES
           (@Name
           ,@GalleryExhibitionTypeId
           ,@ParentId
           ,@StatusId
           ,@LegalName
           ,@ExternalIdentifier
           ,@TimeZone);";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("FullName", entity.GalleryExhibitionId);

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
      ,[GalleryExhibitionTypeId] = @GalleryExhibitionTypeId
      ,[ParentId] = @ParentId
      ,[StatusId] = @StatusId
      ,[LegalName] = @LegalName

      ,[ExternalIdentifier] = @ExternalIdentifier
      ,[ModifyBy] = @ModifyBy
      ,[ModifyDate] = GETUTCDATE()
      ,[TimeZone] = @TimeZone
      ,[ComDataConnectionString] = @ComDataConnectionString
      ,[ComDataShardCount] = @ComDataShardCount
 WHERE GalleryExhibitionId = @GalleryExhibitionId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("GalleryExhibitionId", entity.GalleryExhibitionId);

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
