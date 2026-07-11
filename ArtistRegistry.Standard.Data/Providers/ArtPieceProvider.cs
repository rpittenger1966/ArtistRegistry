using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class ArtPieceProvider : ProviderBase
	{
		public ArtPieceProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertArtPieceAsync(ArtPiece entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertArtPieceAsync(con, entity);
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

		public async Task<int> InsertArtPieceAsync(SqlConnection con, ArtPiece entity)
		{
			string sql = @"INSERT INTO [dbo].[ArtPiece]
           ([ContactId]
           ,[Title]
           ,[Medium]
           ,[Size]
           ,[Category]
           ,[Price]
           ,[CreateDate])
     VALUES
           (@ContactId
           ,@Title
           ,@Medium
           ,@Size
           ,@Category
           ,@Price
           ,@CreateDate);";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("ContactId", entity.ContactId);

				object o = await command.ExecuteScalarAsync();

				int retval = Convert.ToInt32(o);
				return retval;
			}
		}

		public async Task<List<ArtPiece>> GetArtPiecesAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetArtPiecesAsync(con);
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

		public async Task<List<ArtPiece>> GetArtPiecesAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[ArtPiece] order by [ArtPieceId]";

			List<ArtPiece> clientList = new List<ArtPiece>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						ArtPiece client = ArtPieceDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<ArtPiece> GetByIdAsync(int? id)
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

		public async Task<ArtPiece> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[ArtPiece] where ArtPieceId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							ArtPiece client = ArtPieceDataReader.BuildFromDataReader(reader);
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

		public async Task UpdateArtPieceAsync(ArtPiece entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateArtPieceAsync(con, entity);
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


		public async Task UpdateArtPieceAsync(SqlConnection con, ArtPiece entity)
		{
			string sql = @"UPDATE [dbo].[ArtPiece]
   SET [ContactId] = @ContactId
      ,[Title] = @Title
      ,[Medium] = @Medium
      ,[Size] = @Size
      ,[Category] = @Category
      ,[Price] = @Price
      ,[ModifyDate] = getdate()
	 WHERE ArtPieceId = @ArtPieceId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("ArtPieceId", entity.ArtPieceId);

					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update client {entity.ArtPieceId}");
			}
		}



	}  // end of class
}  // end of namespace
