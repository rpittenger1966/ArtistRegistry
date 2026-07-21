using ArtistRegistry.Standard.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace JurorRegistry.Standard.Data.Providers
{
	public class GalleryExhibitionJurorProvider : ProviderBase
	{
		public GalleryExhibitionJurorProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task InsertGalleryExhibitionJurorAsync(int contactId, int galleryExhibitionId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await InsertGalleryExhibitionJurorAsync(con, contactId, galleryExhibitionId);
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

		public async Task InsertGalleryExhibitionJurorAsync(SqlConnection con, int contactId, int galleryExhibitionId)
		{
			string sql = @"INSERT INTO [dbo].[GalleryExhibitionJuror]
           ([GalleryExhibitionId]
           ,[ContactId])
     VALUES
           (@GalleryExhibitionId
           ,@ContactId);";


			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("GalleryExhibitionId", galleryExhibitionId);
				command.Parameters.AddWithValue("ContactId", contactId);
				await command.ExecuteNonQueryAsync();
			}
		}

		public async Task<List<int>> GetGalleryExhibitionJurorsAsync(int galleryExihibitionId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetGalleryExhibitionJurorsAsync(con, galleryExihibitionId);
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

		public async Task<List<int>> GetGalleryExhibitionJurorsAsync(SqlConnection con, int galleryExihibitionId)
		{
			string sql = $"SELECT [ContactId]  FROM [dbo].[GalleryExhibitionJuror] where GalleryExhibitionId = {galleryExihibitionId} order by ContactId desc";

			List<int> contactList = new List<int>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						int contactId = AdoReader.ReadInteger(reader, 0);
						contactList.Add(contactId);
					}
				}
			}

			return contactList;
		}


		public async Task<int?> GetByIdAsync(int galleryExhibitionId, int contactId)
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

		public async Task<int?> GetByIdAsync(SqlConnection con, int galleryExhibitionId, int contactId)
		{
			string sql = $"SELECT [ContactId] FROM [dbo].[GalleryExhibitionJuror] where GalleryExhibitionId = {galleryExhibitionId} and [ContactId]={contactId};";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						if (reader.Read())
						{
							int exists = AdoReader.ReadInteger(reader, 0);
							return exists;
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

		//		public async Task UpdateGalleryExhibitionJurorAsync(GalleryExhibitionJuror entity)
		//		{
		//			SqlConnection con = null;

		//			try
		//			{
		//				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//				{
		//					await UpdateGalleryExhibitionJurorAsync(con, entity);
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


		//		public async Task UpdateGalleryExhibitionJurorAsync(SqlConnection con, GalleryExhibitionJuror entity)
		//		{
		//			string sql = @"UPDATE [dbo].[GalleryExhibitionJuror]
		//   SET [Name] = @Name
		//      ,[GalleryExhibitionJurorTypeId] = @GalleryExhibitionJurorTypeId
		//      ,[ParentId] = @ParentId
		//      ,[StatusId] = @StatusId
		//      ,[LegalName] = @LegalName

		//      ,[ExternalIdentifier] = @ExternalIdentifier
		//      ,[ModifyBy] = @ModifyBy
		//      ,[ModifyDate] = GETUTCDATE()
		//      ,[TimeZone] = @TimeZone
		//      ,[ComDataConnectionString] = @ComDataConnectionString
		//      ,[ComDataShardCount] = @ComDataShardCount
		// WHERE GalleryExhibitionJurorId = @GalleryExhibitionJurorId
		//";

		//			try
		//			{
		//				using (SqlCommand command = new SqlCommand(sql, con))
		//				{
		//					command.Parameters.AddWithValue("GalleryExhibitionJurorId", entity.GalleryExhibitionId);

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
			string sql = $"DELETE FROM [dbo].[GalleryExhibitionJuror] where GalleryExhibitionId = {galleryExhibitionId} and [ContactId]={contactId};";

			await base.ExecuteQueryAsync(sql, "faile to delete");
		}


	}  // end of class
}  // end of namespace
