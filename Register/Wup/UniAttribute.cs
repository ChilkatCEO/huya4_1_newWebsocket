using System;
using System.Collections;
using System.Collections.Generic;
using Wup.Jce;

namespace Wup
{
	public class UniAttribute : JceStruct
	{
		protected Dictionary<string, Dictionary<string, byte[]>> _data;

		protected Dictionary<string, byte[]> _new_data;

		private Dictionary<string, object> cachedData = new Dictionary<string, object>(128);

		protected short _iVer = (short)Const.PACKET_TYPE_WUP;

		private string _encodeName = "UTF-8";

		private JceInputStream _is = new JceInputStream();

		public short Version
		{
			get
			{
				return this._iVer;
			}
			set
			{
				this._iVer = value;
			}
		}

		public string EncodeName
		{
			get
			{
				return this._encodeName;
			}
			set
			{
				this._encodeName = value;
			}
		}

		public int Size
		{
			get
			{
				if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
				{
					return this._new_data.Count;
				}
				return this._data.Count;
			}
		}

		public UniAttribute()
		{
			this._data = new Dictionary<string, Dictionary<string, byte[]>>();
			this._new_data = new Dictionary<string, byte[]>();
		}

		public void ClearCacheData()
		{
			this.cachedData.Clear();
		}

		public bool IsEmpty()
		{
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				return this._new_data.Count == 0;
			}
			return this._data.Count == 0;
		}

