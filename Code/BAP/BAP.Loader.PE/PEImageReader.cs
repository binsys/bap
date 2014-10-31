using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using BAP.Utils;

namespace BAP.Loader.PE
{

	public class PEImage
	{

	}

	public class PEImageReader : BinaryReader
	{
		public IMAGE_DOS_HEADER ImageDOSHeader = default(IMAGE_DOS_HEADER);
		public IMAGE_NT_HEADERS ImageNTHeaders = default(IMAGE_NT_HEADERS);
		public IMAGE_SECTION_HEADER ImageSectionHeader = default(IMAGE_SECTION_HEADER);
		public int ImageSectionHeadersOffset = 0;
		public IMAGE_SECTION_HEADER[] ImageSectionHeaders = default(IMAGE_SECTION_HEADER[]);

		/// <inheritDoc/>
		public PEImageReader(Stream input)
			: base(input)
		{

		}

		/// <inheritDoc/>
		public PEImageReader(Stream input, Encoding encoding)
			: base(input, encoding)
		{

		}

		/// <inheritDoc/>
		public PEImageReader(Stream input, Encoding encoding, bool leaveOpen)
			: base(input, encoding, leaveOpen)
		{

		}

		//Stream input, Encoding encoding, bool leaveOpen


		public void ReadImage()
		{
			this.ReadImageDOSHeader();
			this.ReadImageNTHeaders();
			this.ReadImageSectionHeaders();

			this.CheckNumberOfRvaAndSizes();

			this.ReadExportTable();
			this.ReadImportTable();
			this.ReadResourceTable();
			this.ReadExceptionTable();
			this.ReadCertificateTable();
			this.ReadBaseRelocationTable();
			this.ReadDebug();
			this.ReadArchitecture();
			this.ReadGlobalPtr();
			this.ReadTLSTable();
			this.ReadLoadConfigTable();
			this.ReadBoundImport();
			this.ReadIAT();
			this.ReadDelayImportDescriptor();
			this.ReadCLRRuntimeHeader();
			this.ReadReserved();


		}

		private void ReadImageDOSHeader()
		{
			this.Read(ref this.ImageDOSHeader);

			if (!this.ImageDOSHeader.IsValid)
				throw new InvalidOperationException();
		}

		private void ReadImageNTHeaders()
		{
			this.BaseStream.Seek(this.ImageDOSHeader.e_lfanew, SeekOrigin.Begin);

			this.Read(ref this.ImageNTHeaders);
			if (!this.ImageNTHeaders.IsValid)
				throw new InvalidOperationException();
		}

		private void ReadImageSectionHeaders()
		{
			Array.Resize(ref this.ImageSectionHeaders, this.ImageNTHeaders.CoffFileHeader.NumberOfSections);

			this.ImageSectionHeadersOffset = (int)(Marshal.OffsetOf(typeof(IMAGE_NT_HEADERS), "CoffFileHeader").ToInt32() +
				Utils.Utils.SizeOf<IMAGE_COFF_FILE_HEADER>() +
				this.ImageNTHeaders.CoffFileHeader.SizeOfOptionalHeader);

			this.BaseStream.Seek(this.ImageDOSHeader.e_lfanew, SeekOrigin.Begin);
			this.BaseStream.Seek(ImageSectionHeadersOffset, SeekOrigin.Current);

			this.Read(ref this.ImageSectionHeaders);
		}

		private void CheckNumberOfRvaAndSizes()
		{
			if (!this.ImageNTHeaders.Is64)
			{
				if (this.ImageNTHeaders.OptionalHeader32.NumberOfRvaAndSizes == 0)
					throw new InvalidOperationException();
			}
			else
			{
				if (this.ImageNTHeaders.OptionalHeader64.NumberOfRvaAndSizes == 0)
					throw new InvalidOperationException();
			}
		}

		private void ReadExportTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.ExportTable
				: this.ImageNTHeaders.OptionalHeader64.ExportTable;

			if(DataDirectory.IsZero) return;
		}

		private void ReadImportTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.ImportTable
				: this.ImageNTHeaders.OptionalHeader64.ImportTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadResourceTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.ResourceTable
				: this.ImageNTHeaders.OptionalHeader64.ResourceTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadExceptionTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.ExceptionTable
				: this.ImageNTHeaders.OptionalHeader64.ExceptionTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadCertificateTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.CertificateTable
				: this.ImageNTHeaders.OptionalHeader64.CertificateTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadBaseRelocationTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.BaseRelocationTable
				: this.ImageNTHeaders.OptionalHeader64.BaseRelocationTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadDebug()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.Debug
				: this.ImageNTHeaders.OptionalHeader64.Debug;

			if (DataDirectory.IsZero) return;
		}

		private void ReadArchitecture()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.Architecture
				: this.ImageNTHeaders.OptionalHeader64.Architecture;

			if (DataDirectory.IsZero) return;
		}

		private void ReadGlobalPtr()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.GlobalPtr
				: this.ImageNTHeaders.OptionalHeader64.GlobalPtr;

			if (DataDirectory.IsZero) return;
		}

		private void ReadTLSTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.TLSTable
				: this.ImageNTHeaders.OptionalHeader64.TLSTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadLoadConfigTable()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.LoadConfigTable
				: this.ImageNTHeaders.OptionalHeader64.LoadConfigTable;

			if (DataDirectory.IsZero) return;
		}

		private void ReadBoundImport()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.BoundImport
				: this.ImageNTHeaders.OptionalHeader64.BoundImport;

			if (DataDirectory.IsZero) return;
		}

		private void ReadIAT()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.IAT
				: this.ImageNTHeaders.OptionalHeader64.IAT;

			if (DataDirectory.IsZero) return;
		}

		private void ReadDelayImportDescriptor()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.DelayImportDescriptor
				: this.ImageNTHeaders.OptionalHeader64.DelayImportDescriptor;

			if (DataDirectory.IsZero) return;
		}

		private void ReadCLRRuntimeHeader()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.CLRRuntimeHeader
				: this.ImageNTHeaders.OptionalHeader64.CLRRuntimeHeader;

			if (DataDirectory.IsZero) return;
		}

		private void ReadReserved()
		{
			var DataDirectory = !this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader32.Reserved
				: this.ImageNTHeaders.OptionalHeader64.Reserved;

			if (DataDirectory.IsZero) return;
		}


		public UInt64 VA2FO(UInt64 va)
		{

			ulong basea = this.ImageNTHeaders.Is64
				? this.ImageNTHeaders.OptionalHeader64.ImageBase
				: this.ImageNTHeaders.OptionalHeader32.ImageBase;

			IMAGE_SECTION_HEADER targetHeader = default(IMAGE_SECTION_HEADER);
			bool found = false;

			foreach (var imageSectionHeader in ImageSectionHeaders)
			{
				if (va >= imageSectionHeader.VirtualAddress &&
					va <= imageSectionHeader.VirtualAddress + imageSectionHeader.VirtualSize)
				{
					targetHeader = imageSectionHeader;
					found = true;
					break;
				}
			}


			if (found)
			{
				return va - targetHeader.VirtualAddress + targetHeader.PointerToRawData;
			}
			else
			{
				return 0;
			}
		}
	}
}
