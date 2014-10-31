using System;
using System.Diagnostics;

namespace BAP.Loader.MachO
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/mach_header_64
	/// <seealso cref="mach_header"/>
	/// </summary>
	public struct mach_header_64
	{

		static mach_header_64()
		{
			Debug.Assert(Utils.Utils.SizeOf<mach_header_64>() == 0x20);
		}

		public UInt32 magic;

		public cpu_type_t cputype;

		public cpu_subtype_t cpusubtype;

		public filetype filetype;

		public UInt32 ncmds;

		public UInt32 sizeofcmds;

		public fileflag flags;

		public UInt32 reserved;
	}
}