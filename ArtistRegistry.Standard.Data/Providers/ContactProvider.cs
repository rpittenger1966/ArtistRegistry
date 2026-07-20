using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArtistRegistry.Standard.Data.Providers
{
	public class ContactProvider : ProviderBase
	{
		public ContactProvider(string connectionString, Guid userId) : base(connectionString, userId)
		{
		}

		public async Task<int> InsertContactAsync(Contact entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await InsertContactAsync(con, entity);
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

		public async Task<int> InsertContactAsync(SqlConnection con, Contact entity)
		{
			string sql = @"INSERT INTO [dbo].[Contact]
           ([FirstName]
           ,[LastName]
           ,[Gender]
           ,[BirthYear]
           ,[Generation]
           
		   ,[Address1]
           ,[Address2]
           ,[City]
           ,[State]
           ,[PostalCode]
           
		   ,[Country]
           ,[Phone]
           ,[Email]
           ,[WebSite]
           ,[Facebook]
           
		   ,[Instagram]
           ,[DeviantArt]
           ,[YouTube]
           ,[OhioArtistRegistry]
           ,[InitialSource]
           
		   ,[StatusId]
           ,[CreateDate])
     VALUES
           (@FirstName
           ,@LastName
           ,@Gender
           ,@BirthYear
           ,@Generation
           
		   ,@Address1
           ,@Address2
           ,@City
           ,@State
           ,@PostalCode
           
		   ,@Country
           ,@Phone
           ,@Email
           ,@WebSite
           ,@Facebook
           
		   ,@Instagram
           ,@DeviantArt
           ,@YouTube
           ,@OhioArtistRegistry
           ,@InitialSource
           
		   ,@StatusId
           ,getdate());
";

			sql = sql + "SELECT SCOPE_IDENTITY();";

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				command.Parameters.AddWithValue("FirstName", entity.FirstName);
				command.Parameters.AddWithValue("LastName", entity.LastName);
				command.Parameters.AddWithValue("Gender", entity.Gender);
				if (entity.BirthYear.HasValue)
					command.Parameters.AddWithValue("BirthYear", entity.BirthYear);
				else
					command.Parameters.AddWithValue("BirthYear", DBNull.Value);
				command.Parameters.AddWithValue("Generation", entity.Generation);

				command.Parameters.AddWithValue("Address1", entity.Address1);
				command.Parameters.AddWithValue("Address2", entity.Address2);
				command.Parameters.AddWithValue("City", entity.City);
				command.Parameters.AddWithValue("State", entity.State);
				command.Parameters.AddWithValue("PostalCode", entity.PostalCode);

				command.Parameters.AddWithValue("Country", entity.Country);
				command.Parameters.AddWithValue("Phone", entity.Phone);
				command.Parameters.AddWithValue("Email", entity.Email);
				command.Parameters.AddWithValue("WebSite", entity.WebSite);
				command.Parameters.AddWithValue("Facebook", entity.Facebook);

				command.Parameters.AddWithValue("Instagram", entity.Instagram);
				command.Parameters.AddWithValue("DeviantArt", entity.DeviantArt);
				command.Parameters.AddWithValue("YouTube", entity.YouTube);
				command.Parameters.AddWithValue("OhioArtistRegistry", entity.OhioArtistRegistry);
				command.Parameters.AddWithValue("InitialSource", entity.InitialSource);

				command.Parameters.AddWithValue("StatusId", entity.StatusId);

				object o = await command.ExecuteScalarAsync();

				int retval = Convert.ToInt32(o);
				return retval;
			}
		}

		public async Task<List<Contact>> GetContactsAsync()
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetContactsAsync(con);
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

		public async Task<List<Contact>> GetContactsByQueryAsync(string sql)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					return await GetContactsByQueryAsync(con, sql);
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

		public async Task<List<Contact>> GetContactsAsync(SqlConnection con)
		{
			string sql = "SELECT * FROM [dbo].[Contact] order by [ContactId]";

			List<Contact> clientList = new List<Contact>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						Contact client = ContactDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}


		public async Task<List<Contact>> GetContactsByQueryAsync(SqlConnection con, string sql)
		{
			List<Contact> clientList = new List<Contact>();

			using (SqlCommand command = new SqlCommand(sql, con))
			{
				using (SqlDataReader reader = await command.ExecuteReaderAsync())
				{
					while (reader.Read())
					{
						Contact client = ContactDataReader.BuildFromDataReader(reader);
						if (client != null)
						{
							clientList.Add(client);
						}
					}
				}
			}

			return clientList;
		}

		public async Task<Contact> GetByIdAsync(int? id)
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

		public async Task<Contact> GetByIdAsync(SqlConnection con, int? id)
		{
			if (id == null) return null;

			string sql = $"SELECT * FROM [dbo].[Contact] where ContactId = {id}";


			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					using (SqlDataReader reader = await command.ExecuteReaderAsync())
					{
						while (reader.Read())
						{
							Contact client = ContactDataReader.BuildFromDataReader(reader);
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
		}

		public async Task UpdateContactAsync(Contact entity)
		{
			SqlConnection con = null;

			try
			{
				using (con = SqlConnectionFactory.GetSqlConnection(_connectionString))
				{
					await UpdateContactAsync(con, entity);
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


		public async Task UpdateContactAsync(SqlConnection con, Contact entity)
		{
			string sql = @"UPDATE [dbo].[Contact]
   SET [FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[Gender] = @Gender
      ,[BirthYear] = @BirthYear
      ,[Generation] = @Generation
      ,[Address1] = @Address1
      ,[Address2] = @Address2
      ,[City] = @City
      ,[State] = @State
      ,[PostalCode] = @PostalCode
      ,[Country] = @Country
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[WebSite] = @WebSite
      ,[Facebook] = @Facebook
      ,[Instagram] = @Instagram
      ,[DeviantArt] = @DeviantArt
      ,[YouTube] = @YouTube
      ,[OhioArtistRegistry] = @OhioArtistRegistry
      ,[StatusId] = @StatusId
      ,[ModifyDate] = getdate()
 WHERE ContactId = @ContactId
";

			try
			{
				using (SqlCommand command = new SqlCommand(sql, con))
				{
					command.Parameters.AddWithValue("ContactId", entity.ContactId);

					command.Parameters.AddWithValue("FirstName", entity.FirstName);
					command.Parameters.AddWithValue("LastName", entity.LastName);
					command.Parameters.AddWithValue("Gender", entity.Gender);
					if (entity.BirthYear.HasValue)
						command.Parameters.AddWithValue("BirthYear", entity.BirthYear);
					else
						command.Parameters.AddWithValue("BirthYear", DBNull.Value);
					command.Parameters.AddWithValue("Generation", entity.Generation);

					command.Parameters.AddWithValue("Address1", entity.Address1);
					command.Parameters.AddWithValue("Address2", entity.Address2);
					command.Parameters.AddWithValue("City", entity.City);
					command.Parameters.AddWithValue("State", entity.State);
					command.Parameters.AddWithValue("PostalCode", entity.PostalCode);

					command.Parameters.AddWithValue("Country", entity.Country);
					command.Parameters.AddWithValue("Phone", entity.Phone);
					command.Parameters.AddWithValue("Email", entity.Email);
					command.Parameters.AddWithValue("WebSite", entity.WebSite);
					command.Parameters.AddWithValue("Facebook", entity.Facebook);

					command.Parameters.AddWithValue("Instagram", entity.Instagram);
					command.Parameters.AddWithValue("DeviantArt", entity.DeviantArt);
					command.Parameters.AddWithValue("YouTube", entity.YouTube);
					command.Parameters.AddWithValue("OhioArtistRegistry", entity.OhioArtistRegistry);

					command.Parameters.AddWithValue("StatusId", entity.StatusId);


					await command.ExecuteNonQueryAsync();
				}
			}
			catch (Exception ex)
			{
				throw new Exception($"Failed to update client {entity.ContactId}");
			}
		}



	}  // end of class
}  // end of namespace
