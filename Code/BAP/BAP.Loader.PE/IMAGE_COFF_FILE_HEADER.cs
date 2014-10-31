using System;
using System.Runtime.InteropServices;

namespace BAP.Loader.PE
{
	[StructLayout(LayoutKind.Sequential)]
	public struct IMAGE_COFF_FILE_HEADER
	{
		/// <summary>
		/// The number that identifies the type of target machine. 
		/// For more information, see section 3.3.1, “Machine Types.”
		/// </summary>
		public IMAGE_FILE_MACHINE Machine;

		/// <summary>
		/// The number of sections. 
		/// This indicates the size of the section table, which immediately follows the headers.
		/// </summary>
		public UInt16 NumberOfSections;

		/// <summary>
		/// The low 32 bits of the number of seconds since 00:00 January 1, 1970 (a C run-time time_t value), that indicates when the file was created.
		/// </summary>
		private UInt32 TimeDateStamp;


		public DateTime TimeDateStampa
		{
			get
			{
				//const string STARTDATE = "1/1/1970 0:0:0";
				//TimeZone timeZone = TimeZone.CurrentTimeZone;
				//return timeZone.ToLocalTime(DateTime.Parse(STARTDATE).AddSeconds((double)TimeDateStamp));

				return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970,1,1,0,0,0,DateTimeKind.Local).AddSeconds((double) TimeDateStamp));

				//return timeZone.ToLocalTime(DateTime.Parse(STARTDATE).AddSeconds((double) TimeDateStamp));
			}
			set
			{
				TimeDateStamp = (uint)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
			}
		}

		/// <summary>
		/// The file offset of the COFF symbol table, or zero if no COFF symbol table is present. 
		/// This value should be zero for an image because COFF debugging information is deprecated.
		/// </summary>
		public UInt32 PointerToSymbolTable;

		/// <summary>
		/// The number of entries in the symbol table. This data can be used to locate the string table, 
		/// which immediately follows the symbol table. 
		/// This value should be zero for an image because COFF debugging information is deprecated.
		/// </summary>
		public UInt32 NumberOfSymbols;

		/// <summary>
		/// The size of the optional header, which is required for executable files but not for object files. 
		/// This value should be zero for an object file. 
		/// For a description of the header format, see section 3.4, “Optional Header (Image Only).”
		/// </summary>
		public UInt16 SizeOfOptionalHeader;

		/// <summary>
		/// The flags that indicate the attributes of the file. 
		/// For specific flag values, see section 3.3.2, “Characteristics.”
		/// </summary>
		public IMAGE_FILE_Characteristics Characteristics;




	}
}