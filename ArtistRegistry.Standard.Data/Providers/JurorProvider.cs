using ArtistRegistry.Standard.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JurorRegistry.Standard.Data.Providers
{
	public class JurorProvider : ProviderBase
	{
		public JurorProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task UpsertJuror(int contactId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					int? existing = await GetByIdAsync(con, contactId);
					if (existing == null)
					{
						await InsertJurorAsync(con, contactId);
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


		public async Task InsertJurorAsync(int contactId)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await InsertJurorAsync(con, contactId);
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

		public async Task InsertJurorAsync(SqlConnection con, int contactId)
		{
			string sql = @"INSERT INTO [dbo].[Juror]
           ([ContactId])
     VALUES
           (@ContactId);";


			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("ContactId", contactId);

				await command.ExecuteScalarAsync();
			}
		}

		//public async Task<List<int>> GetJurorsAsync()
		//{
		//	SqlConnection con = null;

		//	try
		//	{
		//		using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//		{
		//			return await GetJurorsAsync(con);
		//		}
		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//	finally
		//	{
		//		con?.Close();
		//	}
		//}

		//public async Task<List<Juror>> GetJurorsAsync(SqlConnection con)
		//{
		//	string sql = "SELECT * FROM [dbo].[Juror] order by [ContactId]";

		//	List<Juror> clientList = new List<Juror>();

		//	using (SqlCommand command = new SqlCommand(sql, con))
		//	{
		//		using (SqlDataReader reader = await command.ExecuteReaderAsync())
		//		{
		//			while (reader.Read())
		//			{
		//				Juror client = JurorDataReader.BuildFromDataReader(reader);
		//				if (client != null)
		//				{
		//					clientList.Add(client);
		//				}
		//			}
		//		}
		//	}

		//	return clientList;
		//}


		public async Task<int?> GetByIdAsync(int? id)
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

		public async Task<int?> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT top(1) ContactId FROM [dbo].[Juror] where ContactId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						if (reader.Read())
						{
							int existing = AdoReader.ReadInteger(reader, 0);
							return existing;
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

		//		public async Task UpdateJurorAsync(Juror entity)
		//		{
		//			SqlConnection con = null;

		//			try
		//			{
		//				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
		//				{
		//					await UpdateJurorAsync(con, entity);
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


		//		public async Task UpdateJurorAsync(SqlConnection con, Juror entity)
		//		{
		//			string sql = @"UPDATE [dbo].[Juror]
		//   SET [Name] = @Name
		//      ,[JurorTypeId] = @JurorTypeId
		//      ,[ParentId] = @ParentId
		//      ,[StatusId] = @StatusId
		//      ,[LegalName] = @LegalName

		//      ,[ExternalIdentifier] = @ExternalIdentifier
		//      ,[ModifyBy] = @ModifyBy
		//      ,[ModifyDate] = GETUTCDATE()
		//      ,[TimeZone] = @TimeZone
		//      ,[ComDataConnectionString] = @ComDataConnectionString
		//      ,[ComDataShardCount] = @ComDataShardCount
		// WHERE JurorId = @JurorId
		//";

		//			try
		//			{
		//				using (SqlCommand command = new SqlCommand(sql, con))
		//				{
		//					command.Parameters.AddWithValue("JurorId", entity.JurorId);

		//					await command.ExecuteNonQueryAsync();
		//				}
		//			}
		//			catch (Exception ex)
		//			{
		//				throw new Exception($"Failed to update client {entity.JurorId}");
		//			}
		//		}



	}  // end of class
}  // end of namespace
