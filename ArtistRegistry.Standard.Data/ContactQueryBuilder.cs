using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistRegistry.Standard.Data
{
	public class ContactQueryBuilder
	{
		public ContactQueryBuilder()
		{
		}

		public string BuildQuery(string token)
		{
			StringBuilder sb = new StringBuilder($"SELECT * FROM [dbo].[Contact] where 1=1 ");

			sb.AppendLine(BuildTokenWhereClause(token));

			sb.AppendLine(OrderBy());
			return sb.ToString();

		}

		public string BuildFirstNameLastNameQuery(string firstName, string lastName)
		{
			StringBuilder sb = new StringBuilder($"SELECT * FROM [dbo].[Contact] where 1=1 ");

			if (firstName != string.Empty)
			{
				sb.AppendLine($"and [FirstName] like('{firstName}%')");
			}
			if (lastName != string.Empty)
			{
				sb.AppendLine($"and [LastName] like('{lastName}%')");
			}
			if (firstName == string.Empty && lastName == string.Empty)
			{
				sb.AppendLine($"and 1=0 ");
			}

			sb.AppendLine(OrderBy());
			return sb.ToString();

		}


		private string BuildTokenWhereClause(string token)
		{
			if (String.IsNullOrWhiteSpace(token)) return "";

			return $"and ([FirstName] like('%{token}%') or [LastName] like('%{token}%'))";
		}

		private string OrderBy()
		{
			return $" order by [LastName],[FirstName];";
		}


	}
}
