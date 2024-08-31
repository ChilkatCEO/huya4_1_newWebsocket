using System;
using System.Collections.Generic;
using System.IO;
using Wup.Jce;

namespace Wup
{
	public class UniPacket : UniAttribute
	{
		public static readonly int UniPacketHeadSize = 4;

		protected RequestPacket _package = new RequestPacket();

		public string ServantName
		{
			get
			{
				return this._package.sServantName;
			}
			set
			{
				this._package.sServantName = value;
			}
		}

		public string FuncName
		{
			get
			{
				return this._package.sFuncName;
			}
			set
			{
				this._package.sFuncName = value;
			}
		}

		public int RequestId
		{
			get
			{
				return this._package.iRequestId;
			}
			set
			{
				this._package.iRequestId = value;
			}
		}

		public int OldRespIRet
		{
			get;
			set;
		}

		public UniPacket()
		{
			this._package.iVersion = 2;
		}

		public void setVersion(short iVer)
		{
			this._iVer = iVer;
			this._package.iVersion = iVer;
		}

		public short getVersion()
		{
			return this._package.iVersion;
		}

		public new byte[] Encode()
		{
			if (this._package.sServantName.Equals(""))
			{
				throw new ArgumentException("servantName can not is null");
			}
			if (this._package.sFuncName.Equals(""))
			{
				throw new ArgumentException("funcName can not is null");
			}
			JceOutputStream jceOutputStream = new JceOutputStream(0);
			jceOutputStream.setServerEncoding(base.EncodeName);
			if (this._package.iVersion == (short)Const.PACKET_TYPE_WUP)
			{
				jceOutputStream.Write(this._data, 0);
			}
			else
			{
				jceOutputStream.write<string, byte[]>(this._new_data, 0);
			}
			this._package.sBuffer = JceUtil.getJceBufArray(jceOutputStream.getMemoryStream());
			jceOutputStream = new JceOutputStream(0);
			jceOutputStream.setServerEncoding(base.EncodeName);
			this.WriteTo(jceOutputStream);
			byte[] jceBufArray = JceUtil.getJceBufArray(jceOutputStream.getMemoryStream());
			int num = jceBufArray.Length;
			MemoryStream memoryStream = new MemoryStream(num + UniPacket.UniPacketHeadSize);
			using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
			{
				binaryWriter.Write(ByteConverter.ReverseEndian(num + UniPacket.UniPacketHeadSize));
				binaryWriter.Write(jceBufArray);
			}
			return memoryStream.ToArray();
		}

		public new void Decode(byte[] buffer, int Index = 0)
		{
			if (buffer.Length < UniPacket.UniPacketHeadSize)
			{
				throw new ArgumentException("Decode namespace must include size head");
			}
			try
			{
				JceInputStream jceInputStream = new JceInputStream(buffer, UniPacket.UniPacketHeadSize + Index);
				jceInputStream.setServerEncoding(base.EncodeName);
				this.ReadFrom(jceInputStream);
				this._iVer = this._package.iVersion;
				jceInputStream = new JceInputStream(this._package.sBuffer);
				jceInputStream.setServerEncoding(base.EncodeName);
				if (this._package.iVersion == (short)Const.PACKET_TYPE_WUP)
				{
					this._data = (Dictionary<string, Dictionary<string, byte[]>>)jceInputStream.readMap<Dictionary<string, Dictionary<string, byte[]>>>(0, false);
				}
				else
				{
					this._new_data = (Dictionary<string, byte[]>)jceInputStream.readMap<Dictionary<string, byte[]>>(0, false);
				}
			}
			catch (Exception ex)
			{
				QTrace.Trace(this + " Decode Exception: " + ex.Message);
				throw ex;
			}
		}

		public override void WriteTo(JceOutputStream _os)
		{
			this._package.WriteTo(_os);
		}

		public override void ReadFrom(JceInputStream _is)
		{
			this._package.ReadFrom(_is);
		}

		public byte[] CreateOldRespEncode()
		{
			JceOutputStream expr_06 = new JceOutputStream(0);
			expr_06.setServerEncoding(base.EncodeName);
			expr_06.Write(this._data, 0);
			byte[] jceBufArray = JceUtil.getJceBufArray(expr_06.getMemoryStream());
			JceOutputStream expr_31 = new JceOutputStream(0);
			expr_31.setServerEncoding(base.EncodeName);
			expr_31.Write(this._package.iVersion, 1);
			expr_31.Write(this._package.cPacketType, 2);
			expr_31.Write(this._package.iRequestId, 3);
			expr_31.Write(this._package.iMessageType, 4);
			expr_31.Write(this.OldRespIRet, 5);
			expr_31.Write(jceBufArray, 6);
			expr_31.Write(this._package.status, 7);
			return JceUtil.getJceBufArray(expr_31.getMemoryStream());
		}
	}
}
