using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Wup.Jce
{
	public class JceOutputStream
	{
		private MemoryStream ms;

		private BinaryWriter bw;

		protected string sServerEncoding = "UTF-8";

		public JceOutputStream(MemoryStream ms)
		{
			this.ms = ms;
			this.bw = new BinaryWriter(ms, Encoding.BigEndianUnicode);
		}

		public JceOutputStream(int capacity)
		{
			this.ms = new MemoryStream(capacity);
			this.bw = new BinaryWriter(this.ms, Encoding.BigEndianUnicode);
		}

		public JceOutputStream()
		{
			this.ms = new MemoryStream(128);
			this.bw = new BinaryWriter(this.ms, Encoding.BigEndianUnicode);
		}

		public MemoryStream getMemoryStream()
		{
			return this.ms;
		}

		public byte[] toByteArray()
		{
			return this.ms.ToArray();
		}

		public void reserve(int len)
		{
			if (this.ms.Capacity - (int)this.ms.Length < len)
			{
				this.ms.Capacity = this.ms.Capacity + len << 1;
			}
		}

		public void writeHead(byte type, int tag)
		{
			if (tag < 15)
			{
				byte value = (byte)(tag << 4 | (int)type);
				try
				{
					this.bw.Write(value);
					return;
				}
				catch (Exception arg_1A_0)
				{
					QTrace.Trace(arg_1A_0.Message);
					return;
				}
			}
			if (tag < 256)
			{
				try
				{
					byte value2 = (byte)(240 | type);
					this.bw.Write(value2);
					this.bw.Write((byte)tag);
					return;
				}
				catch (Exception ex)
				{
					QTrace.Trace(this + " writeHead: " + ex.Message);
					return;
				}
			}
			throw new JceEncodeException("tag is too large: " + tag);
		}

		public void Write(bool b, int tag)
		{
			byte b2 = (byte)(b ? 1 : 0);
			this.Write(b2, tag);
		}

		public void Write(byte b, int tag)
		{
			this.reserve(3);
			if (b == 0)
			{
				this.writeHead(12, tag);
				return;
			}
			this.writeHead(0, tag);
			try
			{
				this.bw.Write(b);
			}
			catch (Exception arg_2A_0)
			{
				QTrace.Trace(arg_2A_0.Message);
			}
		}

		public void Write(short n, int tag)
		{
			this.reserve(4);
			if (n >= -128 && n <= 127)
			{
				this.Write((byte)n, tag);
				return;
			}
			this.writeHead(1, tag);
			try
			{
				this.bw.Write(ByteConverter.ReverseEndian(n));
			}
			catch (Exception ex)
			{
				QTrace.Trace(this + " Write: " + ex.Message);
			}
		}

		public void Write(ushort n, int tag)
		{
			this.Write((short)n, tag);
		}

		public void Write(int n, int tag)
		{
			this.reserve(6);
			if (n >= -32768 && n <= 32767)
			{
				this.Write((short)n, tag);
				return;
			}
			this.writeHead(2, tag);
			try
			{
				this.bw.Write(ByteConverter.ReverseEndian(n));
			}
			catch (Exception arg_3C_0)
			{
				QTrace.Trace(arg_3C_0.Message);
			}
		}

		public void Write(uint n, int tag)
		{
			this.Write((long)((ulong)n), tag);
		}

		public void Write(ulong n, int tag)
		{
			this.Write((long)n, tag);
		}

		public void Write(long n, int tag)
		{
			this.reserve(10);
			if (n >= -2147483648L && n <= 2147483647L)
			{
				this.Write((int)n, tag);
				return;
			}
			this.writeHead(3, tag);
			try
			{
				this.bw.Write(ByteConverter.ReverseEndian(n));
			}
			catch (Exception arg_3F_0)
			{
				QTrace.Trace(arg_3F_0.Message);
			}
		}

		public void Write(float n, int tag)
		{
			this.reserve(6);
			this.writeHead(4, tag);
			try
			{
				this.bw.Write(ByteConverter.ReverseEndian(n));
			}
			catch (Exception arg_22_0)
			{
				QTrace.Trace(arg_22_0.Message);
			}
		}

		public void Write(double n, int tag)
		{
			this.reserve(10);
			this.writeHead(5, tag);
			try
			{
				this.bw.Write(ByteConverter.ReverseEndian(n));
			}
			catch (Exception arg_23_0)
			{
				QTrace.Trace(arg_23_0.Message);
			}
		}

		public void writeStringByte(string s, int tag)
		{
			byte[] array = HexUtil.hexStr2Bytes(s);
			this.reserve(10 + array.Length);
			if (array.Length > 255)
			{
				this.writeHead(7, tag);
				try
				{
					this.bw.Write(ByteConverter.ReverseEndian(array.Length));
					this.bw.Write(array);
					return;
				}
				catch (Exception arg_46_0)
				{
					QTrace.Trace(arg_46_0.Message);
					return;
				}
			}
			this.writeHead(6, tag);
			try
			{
				this.bw.Write((byte)array.Length);
				this.bw.Write(array);
			}
			catch (Exception arg_77_0)
			{
				QTrace.Trace(arg_77_0.Message);
			}
		}

		public void writeByteString(string s, int tag)
		{
			this.reserve(10 + s.Length);
			byte[] array = HexUtil.hexStr2Bytes(s);
			if (array.Length > 255)
			{
				this.writeHead(7, tag);
				try
				{
					this.bw.Write(ByteConverter.ReverseEndian(array.Length));
					this.bw.Write(array);
					return;
				}
				catch (Exception arg_49_0)
				{
					QTrace.Trace(arg_49_0.Message);
					return;
				}
			}
			this.writeHead(6, tag);
			try
			{
				this.bw.Write((byte)array.Length);
				this.bw.Write(array);
			}
			catch (Exception arg_7A_0)
			{
				QTrace.Trace(arg_7A_0.Message);
			}
		}

		public void Write(string s, int tag, bool IsLocalString = false)
		{
			byte[] array;
			try
			{
				array = ByteConverter.String2Bytes(s, IsLocalString);
				if (array == null)
				{
					array = new byte[0];
				}
			}
			catch (Exception ex)
			{
				QTrace.Trace(this + " write s Exception" + ex.Message);
				return;
			}
			if (array != null)
			{
				this.reserve(10 + array.Length);
			}
			if (array != null && array.Length > 255)
			{
				this.writeHead(7, tag);
				try
				{
					this.bw.Write(ByteConverter.ReverseEndian(array.Length));
					this.bw.Write(array);
					return;
				}
				catch (Exception arg_75_0)
				{
					QTrace.Trace(arg_75_0.Message);
					return;
				}
			}
			this.writeHead(6, tag);
			try
			{
				if (array != null)
				{
					this.bw.Write((byte)array.Length);
					this.bw.Write(array);
				}
				else
				{
					this.bw.Write(0);
				}
			}
			catch (Exception ex2)
			{
				QTrace.Trace(this + " write s(2) Exception" + ex2.Message);
			}
		}

		public void write<K, V>(Dictionary<K, V> m, int tag)
		{
			this.reserve(8);
			this.writeHead(8, tag);
			this.Write((m == null) ? 0 : m.Count, 0);
			if (m != null)
			{
				foreach (KeyValuePair<K, V> current in m)
				{
					this.Write(current.Key, 0);
					this.Write(current.Value, 1);
				}
			}
		}

		public void Write(IDictionary m, int tag)
		{
			this.reserve(8);
			this.writeHead(8, tag);
			this.Write((m == null) ? 0 : m.Count, 0);
			if (m != null)
			{
				foreach (object current in m.Keys)
				{
					this.Write(current, 0);
					this.Write(m[current], 1);
				}
			}
		}

		public void Write(bool[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					bool b = l[i];
					this.Write(b, 0);
				}
			}
		}

		public void Write(byte[] l, int tag)
		{
			int num = 0;
			if (l != null)
			{
				num = l.Length;
			}
			this.reserve(8 + num);
			this.writeHead(13, tag);
			this.writeHead(0, 0);
			this.Write(num, 0);
			try
			{
				if (l != null)
				{
					this.bw.Write(l);
				}
			}
			catch (Exception arg_3C_0)
			{
				QTrace.Trace(arg_3C_0.Message);
			}
		}

		public void Write(short[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					short n2 = l[i];
					this.Write(n2, 0);
				}
			}
		}

		public void Write(int[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					int n2 = l[i];
					this.Write(n2, 0);
				}
			}
		}

		public void Write(long[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					long n2 = l[i];
					this.Write(n2, 0);
				}
			}
		}

		public void Write(float[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					float n2 = l[i];
					this.Write(n2, 0);
				}
			}
		}

		public void Write(double[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					double n2 = l[i];
					this.Write(n2, 0);
				}
			}
		}

		public void write<T>(T[] l, int tag)
		{

			this.writeArray(l, tag);
		}

        private void writeArray<T>(T[] l, int tag)
        {
            int n = 0;
            if (l != null)
            {
                n = l.Length;
            }
            this.reserve(8);
            this.writeHead(9, tag);
            this.Write(n, 0);
            if (l != null)
            {
                for (int i = 0; i < l.Length; i++)
                {
                    object o = l[i];
                    this.Write(o, 0);
                }
            }
        }

        private void writeArray(object[] l, int tag)
		{
			int n = 0;
			if (l != null)
			{
				n = l.Length;
			}
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write(n, 0);
			if (l != null)
			{
				for (int i = 0; i < l.Length; i++)
				{
					object o = l[i];
					this.Write(o, 0);
				}
			}
		}

		public void writeList(IList l, int tag)
		{
			this.reserve(8);
			this.writeHead(9, tag);
			this.Write((l == null) ? 0 : ((l.Count > 0) ? l.Count : 0), 0);
			if (l != null)
			{
				for (int i = 0; i < l.Count; i++)
				{
					this.Write(l[i], 0);
				}
			}
		}

		public void Write(JceStruct o, int tag)
		{
			if (o == null)
			{
				return;
			}
			this.reserve(2);
			this.writeHead(10, tag);
			o.WriteTo(this);
			this.reserve(2);
			this.writeHead(11, 0);
		}

		public void Write(object o, int tag)
		{
			if (o == null)
			{
				return;
			}
			if (o is byte)
			{
				this.Write((byte)o, tag);
				return;
			}
			if (o is bool)
			{
				this.Write((bool)o, tag);
				return;
			}
			if (o is short)
			{
				this.Write((short)o, tag);
				return;
			}
			if (o is ushort)
			{
				this.Write((int)((ushort)o), tag);
				return;
			}
			if (o is int)
			{
				this.Write((int)o, tag);
				return;
			}
			if (o is uint)
			{
				this.Write((long)((ulong)((uint)o)), tag);
				return;
			}
			if (o is long)
			{
				this.Write((long)o, tag);
				return;
			}
			if (o is ulong)
			{
				this.Write((long)((ulong)o), tag);
				return;
			}
			if (o is float)
			{
				this.Write((float)o, tag);
				return;
			}
			if (o is double)
			{
				this.Write((double)o, tag);
				return;
			}
			if (o is string)
			{
				string s = o as string;
				this.Write(s, tag, false);
				return;
			}
			if (o is JceStruct)
			{
				this.Write((JceStruct)o, tag);
				return;
			}
			if (o is byte[])
			{
				this.Write((byte[])o, tag);
				return;
			}
			if (o is bool[])
			{
				this.Write((bool[])o, tag);
				return;
			}
			if (o is short[])
			{
				this.Write((short[])o, tag);
				return;
			}
			if (o is int[])
			{
				this.Write((int[])o, tag);
				return;
			}
			if (o is long[])
			{
				this.Write((long[])o, tag);
				return;
			}
			if (o is float[])
			{
				this.Write((float[])o, tag);
				return;
			}
			if (o is double[])
			{
				this.Write((double[])o, tag);
				return;
			}
			if (o.GetType().IsArray)
			{
				this.Write((object[])o, tag);
				return;
			}
			if (o is IList)
			{
				this.writeList((IList)o, tag);
				return;
			}
			if (o is IDictionary)
			{
				this.Write((IDictionary)o, tag);
				return;
			}
			throw new JceEncodeException("write object error: unsupport type. " + o.ToString() + "\n");
		}

		public int setServerEncoding(string se)
		{
			this.sServerEncoding = se;
			return 0;
		}
	}
}
