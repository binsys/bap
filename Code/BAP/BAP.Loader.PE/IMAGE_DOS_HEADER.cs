using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{

	/*
*    USHORT e_magic;    // 魔术数字
*    USHORT e_cblp;     // 文件最后页的字节数
*    USHORT e_cp;       // 文件页数
*    USHORT e_crlc;     // 重定义元素个数
*    USHORT e_cparhdr;  // 头部尺寸，以段落为单位
*    USHORT e_minalloc; // 所需的最小附加段
*    USHORT e_maxalloc; // 所需的最大附加段
*    USHORT e_ss;       // 初始的SS值（相对偏移量）
*    USHORT e_sp;       // 初始的SP值
*    USHORT e_csum;     // 校验和
*    USHORT e_ip;       // 初始的IP值
*    USHORT e_cs;       // 初始的CS值（相对偏移量）
*    USHORT e_lfarlc;   // 重分配表文件地址
*    USHORT e_ovno;     // 覆盖号
*    USHORT e_res[4];   // 保留字
*    USHORT e_oemid;    // OEM标识符（相对e_oeminfo）
*    USHORT e_oeminfo;  // OEM信息
*    USHORT e_res2[10]; // 保留字
*    LONG e_lfanew;     // 新exe头部的文件地址
 */


	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct IMAGE_DOS_HEADER
	{
		static IMAGE_DOS_HEADER()
		{
			Debug.Assert(Utils.Utils.SizeOf<IMAGE_DOS_HEADER>() == 0x40);
		}

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public char[] e_magic;       // Magic number
		public UInt16 e_cblp;        // Bytes on last page of file
		public UInt16 e_cp;          // Pages in file
		public UInt16 e_crlc;        // Relocations
		public UInt16 e_cparhdr;     // Size of header in paragraphs
		public UInt16 e_minalloc;    // Minimum extra paragraphs needed
		public UInt16 e_maxalloc;    // Maximum extra paragraphs needed
		public UInt16 e_ss;          // Initial (relative) SS value
		public UInt16 e_sp;          // Initial SP value
		public UInt16 e_csum;        // Checksum
		public UInt16 e_ip;          // Initial IP value
		public UInt16 e_cs;          // Initial (relative) CS value
		public UInt16 e_lfarlc;      // File address of relocation table
		public UInt16 e_ovno;        // Overlay number

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public UInt16[] e_res1;      // Reserved words
		public UInt16 e_oemid;       // OEM identifier (for e_oeminfo)
		public UInt16 e_oeminfo;     // OEM information; e_oemid specific

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public UInt16[] e_res2;      // Reserved words
		public Int32 e_lfanew;       // File address of new exe header

		public bool IsValid
		{
			get { return e_magic[0] == 'M' && e_magic[1] == 'Z'; }
		}

	}
}