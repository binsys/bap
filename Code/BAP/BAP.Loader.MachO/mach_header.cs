using System;
using System.Diagnostics;

namespace BAP.Loader.MachO
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/mach_header
	/// <seealso cref="mach_header_64"/>
	/// </summary>
	public struct mach_header
	{

		static mach_header()
		{
			Debug.Assert(Utils.Utils.SizeOf<mach_header>() == 0x1c);
		}

		public UInt32 magic;

		public cpu_type_t cputype;

		public cpu_subtype_t cpusubtype;

		public filetype filetype;

		public UInt32 ncmds;

		public UInt32 sizeofcmds;

		public fileflag flags;
	}
}
