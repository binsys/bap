using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	[StructLayout(LayoutKind.Explicit)]
	public struct IMAGE_NT_HEADERS
	{
		[FieldOffset(0)]
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public char[] Signature;

		[FieldOffset(4)]
		public IMAGE_COFF_FILE_HEADER CoffFileHeader;

		[FieldOffset(24)]
		public IMAGE_OPTIONAL_HEADER32 OptionalHeader32;

		[FieldOffset(24)]
		public IMAGE_OPTIONAL_HEADER64 OptionalHeader64;

		public bool Is64
		{
			get
			{
				switch (OptionalHeader32.Magic)
				{
					case IMAGE_OPTIONAL_HEADER_MAGIC.IMAGE_NT_OPTIONAL_HDR32_MAGIC:
						return false;
					case IMAGE_OPTIONAL_HEADER_MAGIC.IMAGE_NT_OPTIONAL_HDR64_MAGIC:
						return true;
					default:
						throw new InvalidOperationException();
				}
			}
		}

		public bool IsValid
		{
			get
			{
				return Signature[0] == 'P' && Signature[1] == 'E' && Signature[2] == 0 && Signature[3] == 0 &&
				       CoffFileHeader.SizeOfOptionalHeader >= 200 &&
				       (OptionalHeader32.Magic == IMAGE_OPTIONAL_HEADER_MAGIC.IMAGE_NT_OPTIONAL_HDR32_MAGIC ||
				        OptionalHeader32.Magic == IMAGE_OPTIONAL_HEADER_MAGIC.IMAGE_NT_OPTIONAL_HDR64_MAGIC);
			}
		}
	}
}