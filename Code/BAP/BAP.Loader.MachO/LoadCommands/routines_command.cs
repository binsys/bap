using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/routines_command
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct routines_command : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
		public UInt32 init_address;
		public UInt32 init_module;
		public UInt32 reserved1;
		public UInt32 reserved2;
		public UInt32 reserved3;
		public UInt32 reserved4;
		public UInt32 reserved5;
		public UInt32 reserved6;
	}
}
