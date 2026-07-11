using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class GalleryExhibitionArtistProvider : ProviderBase
	{
		public GalleryExhibitionArtistProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertGalleryExhibitionArtistAsync(GalleryExhibitionArtist entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertGalleryExhibitionArtistAsync(con, entity);
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

		public async Task<int> InsertGalleryExhibitionArtistAsync(SqlConnection con, GalleryExhibitionArtist entity)
		{
			string sql = @"INSERT INTO [dbo].[GalleryExhibitionArtist]
           ([Name]
           ,[GalleryExhibitionArtistTypeId]
           ,[ParentId]
           ,[StatusId]
           ,[LegalName]
           ,[ExternalIdentifier]
           ,[TimeZone])
     VALUES
           (@Name
           ,@GalleryExhibitionArtistTypeId
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

		public async Task<List<GalleryExhibitionArtist>> GetGalleryExhibitionArtistsAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetGalleryExhibitionArtistsAsync(con);
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

		public async Task<List<GalleryExhibitionArtist>> GetGalleryExhibitionArtistsAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[GalleryExhibitionArtist] order by [Name]";

			List<GalleryExhibitionArtist> clientList = new List<GalleryExhibitionArtist>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						GalleryExhibitionArtist client = GalleryExhibitionArtistDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<GalleryExhibitionArtist> GetByIdAsync(int? id)
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

		public async Task<GalleryExhibitionArtist> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[GalleryExhibitionArtist] where GalleryExhibitionArtistId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							GalleryExhibitionArtist client = GalleryExhibitionArtistDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateGalleryExhibitionArtistAsync(GalleryExhibitionArtist entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateGalleryExhibitionArtistAsync(con, entity);
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


		public async Task UpdateGalleryExhibitionArtistAsync(SqlConnection con, GalleryExhibitionArtist entity)
		{
			string sql = @"UPDATE [dbo].[GalleryExhibitionArtist]
   SET [Name] = @Name
      ,[GalleryExhibitionArtistTypeId] = @GalleryExhibitionArtistTypeId
      ,[ParentId] = @ParentId
      ,[StatusId] = @StatusId
      ,[LegalName] = @LegalName

      ,[ExternalIdentifier] = @ExternalIdentifier
      ,[ModifyBy] = @ModifyBy
      ,[ModifyDate] = GETUTCDATE()
      ,[TimeZone] = @TimeZone
      ,[ComDataConnectionString] = @ComDataConnectionString
      ,[ComDataShardCount] = @ComDataShardCount
 WHERE GalleryExhibitionArtistId = @GalleryExhibitionArtistId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("GalleryExhibitionArtistId", entity.GalleryExhibitionId);

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
