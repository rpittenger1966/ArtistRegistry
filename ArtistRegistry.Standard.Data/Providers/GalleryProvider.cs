using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class GalleryProvider : ProviderBase
	{
		public GalleryProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertGalleryAsync(Gallery entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertGalleryAsync(con, entity);
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

		public async Task<int> InsertGalleryAsync(SqlConnection con, Gallery entity)
		{
			string sql = @"INSERT INTO [dbo].[Gallery]
           ([Name]
           ,[GalleryTypeId]
           ,[ParentId]
           ,[StatusId]
           ,[LegalName]
           ,[ExternalIdentifier]
           ,[TimeZone])
     VALUES
           (@Name
           ,@GalleryTypeId
           ,@ParentId
           ,@StatusId
           ,@LegalName
           ,@ExternalIdentifier
           ,@TimeZone);";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("FullName", entity.Name);

				object o = await command.ExecuteScalarAsync();

				int retval = Convert.ToInt32(o);
				return retval;
			}
		}

		public async Task<List<Gallery>> GetGallerysAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetGallerysAsync(con);
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

		public async Task<List<Gallery>> GetGallerysAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[Gallery] order by [Name]";

			List<Gallery> clientList = new List<Gallery>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						Gallery client = GalleryDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<Gallery> GetByIdAsync(int? id)
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

		public async Task<Gallery> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[Gallery] where GalleryId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							Gallery client = GalleryDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateGalleryAsync(Gallery entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateGalleryAsync(con, entity);
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


		public async Task UpdateGalleryAsync(SqlConnection con, Gallery entity)
		{
			string sql = @"UPDATE [dbo].[Gallery]
   SET [Name] = @Name
      ,[GalleryTypeId] = @GalleryTypeId
      ,[ParentId] = @ParentId
      ,[StatusId] = @StatusId
      ,[LegalName] = @LegalName

      ,[ExternalIdentifier] = @ExternalIdentifier
      ,[ModifyBy] = @ModifyBy
      ,[ModifyDate] = GETUTCDATE()
      ,[TimeZone] = @TimeZone
      ,[ComDataConnectionString] = @ComDataConnectionString
      ,[ComDataShardCount] = @ComDataShardCount
 WHERE GalleryId = @GalleryId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("GalleryId", entity.GalleryId);

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update client {entity.GalleryId}");
			}
		}



	}  // end of class
}  // end of namespace
