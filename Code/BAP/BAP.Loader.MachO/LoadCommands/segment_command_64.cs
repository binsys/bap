using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BAP.Loader.MachO.LoadCommands
{

	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/section_64
	/// <seealso cref="section"/>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct section_64
	{
		static section_64()
		{
			Debug.Assert(Utils.Utils.SizeOf<section_64>() == 0x50);
		}
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] sectname;

		[FieldOffset(16)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] segname;

		[FieldOffset(32)]
		public UInt64 addr;

		[FieldOffset(40)]
		public UInt64 size;

		[FieldOffset(48)]
		public UInt32 offset;

		[FieldOffset(52)]
		public UInt32 align;

		[FieldOffset(56)]
		public UInt32 reloff;

		[FieldOffset(60)]
		public UInt32 nreloc;

		[FieldOffset(64)]
		public UInt32 flags;

		[FieldOffset(68)]
		public UInt32 reserved1;

		[FieldOffset(72)]
		public UInt32 reserved2;
	}

	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/segment_command_64
	/// <seealso cref="segment_command"/>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct segment_command_64 : ILoadCommand
	{

		static segment_command_64()
		{
			Debug.Assert(Utils.Utils.SizeOf<segment_command_64>() == 0x48);
		}

		[FieldOffset(0)]
		public LC cmd;

		[FieldOffset(4)]
		public UInt32 cmdsize;

		[FieldOffset(8)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] segname;

		[FieldOffset(24)]
		public UInt64 vmaddr;

		[FieldOffset(32)]
		public UInt64 vmsize;

		[FieldOffset(40)]
		public UInt64 fileoff;

		[FieldOffset(48)]
		public UInt64 filesize;

		[FieldOffset(56)]
		public vm_prot_t maxprot;

		[FieldOffset(60)]
		public vm_prot_t initprot;

		[FieldOffset(64)]
		public UInt32 nsects;

		[FieldOffset(68)]
		public UInt32 flags;
	}
}
