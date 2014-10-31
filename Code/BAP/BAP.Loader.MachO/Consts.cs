using System;

namespace BAP.Loader.MachO
{
	public class Consts
	{
		/* Constant for the magic field of the mach_header (32-bit architectures) */
		public const UInt32 MH_MAGIC = 0xfeedface; /* the mach magic number */
		public const UInt32 MH_CIGAM = 0xcefaedfe;      /* NXSwapInt(MH_MAGIC) */

		/* Constant for the magic field of the mach_header_64 (64-bit architectures) */
		public const UInt32 MH_MAGIC_64 = 0xfeedfacf; /* the 64-bit mach magic number */
		public const UInt32 MH_CIGAM_64 = 0xcffaedfe; /* NXSwapInt(MH_MAGIC_64) */


		/*
		 * Capability bits used in the definition of cpu_type.
		 */
		public const Int32 CPU_ARCH_MASK = unchecked((Int32)0xff000000);              /* mask for architecture bits */
		public const Int32 CPU_ARCH_ABI64 = unchecked((Int32)0x01000000);             /* 64 bit ABI */

		/*
		 * Capability bits used in the definition of cpu_subtype.
		 */
		public const Int32 CPU_SUBTYPE_MASK = unchecked((Int32)0xff000000);      /* mask for feature flags */
		public const Int32 CPU_SUBTYPE_LIB64 = unchecked((Int32)0x80000000);     /* 64 bit libraries */
	}
}