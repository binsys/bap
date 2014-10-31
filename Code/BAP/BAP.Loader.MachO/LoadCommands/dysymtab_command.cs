using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/dysymtab_command
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct dysymtab_command : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
		public UInt32 ilocalsym;
		public UInt32 nlocalsym;
		public UInt32 iextdefsym;
		public UInt32 nextdefsym;
		public UInt32 iundefsym;
		public UInt32 nundefsym;
		public UInt32 tocoff;
		public UInt32 ntoc;
		public UInt32 modtaboff;
		public UInt32 nmodtab;
		public UInt32 extrefsymoff;
		public UInt32 nextrefsyms;
		public UInt32 indirectsymoff;
		public UInt32 nindirectsyms;
		public UInt32 extreloff;
		public UInt32 nextrel;
		public UInt32 locreloff;
		public UInt32 nlocrel;
	}
}
