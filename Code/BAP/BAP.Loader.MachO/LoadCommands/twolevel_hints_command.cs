using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{

	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/twolevel_hint
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct twolevel_hint
	{
		/// <summary>
		/// :8
		/// </summary>
		[FieldOffset(0)] 
		public byte isub_image;

		/// <summary>
		/// :24
		/// </summary>
		[FieldOffset(1)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
		public byte[] itoc;
	}

	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/twolevel_hints_command
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct twolevel_hints_command : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
		public UInt32 offset;
		public UInt32 nhints;
	}
}
