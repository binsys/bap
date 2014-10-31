using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	/// <summary>
	/// Export Directory Table
	/// The export symbol information begins with the export directory table, which describes the remainder of the export symbol information. 
	/// The export directory table contains address information that is used to resolve imports to the entry points within this image.
	/// </summary>
	[StructLayout(LayoutKind.Explicit,Pack = 1)]
	public struct IMAGE_EXPORT_DIRECTORY_TABLE
	{
		/// <summary>
		/// Reserved, must be 0.
		/// </summary>
		[FieldOffset(0)]
		public UInt32 ExportFlags;

		/// <summary>
		/// The time and date that the export data was created.
		/// </summary>
		[FieldOffset(4)]
		public UInt32 TimeDateStamp;

		/// <summary>
		/// The major version number. 
		/// The major and minor version numbers can be set by the user.
		/// </summary>
		[FieldOffset(8)]
		public UInt16 MajorVersion;

		/// <summary>
		/// The minor version number.
		/// </summary>
		[FieldOffset(10)]
		public UInt16 MinorVersion;

		/// <summary>
		/// The address of the ASCII string that contains the name of the DLL. 
		/// This address is relative to the image base.
		/// </summary>
		[FieldOffset(12)]
		public UInt32 NameRVA;

		/// <summary>
		/// The starting ordinal number for exports in this image. 
		/// This field specifies the starting ordinal number for the export address table. 
		/// It is usually set to 1.
		/// </summary>
		[FieldOffset(16)]
		public UInt32 OrdinalBase;

		/// <summary>
		/// The number of entries in the export address table.
		/// </summary>
		[FieldOffset(20)]
		public UInt32 AddressTableEntries;

		/// <summary>
		/// The number of entries in the name pointer table. 
		/// This is also the number of entries in the ordinal table.
		/// </summary>
		[FieldOffset(24)]
		public UInt32 NumberOfNamePointers;

		/// <summary>
		/// The address of the export address table, relative to the image base.
		/// </summary>
		[FieldOffset(28)]
		public UInt32 ExportAddressTableRVA;

		/// <summary>
		/// The address of the export name pointer table, relative to the image base. 
		/// The table size is given by the Number of Name Pointers field.
		/// </summary>
		[FieldOffset(32)]
		public UInt32 NamePointerRVA;

		/// <summary>
		/// The address of the ordinal table, relative to the image base.
		/// </summary>
		[FieldOffset(36)]
		public UInt32 OrdinalTableRVA;
	}
}