		public bool ContainsKey(string key)
		{
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				return this._new_data.ContainsKey(key);
			}
			return this._data.ContainsKey(key);
		}

		public void Put<T>(string name, T t)
		{
			if (name == null)
			{
				throw new ArgumentException("put key can not is null");
			}
			if (t == null)
			{
				throw new ArgumentException("put value can not is null");
			}
			JceOutputStream expr_26 = new JceOutputStream();
			expr_26.setServerEncoding(this._encodeName);
			expr_26.Write(t, 0);
			byte[] jceBufArray = JceUtil.getJceBufArray(expr_26.getMemoryStream());
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				this.cachedData.Remove(name);
				if (this._new_data.ContainsKey(name))
				{
					this._new_data[name] = jceBufArray;
					return;
				}
				this._new_data.Add(name, jceBufArray);
				return;
			}
			else
			{
				List<string> listTpye = new List<string>();
				this.CheckObjectType(listTpye, t);
				string key = BasicClassTypeUtil.TransTypeList(listTpye);
				Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>(1);
				dictionary.Add(key, jceBufArray);
				this.cachedData.Remove(name);
				if (this._data.ContainsKey(name))
				{
					this._data[name] = dictionary;
					return;
				}
				this._data.Add(name, dictionary);
				return;
			}
		}

		private object decodeData(byte[] data, object proxy)
		{
			this._is.wrap(data, 0);
			this._is.setServerEncoding(this._encodeName);
			return this._is.read(proxy, 0, true);
		}

		public T getByClass<T>(string name, T proxy)
		{
			object obj = null;
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				if (!this._new_data.ContainsKey(name))
				{
					return (T)((object)obj);
				}
				if (this.cachedData.ContainsKey(name))
				{
					if (!this.cachedData.TryGetValue(name, out obj))
					{
						obj = null;
					}
					return (T)((object)obj);
				}
				try
				{
					byte[] data = new byte[0];
					this._new_data.TryGetValue(name, out data);
					object obj2 = this.decodeData(data, proxy);
					if (obj2 != null)
					{
						this.SaveDataCache(name, obj2);
					}
					return (T)((object)obj2);
				}
				catch (Exception arg_84_0)
				{
					throw new ObjectCreateException(arg_84_0);
				}
			}
			return this.Get<T>(name);
		}

		public T Get<T>(string name)
		{
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				throw new Exception("data is encoded by new version, please use getJceStruct(String name,T proxy)");
			}
			object obj = null;
			if (!this._data.ContainsKey(name))
			{
				return (T)((object)obj);
			}
			if (this.cachedData.ContainsKey(name))
			{
				if (!this.cachedData.TryGetValue(name, out obj))
				{
					obj = null;
				}
				return (T)((object)obj);
			}
			Dictionary<string, byte[]> dictionary;
			this._data.TryGetValue(name, out dictionary);
			string text = null;
			byte[] data = new byte[0];
			foreach (KeyValuePair<string, byte[]> current in dictionary)
			{
				text = current.Key;
				data = current.Value;
				if (text != null && !(text == string.Empty))
				{
					string text2 = BasicClassTypeUtil.CS2UniType(typeof(T).ToString());
					if (text.Length > 0 && text == text2)
					{
						break;
					}
					if (text2 == "map" && text.Length >= 3 && text.Substring(0, 3).ToLower() == "map")
					{
						break;
					}
					if (typeof(T).IsArray && text.Length > 3 && text.Substring(0, 4).ToLower() == "list")
					{
						break;
					}
					if (text2 == "list" && text.Length > 3 && text.Substring(0, 4).ToLower() == "list")
					{
						break;
					}
				}
			}
			T result;
			try
			{
				object cacheProxy = this.GetCacheProxy<T>(text);
				if (cacheProxy == null)
				{
					result = (T)((object)cacheProxy);
				}
				else
				{
					obj = this.decodeData(data, cacheProxy);
					if (obj != null)
					{
						this.SaveDataCache(name, obj);
					}
					result = (T)((object)obj);
				}
			}
			catch (Exception ex)
			{
				QTrace.Trace(this + " Get Exception: " + ex.Message);
				throw new ObjectCreateException(ex);
			}
			return result;
		}

		public T Get<T>(string Name, T DefaultObj)
		{
			T result;
			try
			{
				object obj;
				if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
				{
					obj = this.getByClass<T>(Name, DefaultObj);
				}
				else
				{
					obj = this.Get<T>(Name);
				}
				if (obj == null)
				{
					result = DefaultObj;
				}
				else
				{
					result = (T)((object)obj);
				}
			}
			catch (Exception)
			{
				result = DefaultObj;
			}
			return result;
		}

		private object GetCacheProxy<T>(string className)
		{
			return BasicClassTypeUtil.CreateObject<T>();
		}

		private void SaveDataCache(string name, object o)
		{
			this.cachedData.Add(name, o);
		}

		private void CheckObjectType(List<string> listTpye, object o)
		{
			if (o == null)
			{
				throw new Exception("object is null");
			}
			if (o.GetType().IsArray)
			{
				Type elementType = o.GetType().GetElementType();
				listTpye.Add("list");
				this.CheckObjectType(listTpye, BasicClassTypeUtil.CreateObject(elementType));
				return;
			}
			if (!(o is IList))
			{
				if (o is IDictionary)
				{
					listTpye.Add("map");
					IDictionary dictionary = (IDictionary)o;
					if (dictionary.Count > 0)
					{
						IEnumerator enumerator = dictionary.Keys.GetEnumerator();
						try
						{
							if (!enumerator.MoveNext())
							{
								return;
							}
							object current = enumerator.Current;
							listTpye.Add(BasicClassTypeUtil.CS2UniType(current.GetType().ToString()));
							this.CheckObjectType(listTpye, dictionary[current]);
							return;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							if (disposable != null)
							{
								disposable.Dispose();
							}
						}
					}
					listTpye.Add("?");
					listTpye.Add("?");
					return;
				}
				listTpye.Add(BasicClassTypeUtil.CS2UniType(o.GetType().ToString()));
				return;
			}
			listTpye.Add("list");
			IList list = (IList)o;
			if (list.Count > 0)
			{
				this.CheckObjectType(listTpye, list[0]);
				return;
			}
			listTpye.Add("?");
		}

		public byte[] Encode()
		{
			JceOutputStream jceOutputStream = new JceOutputStream(0);
			jceOutputStream.setServerEncoding(this._encodeName);
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				jceOutputStream.Write(this._new_data, 0);
			}
			else
			{
				jceOutputStream.Write(this._data, 0);
			}
			return JceUtil.getJceBufArray(jceOutputStream.getMemoryStream());
		}

		public void Decode(byte[] buffer, int Index = 0)
		{
			try
			{
				this._is.wrap(buffer, Index);
				this._is.setServerEncoding(this._encodeName);
				this._iVer = (short)Const.PACKET_TYPE_WUP;
				this._data = (Dictionary<string, Dictionary<string, byte[]>>)this._is.readMap<Dictionary<string, Dictionary<string, byte[]>>>(this._data, 0, false);
			}
			catch
			{
				this._iVer = (short)Const.PACKET_TYPE_WUP3;
				this._is.wrap(buffer, Index);
				this._is.setServerEncoding(this._encodeName);
				this._new_data = (Dictionary<string, byte[]>)this._is.readMap<Dictionary<string, byte[]>>(this._new_data, 0, false);
			}
		}

		public override void WriteTo(JceOutputStream _os)
		{
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				_os.Write(this._new_data, 0);
				return;
			}
			_os.Write(this._data, 0);
		}

		public override void ReadFrom(JceInputStream _is)
		{
			if (this._iVer == (short)Const.PACKET_TYPE_WUP3)
			{
				this._new_data = (Dictionary<string, byte[]>)_is.readMap<Dictionary<string, byte[]>>(this._new_data, 0, false);
				return;
			}
			this._data = (Dictionary<string, Dictionary<string, byte[]>>)_is.readMap<Dictionary<string, Dictionary<string, byte[]>>>(this._data, 0, false);
		}
	}
}
