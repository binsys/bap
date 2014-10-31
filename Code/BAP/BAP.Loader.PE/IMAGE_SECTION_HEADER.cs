﻿using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	/// <summary>
	/// Section Table (Section Headers)
	/// 
	/// Each row of the section table is, in effect, a section header. 
	/// This table immediately follows the optional header, if any. 
	/// This positioning is required because the file header does not contain a direct pointer to the section table. 
	/// Instead, the location of the section table is determined by calculating the location of the first byte after the headers. 
	/// Make sure to use the size of the optional header as specified in the file header.
	/// 
	/// The number of entries in the section table is given by the NumberOfSections field in the file header. 
	/// Entries in the section table are numbered starting from one (1). 
	/// The code and data memory section entries are in the order chosen by the linker.
	/// 
	/// In an image file, the VAs for sections must be assigned by the linker so that they are in ascending order and adjacent, 
	/// and they must be a multiple of the SectionAlignment value in the optional header.
	/// 
	/// Each section header (section table entry) has the following format, for a total of 40 bytes per entry.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_SECTION_HEADER
	{
		/// <summary>
		/// An 8-byte, null-padded UTF-8 encoded string. 
		/// If the string is exactly 8 characters long, there is no terminating null. 
		/// For longer names, this field contains a slash (/) that is followed by an ASCII representation of a decimal number that is an offset into the string table. 
		/// Executable images do not use a string table and do not support section names longer than 8 characters. 
		/// Long names in object files are truncated if they are emitted to an executable file.
		/// </summary>
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public char[] Name;

		/// <summary>
		/// The total size of the section when loaded into memory. 
		/// If this value is greater than SizeOfRawData, the section is zero-padded. 
		/// This field is valid only for executable images and should be set to zero for object files.
		/// </summary>
		[FieldOffset(8)]
		public UInt32 VirtualSize;

		/// <summary>
		/// For executable images, the address of the first byte of the section relative to the image base when the section is loaded into memory. 
		/// For object files, this field is the address of the first byte before relocation is applied; 
		/// for simplicity, compilers should set this to zero. Otherwise, it is an arbitrary value that is subtracted from offsets during relocation.
		/// </summary>
		[FieldOffset(12)]
		public UInt32 VirtualAddress;

		/// <summary>
		/// The size of the section (for object files) or the size of the initialized data on disk (for image files). 
		/// For executable images, this must be a multiple of FileAlignment from the optional header. 
		/// If this is less than VirtualSize, the remainder of the section is zero-filled. Because the SizeOfRawData field is rounded but the VirtualSize field is not, 
		/// it is possible for SizeOfRawData to be greater than VirtualSize as well. When a section contains only uninitialized data, this field should be zero.
		/// </summary>
		[FieldOffset(16)]
		public UInt32 SizeOfRawData;

		/// <summary>
		/// The file pointer to the first page of the section within the COFF file. 
		/// For executable images, this must be a multiple of FileAlignment from the optional header. 
		/// For object files, the value should be aligned on a 4 byte boundary for best performance. 
		/// When a section contains only uninitialized data, this field should be zero.
		/// </summary>
		[FieldOffset(20)]
		public UInt32 PointerToRawData;

		/// <summary>
		/// The file pointer to the beginning of relocation entries for the section. 
		/// This is set to zero for executable images or if there are no relocations.
		/// </summary>
		[FieldOffset(24)]
		public UInt32 PointerToRelocations;

		/// <summary>
		/// The file pointer to the beginning of line-number entries for the section. 
		/// This is set to zero if there are no COFF line numbers. 
		/// This value should be zero for an image because COFF debugging information is deprecated.
		/// </summary>
		[FieldOffset(28)]
		public UInt32 PointerToLinenumbers;

		/// <summary>
		/// The number of relocation entries for the section. 
		/// This is set to zero for executable images.
		/// </summary>
		[FieldOffset(32)]
		public UInt16 NumberOfRelocations;

		/// <summary>
		/// The number of line-number entries for the section. 
		/// This value should be zero for an image because COFF debugging information is deprecated.
		/// </summary>
		[FieldOffset(34)]
		public UInt16 NumberOfLinenumbers;

		/// <summary>
		/// The flags that describe the characteristics of the section. 
		/// For more information, see section 4.1, “Section Flags.”
		/// </summary>
		[FieldOffset(36)]
		public IMAGE_SCN Characteristics;

		public string Section
		{
			get { return new string(Name).TrimEnd('\0'); }
		}
	}
}