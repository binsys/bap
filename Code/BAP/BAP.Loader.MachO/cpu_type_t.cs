using BAP.Loader.MachO;

namespace BAP.Loader.MachO
{
	public enum cpu_type_t : int
	{
		CPU_TYPE_ANY         = -1,

		CPU_TYPE_VAX         = 1,
		CPU_TYPE_ROMP        = 2,
		CPU_TYPE_NS32032     = 4,
		CPU_TYPE_NS32332     = 5,
		CPU_TYPE_MC680x0     = 6,
		CPU_TYPE_X86         = 7,
		CPU_TYPE_I386        = CPU_TYPE_X86,            /* compatibility */
		CPU_TYPE_X86_64      = (CPU_TYPE_X86 | Consts.CPU_ARCH_ABI64),

		CPU_TYPE_MIPS        = 8,
		CPU_TYPE_NS32532     = 9,
		CPU_TYPE_MC98000     = 10,
		CPU_TYPE_HPPA        = 11,
		CPU_TYPE_ARM         = 12,
		CPU_TYPE_ARM64       = (CPU_TYPE_ARM | Consts.CPU_ARCH_ABI64),
		CPU_TYPE_MC88000     = 13,
		CPU_TYPE_SPARC       = 14,
		CPU_TYPE_I860        = 15, // big-endian
		CPU_TYPE_I860_LITTLE = 16, // little-endian
		CPU_TYPE_ALPHA       = 16,
		CPU_TYPE_RS6000      = 17,
		CPU_TYPE_POWERPC     = 18,
		CPU_TYPE_POWERPC64   = (CPU_TYPE_POWERPC | Consts.CPU_ARCH_ABI64),
		CPU_TYPE_VEO         = 255,
	}
}