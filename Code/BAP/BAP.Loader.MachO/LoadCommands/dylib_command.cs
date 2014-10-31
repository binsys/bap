
//#define __LP64__

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/dylib
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct dylib
	{
		[FieldOffset(0)]
		public lc_str  name;

		[FieldOffset(4)]
		public UInt32 timestamp;

		[FieldOffset(8)]
		public UInt32 current_version;

		[FieldOffset(12)]
		public UInt32 compatibility_version;
	}


	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/dylib_command
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct dylib_command : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
		public dylib dylib;
	}
}
