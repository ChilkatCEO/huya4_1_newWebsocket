using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Wup.Jce
{
	public class JceInputStream
	{
		public class HeadData
		{
			public byte type;

			public int tag;

			public void clear()
			{
				this.type = 0;
				this.tag = 0;
			}
		}

		private MemoryStream ms;

		private BinaryReader br;

		protected string sServerEncoding = "utf-8";

		public JceInputStream()
		{
			this.ms = new MemoryStream();
			this.br = null;
			this.br = new BinaryReader(this.ms);
		}

		public JceInputStream(MemoryStream ms)
		{
			this.ms = ms;
			this.br = null;
			this.br = new BinaryReader(ms);
		}

		public JceInputStream(byte[] bs)
		{
			this.ms = new MemoryStream(bs);
			this.br = null;
			this.br = new BinaryReader(this.ms);
		}

		public JceInputStream(byte[] bs, int pos)
		{
			this.ms = new MemoryStream(bs);
			this.ms.Position = (long)pos;
			this.br = null;
			this.br = new BinaryReader(this.ms);
		}

		public void wrap(byte[] bs, int index = 0)
		{
			if (this.ms != null)
			{
				this.ms = null;
				this.ms = new MemoryStream(bs, index, bs.Length - index);
				this.br = null;
				this.br = new BinaryReader(this.ms);
				return;
			}
			this.ms = new MemoryStream(bs);
			this.br = null;
			this.br = new BinaryReader(this.ms);
		}

		public static int readHead(JceInputStream.HeadData hd, BinaryReader bb)
		{
			if (bb.BaseStream.Position >= bb.BaseStream.Length)
			{
				throw new JceDecodeException("read file to end");
			}
			byte b = bb.ReadByte();
			hd.type = (byte)(b & 15);
			hd.tag = (b & 240) >> 4;
			if (hd.tag == 15)
			{
				hd.tag = (int)bb.ReadByte();
				return 2;
			}
			return 1;
		}

		public int readHead(JceInputStream.HeadData hd)
		{
			return JceInputStream.readHead(hd, this.br);
		}

		private int peakHead(JceInputStream.HeadData hd)
		{
			long position = this.ms.Position;
			int arg_1F_0 = this.readHead(hd);
			this.ms.Position = position;
			return arg_1F_0;
		}

		private void skip(int len)
		{
			this.ms.Position += (long)len;
		}

		public bool skipToTag(int tag)
		{
			try
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				while (true)
				{
					int len = this.peakHead(headData);
					if (tag <= headData.tag || headData.type == 11)
					{
						break;
					}
					this.skip(len);
					this.skipField(headData.type);
				}
				return tag == headData.tag;
			}
			catch (JceDecodeException arg_42_0)
			{
				QTrace.Trace(arg_42_0.Message);
			}
			return false;
		}

		public void skipToStructEnd()
		{
			JceInputStream.HeadData headData = new JceInputStream.HeadData();
			do
			{
				this.readHead(headData);
				this.skipField(headData.type);
			}
			while (headData.type != 11);
		}

		private void skipField()
		{
			JceInputStream.HeadData headData = new JceInputStream.HeadData();
			this.readHead(headData);
			this.skipField(headData.type);
		}

		private void skipField(byte type)
		{
			switch (type)
			{
			case 0:
				this.skip(1);
				return;
			case 1:
				this.skip(2);
				return;
			case 2:
				this.skip(4);
				return;
			case 3:
				this.skip(8);
				return;
			case 4:
				this.skip(4);
				return;
			case 5:
				this.skip(8);
				return;
			case 6:
			{
				int num = (int)this.br.ReadByte();
				if (num < 0)
				{
					num += 256;
				}
				this.skip(num);
				return;
			}
			case 7:
				this.skip(ByteConverter.ReverseEndian(this.br.ReadInt32()));
				return;
			case 8:
			{
				int num2 = this.Read(0, 0, true);
				for (int i = 0; i < num2 * 2; i++)
				{
					this.skipField();
				}
				return;
			}
			case 9:
			{
				int num3 = this.Read(0, 0, true);
				for (int j = 0; j < num3; j++)
				{
					this.skipField();
				}
				return;
			}
			case 10:
				this.skipToStructEnd();
				return;
			case 11:
			case 12:
				return;
			case 13:
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				if (headData.type != 0)
				{
					throw new JceDecodeException(string.Concat(new object[]
					{
						"skipField with invalid type, type value: ",
						type,
						", ",
						headData.type
					}));
				}
				int len = this.Read(0, 0, true);
				this.skip(len);
				return;
			}
			default:
				throw new JceDecodeException("invalid type.");
			}
		}

		public bool Read(bool b, int tag, bool isRequire)
		{
			return this.Read(0, tag, isRequire) > 0;
		}

		public char Read(char c, int tag, bool isRequire)
		{
			return (char)this.Read((byte)c, tag, isRequire);
		}

		public byte Read(byte c, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 0)
				{
					if (type != 12)
					{
						throw new JceDecodeException("type mismatch.");
					}
					c = 0;
				}
				else
				{
					c = this.br.ReadByte();
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return c;
		}

		public short Read(short n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 0)
				{
					if (type != 1)
					{
						if (type != 12)
						{
							throw new JceDecodeException("type mismatch.");
						}
						n = 0;
					}
					else
					{
						n = ByteConverter.ReverseEndian(this.br.ReadInt16());
					}
				}
				else
				{
					n = (short)((sbyte)this.br.ReadByte());
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public ushort Read(ushort n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 0)
				{
					if (type != 1)
					{
						if (type != 12)
						{
							throw new JceDecodeException("type mismatch.");
						}
						n = 0;
					}
					else
					{
						n = ByteConverter.ReverseEndian(this.br.ReadUInt16());
					}
				}
				else
				{
					n = (ushort)this.br.ReadByte();
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public int Read(int n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				switch (type)
				{
				case 0:
					n = (int)((sbyte)this.br.ReadByte());
					break;
				case 1:
					n = (int)ByteConverter.ReverseEndian(this.br.ReadInt16());
					break;
				case 2:
					n = ByteConverter.ReverseEndian(this.br.ReadInt32());
					break;
				case 3:
					n = ByteConverter.ReverseEndian(this.br.ReadInt32());
					break;
				default:
					if (type != 12)
					{
						throw new JceDecodeException("type mismatch.");
					}
					n = 0;
					break;
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public uint Read(uint n, int tag, bool isRequire)
		{
			return (uint)this.Read((long)((ulong)n), tag, isRequire);
		}

		public long Read(long n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				switch (type)
				{
				case 0:
					n = (long)((sbyte)this.br.ReadByte());
					break;
				case 1:
					n = (long)ByteConverter.ReverseEndian(this.br.ReadInt16());
					break;
				case 2:
					n = (long)ByteConverter.ReverseEndian(this.br.ReadInt32());
					break;
				case 3:
					n = ByteConverter.ReverseEndian(this.br.ReadInt64());
					break;
				default:
					if (type != 12)
					{
						throw new JceDecodeException("type mismatch.");
					}
					n = 0L;
					break;
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public ulong Read(ulong n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				switch (type)
				{
				case 0:
					n = (ulong)this.br.ReadByte();
					break;
				case 1:
					n = (ulong)ByteConverter.ReverseEndian(this.br.ReadUInt16());
					break;
				case 2:
					n = (ulong)ByteConverter.ReverseEndian(this.br.ReadUInt32());
					break;
				case 3:
					n = ByteConverter.ReverseEndian(this.br.ReadUInt64());
					break;
				default:
					if (type != 12)
					{
						throw new JceDecodeException("type mismatch.");
					}
					n = 0uL;
					break;
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public float Read(float n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 4)
				{
					if (type != 12)
					{
						throw new JceDecodeException("type mismatch.");
					}
					n = 0f;
				}
				else
				{
					n = ByteConverter.ReverseEndian(this.br.ReadSingle());
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public double Read(double n, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 4)
				{
					if (type != 5)
					{
						if (type != 12)
						{
							throw new JceDecodeException("type mismatch.");
						}
						n = 0.0;
					}
					else
					{
						n = ByteConverter.ReverseEndian(this.br.ReadDouble());
					}
				}
				else
				{
					n = (double)ByteConverter.ReverseEndian(this.br.ReadSingle());
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return n;
		}

		public string readByteString(string s, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 6)
				{
					if (type != 7)
					{
						throw new JceDecodeException("type mismatch.");
					}
					int num = ByteConverter.ReverseEndian(this.br.ReadInt32());
					if (num > JceStruct.JCE_MAX_STRING_LENGTH || num < 0)
					{
						throw new JceDecodeException("string too long: " + num);
					}
					//new byte[num];
					s = HexUtil.bytes2HexStr(this.br.ReadBytes(num));
				}
				else
				{
					int num2 = (int)this.br.ReadByte();
					if (num2 < 0)
					{
						num2 += 256;
					}
					//new byte[num2];
					s = HexUtil.bytes2HexStr(this.br.ReadBytes(num2));
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return s;
		}

		private string readString1()
		{
			int num = (int)this.br.ReadByte();
			if (num < 0)
			{
				num += 256;
			}
			//new byte[num];
			return ByteConverter.Bytes2String(this.br.ReadBytes(num));
		}

		private string readString4()
		{
			int num = ByteConverter.ReverseEndian(this.br.ReadInt32());
			if (num > JceStruct.JCE_MAX_STRING_LENGTH || num < 0)
			{
				throw new JceDecodeException("string too long: " + num);
			}
			//new byte[num];
			return ByteConverter.Bytes2String(this.br.ReadBytes(num));
		}

		public string Read(string s, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 6)
				{
					if (type != 7)
					{
						throw new JceDecodeException("type mismatch.");
					}
					s = this.readString4();
				}
				else
				{
					s = this.readString1();
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return s;
		}

		public string readString(int tag, bool isRequire)
		{
			string result = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 6)
				{
					if (type != 7)
					{
						throw new JceDecodeException("type mismatch.");
					}
					result = this.readString4();
				}
				else
				{
					result = this.readString1();
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return result;
		}

		public string[] Read(string[] s, int tag, bool isRequire)
		{
			return this.readArray<string>(s, tag, isRequire);
		}

		public IDictionary readMap<T>(int tag, bool isRequire)
		{
			T arg = (T)((object)BasicClassTypeUtil.CreateObject<T>());
			return this.readMap<T>(arg, tag, isRequire);
		}

		public IDictionary readMap<T>(T arg, int tag, bool isRequire)
		{
			IDictionary dictionary = BasicClassTypeUtil.CreateObject(arg.GetType()) as IDictionary;
			if (dictionary == null)
			{
				return null;
			}
			Type[] genericArguments = dictionary.GetType().GetGenericArguments();
			if (genericArguments == null || genericArguments.Length < 2)
			{
				return null;
			}
			object obj = BasicClassTypeUtil.CreateObject(genericArguments[0]);
			object obj2 = BasicClassTypeUtil.CreateObject(genericArguments[1]);
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 8)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					obj = this.Read<object>(obj, 0, true);
					obj2 = this.Read<object>(obj2, 1, true);
					if (obj != null)
					{
						if (dictionary.Contains(obj))
						{
							dictionary[obj] = obj2;
						}
						else
						{
							dictionary.Add(obj, obj2);
						}
					}
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return dictionary;
		}

		public bool[] Read(bool[] l, int tag, bool isRequire)
		{
			bool[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				array = new bool[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public byte[] Read(byte[] l, int tag, bool isRequire)
		{
			byte[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					if (type != 13)
					{
						throw new JceDecodeException("type mismatch.");
					}
					JceInputStream.HeadData headData2 = new JceInputStream.HeadData();
					this.readHead(headData2);
					if (headData2.type != 0)
					{
						throw new JceDecodeException(string.Concat(new object[]
						{
							"type mismatch, tag: ",
							tag,
							", type: ",
							headData.type,
							", ",
							headData2.type
						}));
					}
					int num = this.Read(0, 0, true);
					if (num < 0)
					{
						throw new JceDecodeException(string.Concat(new object[]
						{
							"invalid size, tag: ",
							tag,
							", type: ",
							headData.type,
							", ",
							headData2.type,
							", size: ",
							num
						}));
					}
					array = new byte[num];
					try
					{
						array = this.br.ReadBytes(num);
						return array;
					}
					catch (Exception arg_11F_0)
					{
						QTrace.Trace(arg_11F_0.Message);
						return null;
					}
				}
				int num2 = this.Read(0, 0, true);
				if (num2 < 0)
				{
					throw new JceDecodeException("size invalid: " + num2);
				}
				array = new byte[num2];
				for (int i = 0; i < num2; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public short[] Read(short[] l, int tag, bool isRequire)
		{
			short[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				array = new short[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public int[] Read(int[] l, int tag, bool isRequire)
		{
			int[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				array = new int[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public long[] Read(long[] l, int tag, bool isRequire)
		{
			long[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				array = new long[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public float[] Read(float[] l, int tag, bool isRequire)
		{
			float[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				array = new float[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public double[] Read(double[] l, int tag, bool isRequire)
		{
			double[] array = null;
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					throw new JceDecodeException("type mismatch.");
				}
				int num = this.Read(0, 0, true);
				if (num < 0)
				{
					throw new JceDecodeException("size invalid: " + num);
				}
				array = new double[num];
				for (int i = 0; i < num; i++)
				{
					array[i] = this.Read(array[0], 0, true);
				}
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return array;
		}

		public T[] readArray<T>(T[] l, int tag, bool isRequire)
		{
			if (l == null || l.Length == 0)
			{
				throw new JceDecodeException("unable to get type of key and value.");
			}
			return (T[])this.readArrayImpl<T>(l[0], tag, isRequire);
		}

		public IList readList<T>(T l, int tag, bool isRequire)
		{
			if (l == null)
			{
				return null;
			}
			IList list = BasicClassTypeUtil.CreateObject(l.GetType()) as IList;
			if (list == null)
			{
				return null;
			}
			object mt = BasicClassTypeUtil.CreateListItem(list.GetType());
			Array array = this.readArrayImpl<object>(mt, tag, isRequire);
			if (array != null)
			{
				list.Clear();
				foreach (object current in array)
				{
					list.Add(current);
				}
				return list;
			}
			return null;
		}

		public List<T> readArray<T>(List<T> l, int tag, bool isRequire)
		{
			if (l == null || l.Count == 0)
			{
				return new List<T>();
			}
			T[] array = (T[])this.readArrayImpl<T>(l[0], tag, isRequire);
			if (array == null)
			{
				return null;
			}
			List<T> list = new List<T>();
			for (int i = 0; i < array.Length; i++)
			{
				list.Add(array[i]);
			}
			return list;
		}

		private Array readArrayImpl<T>(T mt, int tag, bool isRequire)
		{
			if (this.skipToTag(tag))
			{
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				byte type = headData.type;
				if (type != 9)
				{
					if (type == 13)
					{
						JceInputStream.HeadData headData2 = new JceInputStream.HeadData();
						this.readHead(headData2);
						if (headData2.type == 12)
						{
							return Array.CreateInstance(mt.GetType(), 0);
						}
						if (headData2.type != 0)
						{
							throw new JceDecodeException(string.Concat(new object[]
							{
								"type mismatch, tag: ",
								tag,
								", type: ",
								headData.type,
								", ",
								headData2.type
							}));
						}
						int num = this.Read(0, 0, true);
						if (num < 0)
						{
							throw new JceDecodeException(string.Concat(new object[]
							{
								"invalid size, tag: ",
								tag,
								", type: ",
								headData.type,
								", size: ",
								num
							}));
						}
						T[] array = new T[num];
						try
						{
							byte[] array2 = this.br.ReadBytes(num);
							for (int i = 0; i < array2.Length; i++)
							{
								object obj = array2[i];
								array[i] = (T)((object)obj);
							}
							Array result = array;
							return result;
						}
						catch (Exception arg_1C7_0)
						{
							QTrace.Trace(arg_1C7_0.Message);
							Array result = null;
							return result;
						}
					}
					throw new JceDecodeException("type mismatch.");
				}
				int num2 = this.Read(0, 0, true);
				if (num2 < 0)
				{
					throw new JceDecodeException("size invalid: " + num2);
				}
				Array array3 = Array.CreateInstance(mt.GetType(), num2);
				for (int j = 0; j < num2; j++)
				{
					T t = (T)((object)this.Read<T>(mt, 0, true));
					array3.SetValue(t, j);
				}
				return array3;
			}
			else
			{
				if (isRequire)
				{
					throw new JceDecodeException("require field not exist.");
				}
				return null;
			}
		}

		public JceStruct directRead(JceStruct o, int tag, bool isRequire)
		{
			JceStruct jceStruct = null;
			if (this.skipToTag(tag))
			{
				try
				{
					jceStruct = (JceStruct)BasicClassTypeUtil.CreateObject(o.GetType());
				}
				catch (Exception arg_1E_0)
				{
					throw new JceDecodeException(arg_1E_0.Message);
				}
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				if (headData.type != 10)
				{
					throw new JceDecodeException("type mismatch.");
				}
				jceStruct.ReadFrom(this);
				this.skipToStructEnd();
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return jceStruct;
		}

		public JceStruct Read(JceStruct o, int tag, bool isRequire)
		{
			JceStruct jceStruct = null;
			if (this.skipToTag(tag))
			{
				try
				{
					jceStruct = (JceStruct)BasicClassTypeUtil.CreateObject(o.GetType());
				}
				catch (Exception arg_1E_0)
				{
					throw new JceDecodeException(arg_1E_0.Message);
				}
				JceInputStream.HeadData headData = new JceInputStream.HeadData();
				this.readHead(headData);
				if (headData.type != 10)
				{
					throw new JceDecodeException("type mismatch.");
				}
				jceStruct.ReadFrom(this);
				this.skipToStructEnd();
			}
			else if (isRequire)
			{
				throw new JceDecodeException("require field not exist.");
			}
			return jceStruct;
		}

		public JceStruct[] Read(JceStruct[] o, int tag, bool isRequire)
		{
			return this.readArray<JceStruct>(o, tag, isRequire);
		}

		public object Read<T>(T o, int tag, bool isRequire)
		{
			if (o == null)
			{
				o = (T)((object)BasicClassTypeUtil.CreateObject<T>());
			}
			if (o is byte || o is char)
			{
				return this.Read(0, tag, isRequire);
			}
			if (o is char)
			{
				return this.Read('\0', tag, isRequire);
			}
			if (o is bool)
			{
				return this.Read(false, tag, isRequire);
			}
			if (o is short)
			{
				return this.Read(0, tag, isRequire);
			}
			if (o is ushort)
			{
				return this.Read(0, tag, isRequire);
			}
			if (o is int)
			{
				return this.Read(0, tag, isRequire);
			}
			if (o is uint)
			{
				return this.Read(0u, tag, isRequire);
			}
			if (o is long)
			{
				return this.Read(0L, tag, isRequire);
			}
			if (o is ulong)
			{
				return this.Read(0uL, tag, isRequire);
			}
			if (o is float)
			{
				return this.Read(0f, tag, isRequire);
			}
			if (o is double)
			{
				return this.Read(0.0, tag, isRequire);
			}
			if (o is string)
			{
				return this.readString(tag, isRequire);
			}
			if (o is JceStruct)
			{
				object obj = o;
				return this.Read((JceStruct)obj, tag, isRequire);
			}
			if (o != null && o.GetType().IsArray)
			{
				if (o is byte[] || o is byte[])
				{
					return this.Read(new byte[0], tag, isRequire);
				}
				if (o is bool[])
				{
					return this.Read(new bool[0], tag, isRequire);
				}
				if (o is short[])
				{
					return this.Read(new short[0], tag, isRequire);
				}
				if (o is int[])
				{
					return this.Read(new int[0], tag, isRequire);
				}
				if (o is long[])
				{
					return this.Read(new long[0], tag, isRequire);
				}
				if (o is float[])
				{
					return this.Read(new float[0], tag, isRequire);
				}
				if (o is double[])
				{
					return this.Read(new double[0], tag, isRequire);
				}
				object obj2 = o;
				return this.readArray<object>((object[])obj2, tag, isRequire);
			}
			else
			{
				if (o is IList)
				{
					return this.readList<T>(o, tag, isRequire);
				}
				if (o is IDictionary)
				{
					return this.readMap<T>(o, tag, isRequire);
				}
				throw new JceDecodeException("read object error: unsupport type." + o.ToString());
			}
		}

		public int setServerEncoding(string se)
		{
			this.sServerEncoding = se;
			return 0;
		}

		internal object read(object proxy, int tag, bool isRequired)
		{
			return this.Read<object>(proxy, tag, isRequired);
		}
	}
}
