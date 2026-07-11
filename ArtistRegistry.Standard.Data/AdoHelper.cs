using Microsoft.Data.SqlClient;
using System;

namespace ArtistRegistry.Standard.Data
{
	public class AdoHelper
	{
		static public string ReadString(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return "";

			return reader[fieldName].ToString();
		}

		static public int ReadInt(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToInt32(reader[fieldName]);

		}

		static public long ReadLong(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToInt64(reader[fieldName]);

		}


		static public short ReadShort(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToInt16(reader[fieldName]);
		}


		static public byte ReadByte(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToByte(reader[fieldName]);
		}

		static public DateTime ReadDateTime(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			string value = reader[fieldName].ToString();

			DateTime dt;

			if (DateTime.TryParse(value, out dt)) return dt;

			throw new Exception($"Field {fieldName} value {value} is not a valid date/time");
		}

		static public double ReadDouble(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToDouble(reader[fieldName]);
		}


		static public int? ReadNullableInt(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			return Convert.ToInt32(reader[fieldName]);
		}


		static public short? ReadNullableShort(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			return Convert.ToInt16(reader[fieldName]);
		}

		static public byte? ReadNullableByte(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			return Convert.ToByte(reader[fieldName]);
		}

		static public DateTime? ReadNullableDateTime(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			string value = reader[fieldName].ToString();

			DateTime dt;

			if (DateTime.TryParse(value, out dt)) return dt;

			throw new Exception($"Field {fieldName} value {value} is not a valid date/time");
		}

		static public bool ReadBoolean(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToBoolean(reader[fieldName]);
		}

		static public bool? ReadNullableBoolean(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			return Convert.ToBoolean(reader[fieldName]);
		}

		static public double? ReadNullableDouble(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			return Convert.ToDouble(reader[fieldName]);
		}


		static public Guid ReadGuid(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is nullable guid.  That is not expected");
			}

			string value = reader[fieldName].ToString();

			Guid g;
			if (Guid.TryParse(value, out g)) return g;

			throw new Exception($"Field {fieldName} value {value} is not a valid guid");

		}

		static public Guid? ReadNullableGuid(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				return null;
			}

			string value = reader[fieldName].ToString();

			Guid g;
			if (Guid.TryParse(value, out g)) return g;

			throw new Exception($"Field {fieldName} value {value} is not a valid guid");

		}

		static public byte[] ReadBytes(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				return null;
			}

			byte[] data = (byte[])reader[fieldName];

			return data;

		}

		static public Decimal ReadDecimal(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				throw new Exception($"Field {fieldName} is NULL");
			}

			return Convert.ToDecimal(reader[fieldName]);
		}


		static public Decimal? ReadNullableDecimal(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value)
			{
				return null;
			}

			return Convert.ToDecimal(reader[fieldName]);
		}

		static public Int64? ReadNullableLong(SqlDataReader reader, string fieldName)
		{
			if (reader[fieldName] == DBNull.Value) return null;

			return Convert.ToInt64(reader[fieldName]);
		}

	}
}