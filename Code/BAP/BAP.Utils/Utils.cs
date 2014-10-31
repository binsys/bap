using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BAP.Utils
{
	public class Utils
	{
		static readonly Dictionary<Type, UInt32> sizeofCache = new Dictionary<Type, UInt32>();

		/// <summary>
		/// 计算值类型对象非托管大小
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static UInt32 SizeOf<T>() where T : struct
		{
			Type outputType = typeof(T).IsEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);

			if (!sizeofCache.ContainsKey(outputType))
			{
				sizeofCache.Add(outputType, (UInt32)Marshal.SizeOf(outputType));
			}
			return sizeofCache[outputType];
		}

		public static UInt32 SizeOf(Type t)
		{
			Type outputType = t.IsEnum ? Enum.GetUnderlyingType(t) : t;
			if (!sizeofCache.ContainsKey(outputType))
			{
				sizeofCache.Add(outputType, (UInt32)Marshal.SizeOf(outputType));
			}

			return sizeofCache[outputType];
		}

		/// <summary>
		/// 字节数组转为值类型
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public static T BytesToValueType<T>(byte[] data) where T : struct
		{
			Type outputType = typeof(T).IsEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);

			//unsafe
			//{
			//	fixed (byte* p = data)
			//	{
			//		return (T)Marshal.PtrToStructure(new IntPtr(p), outputType);
			//	}
			//}

			GCHandle handle = GCHandle.Alloc(data, GCHandleType.Pinned);
			T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), outputType);
			handle.Free();
			return theStructure;
		}

		//public static T ReadStruct<T>(this BinaryReader reader) where T : struct
		//{
		//	var type = typeof(T).IsEnum ? Enum.GetUnderlyingType(typeof(T)) : typeof(T);
		//	byte[] bytes = reader.ReadBytes((int)Utils.SizeOf<T>());
		//	// Pin the managed memory while, copy it out the data, then unpin it
		//	GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
		//	T theStructure = (T)Marshal.PtrToStructure(handle.AddrOfPinnedObject(), type);
		//	handle.Free();
		//	return theStructure;
		//}
	}
}
