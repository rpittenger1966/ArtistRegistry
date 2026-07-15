using ArtistRegistry.Standard.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistEntryRegistry.Standard.Data.Providers
{
	public class ArtistEntryProvider : ProviderBase
	{
		public ArtistEntryProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task UpsertArtistEntryAsync(ArtistEntry entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					var existing = await GetByIdAsync(con, entity.FirstLetterId, entity.Slug);
					if (existing != null)
					{
						await UpdateArtistEntryAsync(con, entity);
					}
					else
					{
						await InsertArtistEntryAsync(con, entity);
					}
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

		public async Task InsertArtistEntryAsync(ArtistEntry entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await InsertArtistEntryAsync(con, entity);
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

		public async Task InsertArtistEntryAsync(SqlConnection con, ArtistEntry entity)
		{
			string sql = @"INSERT INTO [oar].[ArtistEntry]
           ([FirstLetterId]
           ,[Slug]
           ,[Url]
           ,[ContentFileName]
           ,[ArtistId]
           ,[LastUpdated])
     VALUES
           (@FirstLetterId
           ,@Slug
           ,@Url
           ,@ContentFileName
           ,@ArtistId
           ,getdate());";


			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("FirstLetterId", entity.FirstLetterId);
				command.Parameters.AddWithValue("Slug", entity.Slug);

				command.Parameters.AddWithValue("Url", entity.Url);
				command.Parameters.AddWithValue("ContentFileName", entity.ContentFileName);
				if (entity.ArtistId.HasValue)
					command.Parameters.AddWithValue("ArtistId", entity.ArtistId);
				else
					command.Parameters.AddWithValue("ArtistId", DBNull.Value);

				await command.ExecuteNonQueryAsync();
			}
		}

		public async Task<List<ArtistEntry>> GetArtistEntrysAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetArtistEntrysAsync(con);
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

		public async Task<List<ArtistEntry>> GetArtistEntrysAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [oar].[ArtistEntry] order by [FirstLetterId], [Slug]";

			List<ArtistEntry> clientList = new List<ArtistEntry>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						ArtistEntry client = ArtistEntryDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<ArtistEntry> GetByIdAsync(string firstLetterId, string slug)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetByIdAsync(con, firstLetterId, slug);
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

		public async Task<ArtistEntry> GetByIdAsync(SqlConnection con, string firstLetterId, string slug)
		{
			
			string sql = $"SELECT * FROM [oar].[ArtistEntry] where FirstLetterId = '{firstLetterId}' and [Slug]='{slug}';";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							ArtistEntry entity = ArtistEntryDataReader.BuildFromDataReader(reader);
							return entity;
						}
					}
				}

				return null;
			}
			catch
			{
				throw;
			}
		}

		public async Task UpdateArtistEntryAsync(ArtistEntry entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateArtistEntryAsync(con, entity);
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


		public async Task UpdateArtistEntryAsync(SqlConnection con, ArtistEntry entity)
		{
			string sql = @"UPDATE [oar].[ArtistEntry]
   SET [Url] = @Url
      ,[ContentFileName] = @ContentFileName
      ,[ArtistId] = @ArtistId
      ,[LastUpdated] = getdate()
 WHERE FirstLetterId = @FirstLetterId and [Slug]=@Slug
		";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("Url", entity.Url);
					command.Parameters.AddWithValue("ContentFileName", entity.ContentFileName);
					if (entity.ArtistId.HasValue)
						command.Parameters.AddWithValue("ArtistId", entity.ArtistId);
					else
						command.Parameters.AddWithValue("ArtistId", DBNull.Value);

					command.Parameters.AddWithValue("FirstLetterId", entity.FirstLetterId);
					command.Parameters.AddWithValue("Slug", entity.Slug);

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update aartist entry {entity.Slug}");
			}
		}



	}  // end of class
}  // end of namespace
