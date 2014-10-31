namespace BAP.Loader.PE
{
	/// <summary>
	/// The optional header magic number determines whether an image is a PE32 or PE32+ executable.
	/// PE32+ images allow for a 64-bit address space while limiting the image size to 2 gigabytes. 
	/// Other PE32+ modifications are addressed in their respective sections.
	/// </summary>
	public enum IMAGE_OPTIONAL_HEADER_MAGIC : ushort
	{
		/// <summary>
		/// PE32
		/// </summary>
		IMAGE_NT_OPTIONAL_HDR32_MAGIC = 0x10b,

		/// <summary>
		/// PE32+
		/// </summary>
		IMAGE_NT_OPTIONAL_HDR64_MAGIC = 0x20b
	}
}