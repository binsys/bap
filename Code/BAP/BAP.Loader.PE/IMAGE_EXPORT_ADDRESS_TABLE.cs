using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	/// <summary>
	/// Export Address Table
	/// 
	/// The export address table contains the address of exported entry points and exported data and absolutes. 
	/// An ordinal number is used as an index into the export address table.
	/// 
	/// Each entry in the export address table is a field that uses one of two formats in the following table. 
	/// If the address specified is not within the export section (as defined by the address and length that are indicated in the optional header), 
	/// the field is an export RVA, which is an actual address in code or data. Otherwise, 
	/// the field is a forwarder RVA, which names a symbol in another DLL.
	/// 
	/// A forwarder RVA exports a definition from some other image, making it appear as if it were being exported by the current image. 
	/// Thus, the symbol is simultaneously imported and exported.
	/// 
	/// For example, in Kernel32.dll in Windows XP, the export named “HeapAlloc” is forwarded to the string “NTDLL.RtlAllocateHeap.” 
	/// This allows applications to use the Windows XP–specific module Ntdll.dll without actually containing import references to it. 
	/// The application’s import table refers only to Kernel32.dll. 
	/// Therefore, the application is not specific to Windows XP and can run on any Win32 system.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_EXPORT_ADDRESS_TABLE
	{
		/// <summary>
		/// The address of the exported symbol when loaded into memory, relative to the image base. For example, the address of an exported function.
		/// </summary>
		[FieldOffset(0)]
		public UInt32 ExportRVA;

		/// <summary>
		/// The pointer to a null-terminated ASCII string in the export section. 
		/// This string must be within the range that is given by the export table data directory entry. 
		/// See section 3.4.3, “Optional Header Data Directories (Image Only).” 
		/// This string gives the DLL name and the name of the export (for example, “MYDLL.expfunc”) or 
		/// the DLL name and the ordinal number of the export (for example, “MYDLL.#27”).
		/// </summary>
		[FieldOffset(0)]
		public UInt32 ForwarderRVA;
	}
}