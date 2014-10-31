using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/lc_str
	/// union lc_str
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct lc_str
	{
		[FieldOffset(0)]
		public UInt32 offset;

		[FieldOffset(0)]
		public UInt32 ptr;
	}
}