using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/symtab_command
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct symtab_command : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
		public UInt32 symoff;
		public UInt32 nsyms;
		public UInt32 stroff;
		public UInt32 strsize;
	}
}
