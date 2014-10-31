using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BAP.Loader.MachO.LoadCommands
{

	/// <summary>
	/// LC_VERSION_MIN_MACOSX LC_VERSION_MIN_IPHONEOS
	/// loader.h
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct version_min_command
	{
		public LC cmd;
		public UInt32 cmdsize;        /* sizeof(struct min_version_command) */
		public UInt32 version;        /* X.Y.Z is encoded in nibbles xxxx.yy.zz */
		public UInt32 sdk;            /* X.Y.Z is encoded in nibbles xxxx.yy.zz */
	}
}
