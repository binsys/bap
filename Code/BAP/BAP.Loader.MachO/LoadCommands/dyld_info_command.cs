using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{

	/// <summary>
	/// LC_DYLD_INFO or LC_DYLD_INFO_ONLY
	/// loader.h
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct dyld_info_command
	{
		public LC cmd;              /* LC_DYLD_INFO or LC_DYLD_INFO_ONLY */
		public UInt32 cmdsize;          /* sizeof(struct dyld_info_command) */
		public UInt32 rebase_off;      /* file offset to rebase info  */
		public UInt32 rebase_size;     /* size of rebase info   */
		public UInt32 bind_off;        /* file offset to binding info   */
		public UInt32 bind_size;       /* size of binding info  */
		public UInt32 weak_bind_off;   /* file offset to weak binding info   */
		public UInt32 weak_bind_size;  /* size of weak binding info  */
		public UInt32 lazy_bind_off;   /* file offset to lazy binding info */
		public UInt32 lazy_bind_size;  /* size of lazy binding infs */
		public UInt32 export_off;      /* file offset to lazy binding info */
		public UInt32 export_size;     /* size of lazy binding infs */
	}
}
