using System;
using System.Collections.Generic;
using System.Text;

namespace Wup
{
	public class BasicClassTypeUtil
	{
		public static string TransTypeList(List<string> listTpye)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < listTpye.Count; i++)
			{
				listTpye[i] = BasicClassTypeUtil.CS2UniType(listTpye[i]);
			}
			listTpye.Reverse();
			for (int j = 0; j < listTpye.Count; j++)
			{
				string text = listTpye[j];
				if (text != null)
				{
					if (text.Equals("list"))
					{
						listTpye[j - 1] = "<" + listTpye[j - 1];
						listTpye[0] = listTpye[0] + ">";
					}
					else if (text.Equals("map"))
					{
						listTpye[j - 1] = "<" + listTpye[j - 1] + ",";
						listTpye[0] = listTpye[0] + ">";
					}
					else if (text.Equals("Array"))
					{
						listTpye[j - 1] = "<" + listTpye[j - 1];
						listTpye[0] = listTpye[0] + ">";
					}
				}
			}
			listTpye.Reverse();
			foreach (string current in listTpye)
			{
				stringBuilder.Append(current);
			}
			return stringBuilder.ToString();
		}

		public static object CreateObject<T>()
		{
			return BasicClassTypeUtil.CreateObject(typeof(T));
		}

		public static object CreateObject(Type type)
		{
			object result;
			try
			{
				if (type.ToString() == "System.String")
				{
					result = "";
				}
				else if (type == typeof(byte[]))
				{
					result = new byte[0];
				}
				else if (type == typeof(short[]))
				{
					result = new short[0];
				}
				else if (type == typeof(ushort[]))
				{
					result = new ushort[0];
				}
				else if (type == typeof(int[]))
				{
					result = new int[0];
				}
				else if (type == typeof(uint[]))
				{
					result = new uint[0];
				}
				else if (type == typeof(long[]))
				{
					result = new long[0];
				}
				else if (type == typeof(ulong[]))
				{
					result = new ulong[0];
				}
				else if (type == typeof(char[]))
				{
					result = new char[0];
				}
				else
				{
					result = Activator.CreateInstance(type);
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public static object CreateListItem(Type typeList)
		{
			Type[] genericArguments = typeList.GetGenericArguments();
			if (genericArguments == null || genericArguments.Length == 0)
			{
				return null;
			}
			return BasicClassTypeUtil.CreateObject(genericArguments[0]);
		}

		public static string CS2UniType(string srcType)
		{
			if (srcType.Equals("System.Int16"))
			{
				return "short";
			}
			if (srcType.Equals("System.UInt16"))
			{
				return "ushort";
			}
			if (srcType.Equals("System.Int32"))
			{
				return "int32";
			}
			if (srcType.Equals("System.UInt32"))
			{
				return "uint32";
			}
			if (srcType.Equals("System.Boolean"))
			{
				return "bool";
			}
			if (srcType.Equals("System.Byte"))
			{
				return "char";
			}
			if (srcType.Equals("System.Double"))
			{
				return "double";
			}
			if (srcType.Equals("System.Single"))
			{
				return "float";
			}
			if (srcType.Equals("System.Int64"))
			{
				return "int64";
			}
			if (srcType.Equals("System.UInt64"))
			{
				return "uint64";
			}
			if (srcType.Equals("System.String"))
			{
				return "string";
			}
			if (srcType.IndexOf("System.Collections.Generic.QDictionary") == 0)
			{
				return "map";
			}
			if (srcType.IndexOf("System.Collections.Generic.List") == 0)
			{
				return "list";
			}
			return srcType;
		}

		public static bool IsQDictionary(string cls)
		{
			return cls.IndexOf("System.Collections.Generic.QDictionary") == 0;
		}
	}
}
