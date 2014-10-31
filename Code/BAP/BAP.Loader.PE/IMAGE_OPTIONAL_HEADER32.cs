using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	/// <summary>
	/// Every image file has an optional header that provides information to the loader. 
	/// This header is optional in the sense that some files (specifically, object files) do not have it. 
	/// For image files, this header is required. 
	/// An object file can have an optional header, but generally this header has no function in an object file except to increase its size. 
	/// Note that the size of the optional header is not fixed. 
	/// The SizeOfOptionalHeader field in the COFF header must be used to validate that a probe into the file for a particular data directory does not go beyond SizeOfOptionalHeader. 
	/// For more information, see section 3.3, “COFF File Header (Object and Image).”
	/// 
	/// The NumberOfRvaAndSizes field of the optional header should also be used to ensure that no probe for a particular data directory entry goes beyond the optional header. 
	/// In addition, it is important to validate the optional header magic number for format compatibility.

	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_OPTIONAL_HEADER32
	{
		#region Optional Header Standard Fields (Image Only)

		// The first eight fields of the optional header are standard fields that are defined for every implementation of COFF. 
		// These fields contain general information that is useful for loading and running an executable file. 
		// They are unchanged for the PE32+ format.

		/// <summary>
		/// The unsigned integer that identifies the state of the image file. 
		/// The most common number is 0x10B, which identifies it as a normal executable file. 
		/// 0x107 identifies it as a ROM image, and 0x20B identifies it as a PE32+ executable.
		/// </summary>
		[FieldOffset(0)]
		public IMAGE_OPTIONAL_HEADER_MAGIC Magic;

		/// <summary>
		/// The linker major version number.
		/// </summary>
		[FieldOffset(2)]
		public byte MajorLinkerVersion;

		/// <summary>
		/// The linker minor version number.
		/// </summary>
		[FieldOffset(3)]
		public byte MinorLinkerVersion;

		/// <summary>
		/// The size of the code (text) section, or the sum of all code sections if there are multiple sections.
		/// </summary>
		[FieldOffset(4)]
		public uint SizeOfCode;

		/// <summary>
		/// The size of the initialized data section, or the sum of all such sections if there are multiple data sections.
		/// </summary>
		[FieldOffset(8)]
		public uint SizeOfInitializedData;

		/// <summary>
		/// The size of the uninitialized data section (BSS), or the sum of all such sections if there are multiple BSS sections.
		/// </summary>
		[FieldOffset(12)]
		public uint SizeOfUninitializedData;

		/// <summary>
		/// The address of the entry point relative to the image base when the executable file is loaded into memory. 
		/// For program images, this is the starting address. 
		/// For device drivers, this is the address of the initialization function. An entry point is optional for DLLs. 
		/// When no entry point is present, this field must be zero.
		/// </summary>
		[FieldOffset(16)]
		public uint AddressOfEntryPoint;

		/// <summary>
		/// The address that is relative to the image base of the beginning-of-code section when it is loaded into memory.
		/// </summary>
		[FieldOffset(20)]
		public uint BaseOfCode;

		#endregion

		#region PE32 Only
		// PE32 contains this additional field, which is absent in PE32+, following BaseOfCode.

		/// <summary>
		/// The address that is relative to the image base of the beginning-of-data section when it is loaded 
		/// </summary>
		[FieldOffset(24)]
		public uint BaseOfData;
		#endregion

		#region Optional Header Windows-Specific Fields (Image Only)

		/// <summary>
		/// The preferred address of the first byte of image when loaded into memory; 
		/// must be a multiple of 64 K. The default for DLLs is 0x10000000. 
		/// The default for Windows CE EXEs is 0x00010000. 
		/// The default for Windows NT, Windows 2000, Windows XP, Windows 95, Windows 98, and Windows Me is 0x00400000.
		/// </summary>
		[FieldOffset(28)]
		public uint ImageBase;

		/// <summary>
		/// The alignment (in bytes) of sections when they are loaded into memory. 
		/// It must be greater than or equal to FileAlignment. 
		/// The default is the page size for the architecture.
		/// </summary>
		[FieldOffset(32)]
		public uint SectionAlignment;

		/// <summary>
		/// The alignment factor (in bytes) that is used to align the raw data of sections in the image file. 
		/// The value should be a power of 2 between 512 and 64 K, inclusive. 
		/// The default is 512. 
		/// If the SectionAlignment is less than the architecture’s page size, then FileAlignment must match SectionAlignment.
		/// </summary>
		[FieldOffset(36)]
		public uint FileAlignment;

		/// <summary>
		/// The major version number of the required operating system.
		/// </summary>
		[FieldOffset(40)]
		public ushort MajorOperatingSystemVersion;

		/// <summary>
		/// The minor version number of the required operating system.
		/// </summary>
		[FieldOffset(42)]
		public ushort MinorOperatingSystemVersion;

		/// <summary>
		/// The major version number of the image.
		/// </summary>
		[FieldOffset(44)]
		public ushort MajorImageVersion;

		/// <summary>
		/// The minor version number of the image.
		/// </summary>
		[FieldOffset(46)]
		public ushort MinorImageVersion;

		/// <summary>
		/// The major version number of the subsystem.
		/// </summary>
		[FieldOffset(48)]
		public ushort MajorSubsystemVersion;

		/// <summary>
		/// The minor version number of the subsystem.
		/// </summary>
		[FieldOffset(50)]
		public ushort MinorSubsystemVersion;

		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		[FieldOffset(52)]
		public uint Win32VersionValue;

		/// <summary>
		/// The size (in bytes) of the image, including all headers, as the image is loaded in memory. 
		/// It must be a multiple of SectionAlignment.
		/// </summary>
		[FieldOffset(56)]
		public uint SizeOfImage;

		/// <summary>
		/// The combined size of an MS DOS stub, PE header, and section headers rounded up to a multiple of FileAlignment.
		/// </summary>
		[FieldOffset(60)]
		public uint SizeOfHeaders;

		/// <summary>
		/// The image file checksum. 
		/// The algorithm for computing the checksum is incorporated into IMAGHELP.DLL. 
		/// The following are checked for validation at load time: 
		/// all drivers, 
		/// any DLL loaded at boot time, 
		/// and any DLL that is loaded into a critical Windows process.
		/// </summary>
		[FieldOffset(64)]
		public uint CheckSum;

		/// <summary>
		/// The subsystem that is required to run this image. 
		/// For more information, see “Windows Subsystem” later in this specification.
		/// </summary>
		[FieldOffset(68)]
		public IMAGE_SUBSYSTEM Subsystem;

		/// <summary>
		/// For more information, see “DLL Characteristics” later in this specification.
		/// </summary>
		[FieldOffset(70)]
		public DllCharacteristicsType DllCharacteristics;

		/// <summary>
		/// The size of the stack to reserve. Only SizeOfStackCommit is committed; 
		/// the rest is made available one page at a time until the reserve size is reached.
		/// </summary>
		[FieldOffset(72)]
		public uint SizeOfStackReserve;

		/// <summary>
		/// The size of the stack to commit.
		/// </summary>
		[FieldOffset(76)]
		public uint SizeOfStackCommit;

		/// <summary>
		/// The size of the local heap space to reserve. 
		/// Only SizeOfHeapCommit is committed; the rest is made available one page at a time until the reserve size is reached.
		/// </summary>
		[FieldOffset(80)]
		public uint SizeOfHeapReserve;

		/// <summary>
		/// The size of the local heap space to commit.
		/// </summary>
		[FieldOffset(84)]
		public uint SizeOfHeapCommit;

		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		[FieldOffset(88)]
		public uint LoaderFlags;

		/// <summary>
		/// The number of data-directory entries in the remainder of the optional header. 
		/// Each describes a location and size.
		/// </summary>
		[FieldOffset(92)]
		public uint NumberOfRvaAndSizes;

		#endregion

		#region Optional Header Data Directories (Image Only)

		/// <summary>
		/// The export table address and size. For more information see section 6.3, “The .edata Section (Image Only).”
		/// </summary>
		[FieldOffset(96)]
		public IMAGE_DATA_DIRECTORY ExportTable;


		/// <summary>
		/// The import table address and size. For more information, see section 6.4, “The .idata Section.”
		/// </summary>
		[FieldOffset(104)]
		public IMAGE_DATA_DIRECTORY ImportTable;

		/// <summary>
		/// The resource table address and size. For more information, see section 6.9, “The .rsrc Section.”
		/// </summary>
		[FieldOffset(112)]
		public IMAGE_DATA_DIRECTORY ResourceTable;

		/// <summary>
		/// The exception table address and size. For more information, see section 6.5, “The .pdata Section.
		/// </summary>
		[FieldOffset(120)]
		public IMAGE_DATA_DIRECTORY ExceptionTable;

		/// <summary>
		/// The attribute certificate table address and size. For more information, see section 5.7, “The attribute certificate table (Image Only).”
		/// </summary>
		[FieldOffset(128)]
		public IMAGE_DATA_DIRECTORY CertificateTable;

		/// <summary>
		/// The base relocation table address and size. For more information, see section 6.6, “The .reloc Section (Image Only).”
		/// </summary>
		[FieldOffset(136)]
		public IMAGE_DATA_DIRECTORY BaseRelocationTable;

		/// <summary>
		/// The debug data starting address and size. For more information, see section 6.1, “The .debug Section.”
		/// </summary>
		[FieldOffset(144)]
		public IMAGE_DATA_DIRECTORY Debug;

		/// <summary>
		/// Reserved, must be 0
		/// </summary>
		[FieldOffset(152)]
		public IMAGE_DATA_DIRECTORY Architecture;

		/// <summary>
		/// The RVA of the value to be stored in the global pointer register. 
		/// The size member of this structure must be set to zero. 
		/// </summary>
		[FieldOffset(160)]
		public IMAGE_DATA_DIRECTORY GlobalPtr;

		/// <summary>
		/// The thread local storage (TLS) table address and size. For more information, see section 6.7, “The .tls Section.”
		/// </summary>
		[FieldOffset(168)]
		public IMAGE_DATA_DIRECTORY TLSTable;

		/// <summary>
		/// The load configuration table address and size. For more information, see section 6.8, “The Load Configuration Structure (Image Only).”
		/// </summary>
		[FieldOffset(176)]
		public IMAGE_DATA_DIRECTORY LoadConfigTable;

		/// <summary>
		/// The bound import table address and size. 
		/// </summary>
		[FieldOffset(184)]
		public IMAGE_DATA_DIRECTORY BoundImport;

		/// <summary>
		/// The import address table address and size. For more information, see section 6.4.4, “Import Address Table.”
		/// </summary>
		[FieldOffset(192)]
		public IMAGE_DATA_DIRECTORY IAT;

		/// <summary>
		/// The delay import descriptor address and size. For more information, see section 5.8, “Delay-Load Import Tables (Image Only).”
		/// </summary>
		[FieldOffset(200)]
		public IMAGE_DATA_DIRECTORY DelayImportDescriptor;

		/// <summary>
		/// The CLR runtime header address and size. For more information, see section 6.10, “The .cormeta Section (Object Only).”
		/// </summary>
		[FieldOffset(208)]
		public IMAGE_DATA_DIRECTORY CLRRuntimeHeader;

		/// <summary>
		/// Reserved, must be zero
		/// </summary>
		[FieldOffset(216)]
		public IMAGE_DATA_DIRECTORY Reserved;
		#endregion
	}
}