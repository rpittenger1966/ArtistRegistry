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

		public async Task InsertGalleryExhibitionArtistAsync(GalleryExhibitionArtist entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await InsertGalleryExhibitionArtistAsync(con, entity);
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

		public async Task InsertGalleryExhibitionArtistAsync(SqlConnection con, GalleryExhibitionArtist entity)
		{
			string sql = @"INSERT INTO [dbo].[GalleryExhibitionArtist]
           ([GalleryExhibitionId]
           ,[ContactId])
     VALUES
           (@GalleryExhibitionId
           ,@ContactId);";


			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("GalleryExhibitionId", entity.GalleryExhibitionId);
				command.Parameters.AddWithValue("ContactId", entity.ContactId);
				await command.ExecuteNonQueryAsync();
			}
		}

		public async Task<List<GalleryExhibitionArtist>> GetGalleryExhibitionArtistsAsync(int galleryExihibitionId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetGalleryExhibitionArtistsAsync(con, galleryExihibitionId);
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

		public async Task<List<GalleryExhibitionArtist>> GetGalleryExhibitionArtistsAsync(SqlConnection con, int galleryExihibitionId)
		{
			string sql = $"SELECT *  FROM [dbo].[GalleryExhibitionArtist] where GalleryExhibitionId = {galleryExihibitionId} order by ContactId desc";

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


		public async Task<GalleryExhibitionArtist> GetByIdAsync(int galleryExhibitionId, int contactId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetByIdAsync(con, galleryExhibitionId, contactId);
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

		public async Task<GalleryExhibitionArtist> GetByIdAsync(SqlConnection con, int galleryExhibitionId, int contactId)
		{
			string sql = $"SELECT * FROM [dbo].[GalleryExhibitionArtist] where GalleryExhibitionId = {galleryExhibitionId} and [ContactId]={contactId};";

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

		//		public async Task UpdateGalleryExhibitionArtistAsync(GalleryExhibitionArtist entity)
		//		{
		//			SqlConnection con = null;

		//			try
		//			{
		//				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//				{
		//					await UpdateGalleryExhibitionArtistAsync(con, entity);
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


		//		public async Task UpdateGalleryExhibitionArtistAsync(SqlConnection con, GalleryExhibitionArtist entity)
		//		{
		//			string sql = @"UPDATE [dbo].[GalleryExhibitionArtist]
		//   SET [Name] = @Name
		//      ,[GalleryExhibitionArtistTypeId] = @GalleryExhibitionArtistTypeId
		//      ,[ParentId] = @ParentId
		//      ,[StatusId] = @StatusId
		//      ,[LegalName] = @LegalName

		//      ,[ExternalIdentifier] = @ExternalIdentifier
		//      ,[ModifyBy] = @ModifyBy
		//      ,[ModifyDate] = GETUTCDATE()
		//      ,[TimeZone] = @TimeZone
		//      ,[ComDataConnectionString] = @ComDataConnectionString
		//      ,[ComDataShardCount] = @ComDataShardCount
		// WHERE GalleryExhibitionArtistId = @GalleryExhibitionArtistId
		//";

		//			try
		//			{
		//				using (SqlCommand command = new SqlCommand(sql, con))
		//				{
		//					command.Parameters.AddWithValue("GalleryExhibitionArtistId", entity.GalleryExhibitionId);

		//					await command.ExecuteNonQueryAsync();
		//				}
		//			}
		//			catch (Exception ex)
		//			{
		//				throw new Exception($"Failed to update client {entity.GalleryExhibitionId}");
		//			}
		//		}

		public async Task DeleteByIdAsync(int galleryExhibitionId, int contactId)
		{
			string sql = $"DELETE FROM [dbo].[GalleryExhibitionArtist] where GalleryExhibitionId = {galleryExhibitionId} and [ContactId]={contactId};";

			await base.ExecuteQueryAsync(sql, "faile to delete");
		}


	}  // end of class
}  // end of namespace
