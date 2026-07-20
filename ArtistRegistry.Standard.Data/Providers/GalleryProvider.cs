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
           ,[Address1]
           ,[Address2]
           ,[City]
           ,[State]
           
		   ,[PostalCode]
           ,[Country]
           ,[Phone]
           ,[EmailAddress]
           ,[WebSite]
           
		   ,[Facebook]
           ,[Instagram]
           ,[DeviantArt]
           ,[YouTube]
           ,[CreateDate])
     VALUES
           (@Name
           ,@Address1
           ,@Address2
           ,@City
           ,@State
           ,@PostalCode
           ,@Country
           ,@Phone
           ,@EmailAddress
           ,@WebSite
           ,@Facebook
           ,@Instagram
           ,@DeviantArt
           ,@YouTube
           ,getdate());";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("Name", entity.Name);
				command.Parameters.AddWithValue("Address1", entity.Address1);
				command.Parameters.AddWithValue("Address2", entity.Address2);
				command.Parameters.AddWithValue("City", entity.City);
				command.Parameters.AddWithValue("State", entity.State);

				command.Parameters.AddWithValue("PostalCode", entity.PostalCode);
				command.Parameters.AddWithValue("Country", entity.Country);
				command.Parameters.AddWithValue("Phone", entity.Phone);
				command.Parameters.AddWithValue("EmailAddress", entity.EmailAddress);
				command.Parameters.AddWithValue("WebSite", entity.WebSite);

				command.Parameters.AddWithValue("Facebook", entity.Facebook);
				command.Parameters.AddWithValue("Instagram", entity.Instagram);
				command.Parameters.AddWithValue("DeviantArt", entity.DeviantArt);
				command.Parameters.AddWithValue("YouTube", entity.YouTube);

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
      ,[Address1] = @Address1
      ,[Address2] = @Address2
      ,[City] = @City
      ,[State] = @State

      ,[PostalCode] = @PostalCode
      ,[Country] = @Country
      ,[Phone] = @Phone
      ,[EmailAddress] = @EmailAddress
      ,[WebSite] = @WebSite

      ,[Facebook] = @Facebook
      ,[Instagram] = @Instagram
      ,[DeviantArt] = @DeviantArt
      ,[YouTube] = @YouTube

      ,[ModifyDate] = getdate()
 WHERE GalleryId = @GalleryId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("GalleryId", entity.GalleryId);

					command.Parameters.AddWithValue("Name", entity.Name);
					command.Parameters.AddWithValue("Address1", entity.Address1);
					command.Parameters.AddWithValue("Address2", entity.Address2);
					command.Parameters.AddWithValue("City", entity.City);
					command.Parameters.AddWithValue("State", entity.State);

					command.Parameters.AddWithValue("PostalCode", entity.PostalCode);
					command.Parameters.AddWithValue("Country", entity.Country);
					command.Parameters.AddWithValue("Phone", entity.Phone);
					command.Parameters.AddWithValue("EmailAddress", entity.EmailAddress);
					command.Parameters.AddWithValue("WebSite", entity.WebSite);

					command.Parameters.AddWithValue("Facebook", entity.Facebook);
					command.Parameters.AddWithValue("Instagram", entity.Instagram);
					command.Parameters.AddWithValue("DeviantArt", entity.DeviantArt);
					command.Parameters.AddWithValue("YouTube", entity.YouTube);

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update gallery {entity.GalleryId}");
			}
		}



	}  // end of class
}  // end of namespace
