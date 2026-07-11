using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistRegistry.Standard.Data
{
	public class AdoReader
	{
		static public string ReadString(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) return "";
			return reader[column].ToString();
		}

		static public DateTime ReadDateTime(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");
			return Convert.ToDateTime(reader[column]);
		}

		static public DateTimeOffset ReadDateTimeOffset(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");

			string value = reader[column].ToString();
			DateTimeOffset d;
			if (DateTimeOffset.TryParse(value, out d) == false)
			{
				throw new Exception($"Value {value} for column {column} is not a valid DateTimeOffset");
			}

			return d;
		}

		static public DateTime? ReadNullableDateTime(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) return null;
			return Convert.ToDateTime(reader[column]);
		}

		static public long ReadLong(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");

			string value = reader[column].ToString();

			long n;
			if (Int64.TryParse(value, out n) == false)
			{
				throw new Exception($"Column {column} with value {value} is not a valid long integer");
			}

			return n;
		}

		static public int ReadInteger(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");

			string value = reader[column].ToString();

			int n;
			if (Int32.TryParse(value, out n) == false)
			{
				throw new Exception($"Column {column} with value {value} is not a valid integer");
			}

			return n;
		}

		static public Guid ReadGuid(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");

			string value = reader[column].ToString();

			Guid n;
			if (Guid.TryParse(value, out n) == false)
			{
				throw new Exception($"Column {column} with value {value} is not a valid integer");
			}

			return n;
		}


		static public int? ReadNullableInteger(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) return null;
			return ReadInteger(reader, column);
		}

		static public Guid? ReadNullableGuid(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) return null;
			return ReadGuid(reader, column);
		}

		static public double ReadDouble(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");

			string value = reader[column].ToString();

			double n;
			if (Double.TryParse(value, out n) == false)
			{
				throw new Exception($"Column {column} with value {value} is not a valid double");
			}


			return n;
		}

		static public double? ReadNullableDouble(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) return null;
			return ReadDouble(reader, column);
		}

		static public bool ReadBoolean(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) throw new Exception($"Column {column} is null.  A value is expected");

			string value = reader[column].ToString();

			bool n;
			if (Boolean.TryParse(value, out n) == false)
			{
				throw new Exception($"Column {column} with value {value} is not a valid boolean");
			}

			return n;
		}

		static public bool? ReadNullableBoolean(SqlDataReader reader, int column)
		{
			if (reader[column] == DBNull.Value) return null;
			return ReadBoolean(reader, column);
		}


	}  // end of class
}  // end of namespace

