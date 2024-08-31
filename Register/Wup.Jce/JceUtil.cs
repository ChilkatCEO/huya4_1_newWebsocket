using System;
using System.Collections.Generic;
using System.IO;

namespace Wup.Jce
{
	internal class JceUtil
	{
		private static int iConstant = 37;

		private static int iTotal = 17;

		public static bool Equals(bool l, bool r)
		{
			return l == r;
		}

		public static bool Equals(byte l, byte r)
		{
			return l == r;
		}

		public static bool Equals(char l, char r)
		{
			return l == r;
		}

		public static bool Equals(short l, short r)
		{
			return l == r;
		}

		public static bool Equals(int l, int r)
		{
			return l == r;
		}

		public static bool Equals(long l, long r)
		{
			return l == r;
		}

		public static bool Equals(float l, float r)
		{
			return l == r;
		}

		public static bool Equals(double l, double r)
		{
			return l == r;
		}

		public new static bool Equals(object l, object r)
		{
			return l.Equals(r);
		}

		public static int compareTo(bool l, bool r)
		{
			return (l ? 1 : 0) - (r ? 1 : 0);
		}

		public static int compareTo(byte l, byte r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo(char l, char r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo(short l, short r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo(int l, int r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo(long l, long r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo(float l, float r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo(double l, double r)
		{
			if (l < r)
			{
				return -1;
			}
			if (l <= r)
			{
				return 0;
			}
			return 1;
		}

		public static int compareTo<T>(T l, T r) where T : IComparable
		{
			return l.CompareTo(r);
		}

		public static int compareTo<T>(List<T> l, List<T> r) where T : IComparable
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Count && num2 < r.Count)
			{
				if (l[num] == null || r[num2] == null)
				{
					throw new Exception("Argument must be IComparable!");
				}
				IComparable arg_3E_0 = l[num];
				IComparable obj = r[num2];
				int num3 = arg_3E_0.CompareTo(obj);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Count, r.Count);
		}

		public static int compareTo<T>(T[] l, T[] r) where T : IComparable
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = l[num].CompareTo(r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(bool[] l, bool[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(byte[] l, byte[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(char[] l, char[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(short[] l, short[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(int[] l, int[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(long[] l, long[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(float[] l, float[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int compareTo(double[] l, double[] r)
		{
			int num = 0;
			int num2 = 0;
			while (num < l.Length && num2 < r.Length)
			{
				int num3 = JceUtil.compareTo(l[num], r[num2]);
				if (num3 != 0)
				{
					return num3;
				}
				num++;
				num2++;
			}
			return JceUtil.compareTo(l.Length, r.Length);
		}

		public static int hashCode(bool o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + (o ? 0 : 1);
		}

		public static int hashCode(bool[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + (array[i] ? 0 : 1);
			}
			return num;
		}

		public static int hashCode(byte o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + (int)o;
		}

		public static int hashCode(byte[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + (int)array[i];
			}
			return num;
		}

		public static int hashCode(char o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + (int)o;
		}

		public static int hashCode(char[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + (int)array[i];
			}
			return num;
		}

		public static int hashCode(double o)
		{
			return JceUtil.hashCode(Convert.ToInt64(o));
		}

		public static int hashCode(double[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + (int)(Convert.ToInt64(array[i]) ^ Convert.ToInt64(array[i]) >> 32);
			}
			return num;
		}

		public static int hashCode(float o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + Convert.ToInt32(o);
		}

		public static int hashCode(float[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + Convert.ToInt32(array[i]);
			}
			return num;
		}

		public static int hashCode(short o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + (int)o;
		}

		public static int hashCode(short[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + (int)array[i];
			}
			return num;
		}

		public static int hashCode(int o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + o;
		}

		public static int hashCode(int[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + array[i];
			}
			return num;
		}

		public static int hashCode(long o)
		{
			return JceUtil.iTotal * JceUtil.iConstant + (int)(o ^ o >> 32);
		}

		public static int hashCode(long[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + (int)(array[i] ^ array[i] >> 32);
			}
			return num;
		}

		public static int hashCode(JceStruct[] array)
		{
			if (array == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			int num = JceUtil.iTotal;
			for (int i = 0; i < array.Length; i++)
			{
				num = num * JceUtil.iConstant + array[i].GetHashCode();
			}
			return num;
		}

		public static int hashCode(object obj)
		{
			if (obj == null)
			{
				return JceUtil.iTotal * JceUtil.iConstant;
			}
			if (obj.GetType().IsArray)
			{
				if (obj is long[])
				{
					return JceUtil.hashCode((long[])obj);
				}
				if (obj is int[])
				{
					return JceUtil.hashCode((int[])obj);
				}
				if (obj is short[])
				{
					return JceUtil.hashCode((short[])obj);
				}
				if (obj is char[])
				{
					return JceUtil.hashCode((char[])obj);
				}
				if (obj is byte[])
				{
					return JceUtil.hashCode((byte[])obj);
				}
				if (obj is double[])
				{
					return JceUtil.hashCode((double[])obj);
				}
				if (obj is float[])
				{
					return JceUtil.hashCode((float[])obj);
				}
				if (obj is bool[])
				{
					return JceUtil.hashCode((bool[])obj);
				}
				if (obj is JceStruct[])
				{
					return JceUtil.hashCode((JceStruct[])obj);
				}
				return JceUtil.hashCode((object[])obj);
			}
			else
			{
				if (obj is JceStruct)
				{
					return obj.GetHashCode();
				}
				return JceUtil.iTotal * JceUtil.iConstant + obj.GetHashCode();
			}
		}

		public static byte[] getJceBufArray(MemoryStream ms)
		{
			return ms.ToArray();
		}
	}
}
