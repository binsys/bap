using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/uuid_command
	/// </summary>
	public struct uuid_command : ILoadCommand
	{
		public LC cmd;

		public UInt32 cmdsize;

		//[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		//public byte[] uuid;

		public Guid uuid;
	}
}