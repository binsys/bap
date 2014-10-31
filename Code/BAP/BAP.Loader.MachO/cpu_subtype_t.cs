namespace BAP.Loader.MachO
{
	public enum cpu_subtype_t
	{

		/*
		 * Machine subtypes (these are defined here, instead of in a machine
		 * dependent directory, so that any program can get all definitions
		 * regardless of where is it compiled).
		 */


		/*
		 * Object files that are hand-crafted to run on any
		 * implementation of an architecture are tagged with
		 * CPU_SUBTYPE_MULTIPLE.  This functions essentially the same as
		 * the "ALL" subtype of an architecture except that it allows us
		 * to easily find object files that may need to be modified
		 * whenever a new implementation of an architecture comes out.
		 * 
		 * It is the responsibility of the implementor to make sure the
		 * software handles unsupported implementations elegantly.
		 */
		CPU_SUBTYPE_MULTIPLE = -1,
		CPU_SUBTYPE_LITTLE_ENDIAN = 0,
		CPU_SUBTYPE_BIG_ENDIAN = 1,

		/*
		 * Machine threadtypes.
		 * This is none - not defined - for most machine types/subtypes.
		 */
		CPU_THREADTYPE_NONE = 0,

		/*
		 * VAX subtypes (these do *not* necessary conform to the actual cpu
		 * ID assigned by DEC available via the SID register).
		 */

		CPU_SUBTYPE_VAX_ALL = 0,
		CPU_SUBTYPE_VAX780 = 1,
		CPU_SUBTYPE_VAX785 = 2,
		CPU_SUBTYPE_VAX750 = 3,
		CPU_SUBTYPE_VAX730 = 4,
		CPU_SUBTYPE_UVAXI = 5,
		CPU_SUBTYPE_UVAXII = 6,
		CPU_SUBTYPE_VAX8200 = 7,
		CPU_SUBTYPE_VAX8500 = 8,
		CPU_SUBTYPE_VAX8600 = 9,
		CPU_SUBTYPE_VAX8650 = 10,
		CPU_SUBTYPE_VAX8800 = 11,
		CPU_SUBTYPE_UVAXIII = 12,

		/*
		 * ROMP subtypes.
		 */

		CPU_SUBTYPE_RT_ALL = 0,
		CPU_SUBTYPE_RT_PC = 1,
		CPU_SUBTYPE_RT_APC = 2,
		CPU_SUBTYPE_RT_135 = 3,

		/*
		 * 32032/32332/32532 subtypes.
		 */

		CPU_SUBTYPE_MMAX_ALL = 0,
		CPU_SUBTYPE_MMAX_DPC = 1, /* 032 CPU */
		CPU_SUBTYPE_SQT = 2,
		CPU_SUBTYPE_MMAX_APC_FPU = 3, /* 32081 FPU */
		CPU_SUBTYPE_MMAX_APC_FPA = 4, /* Weitek FPA */
		CPU_SUBTYPE_MMAX_XPC = 5, /* 532 CPU */

		/*
		 * 680x0 subtypes
		 *
		 * The subtype definitions here are unusual for historical reasons.
		 * NeXT used to consider 68030 code as generic 68000 code.  For
		 * backwards compatability:
		 * 
		 * CPU_SUBTYPE_MC68030 symbol has been preserved for source code
		 * compatability.
		 *
		 * CPU_SUBTYPE_MC680x0_ALL has been defined to be the same
		 * subtype as CPU_SUBTYPE_MC68030 for binary comatability.
		 *
		 * CPU_SUBTYPE_MC68030_ONLY has been added to allow new object
		 * files to be tagged as containing 68030-specific instructions.
		 */

		CPU_SUBTYPE_MC680x0_ALL = 1,
		CPU_SUBTYPE_MC68030 = 1, /* compat */
		CPU_SUBTYPE_MC68040 = 2,
		CPU_SUBTYPE_MC68030_ONLY = 3,

		/*
		 * I386 subtypes
		 */

		//#define CPU_SUBTYPE_INTEL(f, m) ((cpu_subtype_t) (f) + ((m) << 4))

		CPU_SUBTYPE_I386_ALL       = (3  + (0 << 4)),
		CPU_SUBTYPE_386            = (3  + (0 << 4)),
		CPU_SUBTYPE_486            = (4  + (0 << 4)),
		CPU_SUBTYPE_486SX          = (4  + (8 << 4)), // 8 << 4 = 128
		CPU_SUBTYPE_586            = (5  + (0 << 4)),
		CPU_SUBTYPE_PENT           = (5  + (0 << 4)),
		CPU_SUBTYPE_PENTPRO        = (6  + (1 << 4)),
		CPU_SUBTYPE_PENTII_M3      = (6  + (3 << 4)),
		CPU_SUBTYPE_PENTII_M5      = (6  + (5 << 4)),
		CPU_SUBTYPE_CELERON        = (7  + (6 << 4)),
		CPU_SUBTYPE_CELERON_MOBILE = (7  + (7 << 4)),
		CPU_SUBTYPE_PENTIUM_3      = (8  + (0 << 4)),
		CPU_SUBTYPE_PENTIUM_3_M    = (8  + (1 << 4)),
		CPU_SUBTYPE_PENTIUM_3_XEON = (8  + (2 << 4)),
		CPU_SUBTYPE_PENTIUM_M      = (9  + (0 << 4)),
		CPU_SUBTYPE_PENTIUM_4      = (10 + (0 << 4)),
		CPU_SUBTYPE_PENTIUM_4_M    = (10 + (1 << 4)),
		CPU_SUBTYPE_ITANIUM        = (11 + (0 << 4)),
		CPU_SUBTYPE_ITANIUM_2      = (11 + (1 << 4)),
		CPU_SUBTYPE_XEON           = (12 + (0 << 4)),
		CPU_SUBTYPE_XEON_MP        = (12 + (1 << 4)),

		//#define CPU_SUBTYPE_INTEL_FAMILY(x)     ((x) & 15)
		//#define CPU_SUBTYPE_INTEL_FAMILY_MAX    15

		//#define CPU_SUBTYPE_INTEL_MODEL(x)      ((x) >> 4)
		//#define CPU_SUBTYPE_INTEL_MODEL_ALL     0

		/*
		 *      X86 subtypes.
		 */

		CPU_SUBTYPE_X86_ALL = 3,
		CPU_SUBTYPE_X86_64_ALL = 3,
		CPU_SUBTYPE_X86_ARCH1 = 4,


		CPU_THREADTYPE_INTEL_HTT = 1,

		/*
		 *      Mips subtypes.
		 */
		CPU_SUBTYPE_MIPS_ALL = 0,
		CPU_SUBTYPE_MIPS_R2300 = 1,
		CPU_SUBTYPE_MIPS_R2600 = 2,
		CPU_SUBTYPE_MIPS_R2800 = 3,
		CPU_SUBTYPE_MIPS_R2000a = 4,    /* pmax */
		CPU_SUBTYPE_MIPS_R2000 = 5,
		CPU_SUBTYPE_MIPS_R3000a = 6,    /* 3max */
		CPU_SUBTYPE_MIPS_R3000 = 7,

		/*
		 *      MC98000 (PowerPC) subtypes
		 */
		CPU_SUBTYPE_MC98000_ALL = 0,
		CPU_SUBTYPE_MC98601 = 1,

		/*
		 *      HPPA subtypes for Hewlett-Packard HP-PA family of
		 *      risc processors. Port by NeXT to 700 series. 
		 */

		CPU_SUBTYPE_HPPA_ALL = 0,
		CPU_SUBTYPE_HPPA_7100 = 0, /* compat */
		CPU_SUBTYPE_HPPA_7100LC = 1,

		/*
		 *      MC88000 subtypes.
		 */
		CPU_SUBTYPE_MC88000_ALL = 0,
		CPU_SUBTYPE_MC88100 = 1,
		CPU_SUBTYPE_MC88110 = 2,


		/*
		 *      I860 subtypes
		 */
		CPU_SUBTYPE_I860_ALL = 0,
		CPU_SUBTYPE_I860_860 = 1,

		/*
		 *      I860 subtypes for NeXT-internal backwards compatability.
		 *      These constants will be going away.  DO NOT USE THEM!!!
		 */
		//CPU_SUBTYPE_LITTLE_ENDIAN       = 0,
		//CPU_SUBTYPE_BIG_ENDIAN          = 1,

		/*
		 *      I860_LITTLE subtypes
		 */
		CPU_SUBTYPE_I860_LITTLE_ALL = 0,
		CPU_SUBTYPE_I860_LITTLE = 1,

		/*
		 *      RS6000 subtypes
		 */
		CPU_SUBTYPE_RS6000_ALL = 0,
		CPU_SUBTYPE_RS6000 = 1,

		/*
		 *      Sun4 subtypes - port done at CMU
		 */
		CPU_SUBTYPE_SUN4_ALL = 0,
		CPU_SUBTYPE_SUN4_260 = 1,
		CPU_SUBTYPE_SUN4_110 = 2,

		/*
		 *      SPARC subtypes
		 */
		CPU_SUBTYPE_SPARC_ALL = 0,

		/*
		 *      PowerPC subtypes
		 */
		CPU_SUBTYPE_POWERPC_ALL = 0,
		CPU_SUBTYPE_POWERPC_601 = 1,
		CPU_SUBTYPE_POWERPC_602 = 2,
		CPU_SUBTYPE_POWERPC_603 = 3,
		CPU_SUBTYPE_POWERPC_603e = 4,
		CPU_SUBTYPE_POWERPC_603ev = 5,
		CPU_SUBTYPE_POWERPC_604 = 6,
		CPU_SUBTYPE_POWERPC_604e = 7,
		CPU_SUBTYPE_POWERPC_620 = 8,
		CPU_SUBTYPE_POWERPC_750 = 9,
		CPU_SUBTYPE_POWERPC_7400 = 10,
		CPU_SUBTYPE_POWERPC_7450 = 11,
		CPU_SUBTYPE_POWERPC_970 = 100,

		/*
		 *      ARM subtypes
		 */
		CPU_SUBTYPE_ARM_ALL = 0,
		CPU_SUBTYPE_ARM_A500_ARCH = 1,
		CPU_SUBTYPE_ARM_A500 = 2,
		CPU_SUBTYPE_ARM_A440 = 3,
		CPU_SUBTYPE_ARM_M4 = 4,
		CPU_SUBTYPE_ARM_A680 = 5,
		CPU_SUBTYPE_ARM_V4T = 5,
		CPU_SUBTYPE_ARM_V6 = 6,
		CPU_SUBTYPE_ARM_V5TEJ = 7,
		CPU_SUBTYPE_ARM_XSCALE = 8,
		CPU_SUBTYPE_ARM_V7 = 9,
		CPU_SUBTYPE_ARM_V7F = 10, /* Cortex A9 */
		CPU_SUBTYPE_ARM_V7S = 11, /* Swift */
		CPU_SUBTYPE_ARM_V7K = 12, /* Kirkwood40 */
		CPU_SUBTYPE_ARM_V6M = 14, /* Not meant to be run under xnu */
		CPU_SUBTYPE_ARM_V7M = 15, /* Not meant to be run under xnu */
		CPU_SUBTYPE_ARM_V7EM = 16, /* Not meant to be run under xnu */

		CPU_SUBTYPE_ARM_V8 = 13,

		/*
		 *  ARM64 subtypes
		 */
		CPU_SUBTYPE_ARM64_ALL = 0,
		CPU_SUBTYPE_ARM64_V8 = 1,


		/*
		 * VEO subtypes
		 * Note: the CPU_SUBTYPE_VEO_ALL will likely change over time to be defined as
		 * one of the specific subtypes.
		 */
		CPU_SUBTYPE_VEO_1 = 1,
		CPU_SUBTYPE_VEO_2 = 2,
		CPU_SUBTYPE_VEO_ALL = CPU_SUBTYPE_VEO_2,
	}
}