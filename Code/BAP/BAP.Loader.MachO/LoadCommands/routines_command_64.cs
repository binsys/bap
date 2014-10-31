using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/routines_command_64
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct routines_command_64 : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
		public UInt64 init_address;
		public UInt64 init_module;
		public UInt64 reserved1;
		public UInt64 reserved2;
		public UInt64 reserved3;
		public UInt64 reserved4;
		public UInt64 reserved5;
		public UInt64 reserved6;
	}
}
