namespace BAP.Loader.MachO
{

	/*
	 * The layout of the file depends on the filetype.  For all but the MH_OBJECT
	 * file type the segments are padded out and aligned on a segment alignment
	 * boundary for efficient demand pageing.  The MH_EXECUTE, MH_FVMLIB, MH_DYLIB,
	 * MH_DYLINKER and MH_BUNDLE file types also have the headers included as part
	 * of their first segment.
	 * 
	 * The file type MH_OBJECT is a compact format intended as output of the
	 * assembler and input (and possibly output) of the link editor (the .o
	 * format).  All sections are in one unnamed segment with no segment padding. 
	 * This format is used as an executable format when the file is so small the
	 * segment padding greatly increases its size.
	 *
	 * The file type MH_PRELOAD is an executable format intended for things that
	 * are not executed under the kernel (proms, stand alones, kernels, etc).  The
	 * format can be executed under the kernel but may demand paged it and not
	 * preload it before execution.
	 *
	 * A core file is in MH_CORE format and can be any in an arbritray legal
	 * Mach-O file.
	 *
	 * Constants for the filetype field of the mach_header
	 */
	public enum filetype : uint
	{
		MH_OBJECT        = 0x1,             /* relocatable object file */
		MH_EXECUTE       = 0x2,             /* demand paged executable file */
		MH_FVMLIB        = 0x3,             /* fixed VM shared library file */
		MH_CORE          = 0x4,             /* core file */
		MH_PRELOAD       = 0x5,             /* preloaded executable file */
		MH_DYLIB         = 0x6,             /* dynamically bound shared library */
		MH_DYLINKER      = 0x7,             /* dynamic link editor */
		MH_BUNDLE        = 0x8,             /* dynamically bound bundle file */
		MH_DYLIB_STUB    = 0x9,             /* shared library stub for static */
		/*  linking only, no section contents */
		MH_DSYM          = 0xa,             /* companion file with only debug */
		/*  sections */
		MH_KEXT_BUNDLE   = 0xb,             /* x86_64 kexts */
	}
}