using System;
using System.Collections.Generic;
using System.Text;

namespace Wup
{
	internal class ByteConverter
	{
		public static byte[] ReverseBytes(byte[] inArray)
		{
			int num = inArray.Length - 1;
			for (int i = 0; i < inArray.Length / 2; i++)
			{
				byte b = inArray[i];
				inArray[i] = inArray[num];
				inArray[num] = b;
				num--;
			}
			return inArray;
		}

		public static short ReverseEndian(short value)
		{
			return BitConverter.ToInt16(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static ushort ReverseEndian(ushort value)
		{
			return BitConverter.ToUInt16(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static int ReverseEndian(int value)
		{
			return BitConverter.ToInt32(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static uint ReverseEndian(uint value)
		{
			return BitConverter.ToUInt32(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static long ReverseEndian(long value)
		{
			return BitConverter.ToInt64(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static ulong ReverseEndian(ulong value)
		{
			return BitConverter.ToUInt64(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static float ReverseEndian(float value)
		{
			return BitConverter.ToSingle(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static double ReverseEndian(double value)
		{
			return BitConverter.ToDouble(ByteConverter.ReverseBytes(BitConverter.GetBytes(value)), 0);
		}

		public static string Bytes2String(byte[] bytes)
		{
			string text = "";
			int num = 0;
			while (num < bytes.Length && bytes[num] != 0)
			{
				num++;
			}
			byte[] array = new byte[num];
			Array.Copy(bytes, array, array.Length);
			List<int> list = new List<int>();
			int num2 = 0;
			while (num2 < array.Length - 1 && array[num2] != 0)
			{
				if (array[num2] == 20)
				{
					list.Add(num2);
					num2++;
				}
				num2++;
			}
			if (list.Count > 0)
			{
				if (list[0] > 0)
				{
					text += Encoding.UTF8.GetString(array, 0, list[0]);
				}
				string arg_A0_0 = text;
				char c = (char)array[list[0]];
				text = arg_A0_0 + c.ToString();
				string arg_BB_0 = text;
				c = (char)array[list[0] + 1];
				text = arg_BB_0 + c.ToString();
			}
			for (int i = 1; i < list.Count; i++)
			{
				int num3 = list[i] - list[i - 1] - 2;
				if (num3 > 0)
				{
					text += Encoding.UTF8.GetString(array, list[i - 1] + 2, num3);
				}
				string arg_116_0 = text;
				char c = (char)array[list[i]];
				text = arg_116_0 + c.ToString();
				string arg_132_0 = text;
				c = (char)array[list[i] + 1];
				text = arg_132_0 + c.ToString();
			}
			int num4 = 0;
			if (list.Count > 0)
			{
				num4 = list[list.Count - 1] + 2;
			}
			if (num4 < array.Length)
			{
				text += Encoding.UTF8.GetString(array, num4, array.Length - num4);
			}
			return text;
		}

		public static bool IsCharValidate(char ch)
		{
			bool arg_13_0 = (byte)(ch >> 8 & 'ÿ') != 0;
			byte b = (byte)(ch & 'ÿ');
			return arg_13_0 || (b & 128) == 0;
		}

		public static byte[] String2Bytes(string strInput, bool IsLocalString)
		{
			if (!IsLocalString)
			{
				return ByteConverter.String2Bytes(strInput);
			}
			return Encoding.UTF8.GetBytes(strInput);
		}

		public static byte[] String2Bytes(string strInput)
		{
			if (strInput == null)
			{
				return null;
			}
			char[] array = strInput.ToCharArray();
			List<int> list = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				if (!ByteConverter.IsCharValidate(array[i]))
				{
					list.Add(i);
				}
			}
			byte[] array2 = new byte[Encoding.UTF8.GetByteCount(strInput)];
			int num = 0;
			if (list.Count > 0)
			{
				if (list[0] > 0)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(array, 0, list[0]);
					Array.Copy(bytes, 0, array2, 0, bytes.Length);
					num += bytes.Length;
				}
				array2.SetValue((byte)array[list[0]], num);
				num++;
			}
			for (int j = 1; j < list.Count; j++)
			{
				int num2 = list[j] - list[j - 1] - 1;
				if (num2 > 0)
				{
					byte[] bytes = Encoding.UTF8.GetBytes(array, list[j - 1] + 1, num2);
					Array.Copy(bytes, 0, array2, num, bytes.Length);
					num += bytes.Length;
				}
				array2.SetValue((byte)array[list[j]], num);
				num++;
			}
			int num3 = 0;
			if (list.Count > 0)
			{
				num3 = list[list.Count - 1] + 1;
			}
			if (num3 < array2.Length)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(array, num3, array.Length - num3);
				Array.Copy(bytes, 0, array2, num, bytes.Length);
				num += bytes.Length;
			}
			byte[] array3 = new byte[num];
			Array.Copy(array2, array3, num);
			return array3;
		}
	}
}
