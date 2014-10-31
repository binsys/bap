using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	/// <summary>
	/// Each data directory gives the address and size of a table or string that Windows uses. 
	/// These data directory entries are all loaded into memory so that the system can use them at run time. 
	/// A data directory is an 8 byte field that has the following declaration.
	/// 
	/// The first field, VirtualAddress, is actually the RVA of the table. 
	/// The RVA is the address of the table relative to the base address of the image when the table is loaded. 
	/// The second field gives the size in bytes. 
	/// The data directories, which form the last part of the optional header, are listed in the following table.
	/// 
	/// Note that the number of directories is not fixed. 
	/// Before looking for a specific directory, check the NumberOfRvaAndSizes field in the optional header.
	/// 
	/// Also, do not assume that the RVAs in this table point to the beginning of a section or that the sections that contain specific tables have specific names.
	/// 

	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_DATA_DIRECTORY
	{
		public UInt32 VirtualAddress;
		public UInt32 Size;

		public bool IsZero
		{
			get
			{
				return VirtualAddress != 0 && Size != 0;
			}
		}
	}
}