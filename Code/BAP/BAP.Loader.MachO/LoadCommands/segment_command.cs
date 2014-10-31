using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BAP.Loader.MachO.LoadCommands
{

	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/section
	/// <seealso cref="section_64"/>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct section
	{
		static section()
		{
			Debug.Assert(Utils.Utils.SizeOf<section>() == 0x44);
		}

		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] sectname;

		[FieldOffset(16)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] segname;

		[FieldOffset(32)]
		public UInt32 addr;

		[FieldOffset(36)]
		public UInt32 size;

		[FieldOffset(40)]
		public UInt32 offset;

		[FieldOffset(44)]
		public UInt32 align;

		[FieldOffset(48)]
		public UInt32 reloff;

		[FieldOffset(52)]
		public UInt32 nreloc;

		[FieldOffset(56)]
		public UInt32 flags;

		[FieldOffset(60)]
		public UInt32 reserved1;

		[FieldOffset(64)]
		public UInt32 reserved2;
	}

	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/segment_command
	/// <seealso cref="segment_command_64"/>
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct segment_command : ILoadCommand
	{

		static segment_command()
		{
			Debug.Assert(Utils.Utils.SizeOf<segment_command>() == 0x38);
		}

		[FieldOffset(0)]
		public LC cmd;

		[FieldOffset(4)]
		public UInt32 cmdsize;

		[FieldOffset(8)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public char[] segname;

		[FieldOffset(24)]
		public UInt32 vmaddr;

		[FieldOffset(28)]
		public UInt32 vmsize;

		[FieldOffset(32)]
		public UInt32 fileoff;

		[FieldOffset(36)]
		public UInt32 filesize;

		[FieldOffset(40)]
		public vm_prot_t maxprot;

		[FieldOffset(44)]
		public vm_prot_t initprot;

		[FieldOffset(48)]
		public UInt32 nsects;

		[FieldOffset(52)]
		public UInt32 flags;
	}
}