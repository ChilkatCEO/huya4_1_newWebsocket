using System;
using System.Collections.Generic;
using System.IO;

namespace iHuya
{
    public class ProtoBase
    {
        protected ByteArray mBuffer;

        protected uint mUri;

        protected uint mRes = 200u;

        public void setUri(uint _arg1)
        {
            mUri = _arg1;
        }

        public uint getUri()
        {
            return mUri;
        }

        public uint getRes()
        {
            return mRes;
        }

        public byte[] getBuffer()
        {
            ByteArray ms = new ByteArray();
            ms.endian = Endian.LITTLE_ENDIAN;
            ms.writeInt( mBuffer.length+8);
            ms.writeShort(Convert.ToInt32(mUri));
            ms.writeShort(0);
            ms.MemoryStream.Write(mBuffer.Buffer,0, mBuffer.Buffer.Length);
            return ms.Buffer;
        }

        public virtual void marshall()
        {

            mBuffer = new ByteArray();
            mBuffer.endian =  Endian.LITTLE_ENDIAN;
        }

        public virtual void unmarshall(ByteArray _arg1)
        {
            mBuffer = _arg1;
        }

        public void pushBool(bool _arg1)
        {
            uint value = 0u;
            if (_arg1)
            {
                value = 1u;
            }
            mBuffer.writeByte(Convert.ToByte(value));
        }

        public void pushByte(uint _arg1)
        {
            mBuffer.writeByte(Convert.ToByte(_arg1));
        }

        public void pushShort(uint _arg1)
        {
            mBuffer.writeShort(Convert.ToUInt16(_arg1));
        }

        public void pushInt(uint _arg1)
        {
            mBuffer.writeUnsignedInt(_arg1);
        }
        public void pushInt(long _arg1)
        {
            mBuffer.writeUnsignedL(_arg1);
        }
        public void pushInt(int _arg1)
        {
            mBuffer.writeInt(_arg1);
        }

        public void pushBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                mBuffer.writeShort(0);
            }
            else
            {
                mBuffer.writeShort(bytes.Length);
                mBuffer.writeBytes(bytes);
            }
        }


     

        public void pushShortArray(List<uint> _arg1)
        {
            uint count = (uint)_arg1.Count;
            pushInt(count);
            for (uint num = 0u; num < count; num++)
            {
                mBuffer.writeShort((int)_arg1[(int)num]);
            }
        }

        public void pushIntArray(List<uint> _arg1)
        {
            uint count = (uint)_arg1.Count;
            pushInt(count);
            for (uint num = 0u; num < count; num++)
            {
                mBuffer.writeUnsignedInt(_arg1[(int)num]);
            }
        }


        public void pushStringArray(List<ByteArray> _arg1)
        {
            uint count = (uint)_arg1.Count;
            pushInt(count);
            for (uint num = 0u; num < count; num++)
            {
                pushBytes(_arg1[(int)num].Buffer);
            }
        }

        public bool popBool()
        {
            return mBuffer.readByte() != 0;
        }

        public uint popByte()
        {
            return (uint)(mBuffer.readByte() & 0xFF);
        }

        public uint popShort()
        {
            return mBuffer.readUnsignedShort();
        }

        public uint popInt()
        {
            return mBuffer.readUnsignedInt();
        }


        public List<uint> popIntArray()
        {
            uint num = popInt();
            List<uint> list = new List<uint>();
            for (uint num2 = 0u; num2 < num; num2++)
            {
                list[(int)num2] = popInt();
            }
            return list;
        }


        public List<uint> popShortArray()
        {
            uint num = popInt();
            List<uint> list = new List<uint>();
            for (uint num2 = 0u; num2 < num; num2++)
            {
                list[(int)num2] = popShort();
            }
            return list;
        }

        public byte[] popBytes()
        {
            uint num = popShort();
            byte[] result = null;
            using (ByteArray byteArray = new ByteArray())
            {
                if (num == 0)
                {
                    return result;
                }
                mBuffer.readBytes(byteArray, 0u, num);
                byteArray.position = 0;
                return byteArray.Buffer;
            }
        }

        public List<byte[]> popStringArray()
        {
            uint num = popInt();
            List<byte[]> list = new List<byte[]>();
            for (uint num2 = 0u; num2 < num; num2++)
            {
                list[(int)num2] = popBytes();
            }
            return list;
        }



        public T popProto<T>() where T : ProtoBase, new()
        {
            T val = new T();
            val.unmarshall(mBuffer);
            return val;
        }

        public List<T> popProtoArray<T>() where T : ProtoBase, new()
        {
            uint num = popInt();
            List<T> list = new List<T>();
            for (uint num2 = 0u; num2 < num; num2++)
            {
                list[(int)num2] = popProto<T>();
            }
            return list;
        }

  
    }
}
