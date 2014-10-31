using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace BAP.Utils
{
	public static class BinaryReaderExt
	{



		/// <summary>
		/// 读取值类型数组数据
		/// </summary>
		/// <typeparam name="TItemType"></typeparam>
		/// <param name="dest"></param>
		/// <returns></returns>
		public static bool Read<TItemType>(this BinaryReader br, ref TItemType[] dest) where TItemType : struct
		{
			for (int i = 0; i < dest.Length; i++)
			{
				if (!br.Read(ref dest[i]))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// 读取值类型数据
		/// </summary>
		/// <typeparam name="TItemType"></typeparam>
		/// <param name="dest"></param>
		/// <returns></returns>
		public static bool Read<TItemType>(this BinaryReader br, ref TItemType dest) where TItemType : struct
		{
			UInt32 byteSize = Utils.SizeOf<TItemType>();

			//if (byteSize > this.BytesLeft)
			//	return false;

			UInt32 bytesRead = 0;

			byte[] destBytes = new byte[byteSize];

			bool result = br.ReadBytes(destBytes, byteSize, out bytesRead);

			if (result && byteSize == bytesRead)
			{
				dest = Utils.BytesToValueType<TItemType>(destBytes);
				return true;
			}

			return false;
		}

		/// <summary>
		/// 读取字节数量
		/// </summary>
		/// <param name="dest"></param>
		/// <param name="bytesCount"></param>
		/// <param name="bytesRead"></param>
		/// <returns></returns>
		public static bool ReadBytes(this BinaryReader br, byte[] dest, UInt32 bytesCount, out UInt32 bytesRead)
		{
			var outbytes = br.ReadBytes((int)bytesCount);
			Buffer.BlockCopy(outbytes, 0, dest, 0, outbytes.Length);
			bytesRead = (uint)outbytes.Length;

			return true;
		}

		public static string ReadCString(this BinaryReader br)
		{
			List<byte> chars = new List<byte>();


			byte curr = 0;

			while ((curr = br.ReadByte()) != 0)
			{
				chars.Add(curr);
			}
			return Encoding.ASCII.GetString(chars.ToArray());
		}
	}
}
