using System;

namespace BAP.Loader.PE
{
	/// <summary>
	/// The following values are defined for the DllCharacteristics field of the optional header.
	/// </summary>
	[Flags]
	public enum DllCharacteristicsType : ushort
	{
		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		Reserved_0 = 0x0001,

		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		Reserved_1 = 0x0002,

		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		Reserved_2 = 0x0004,

		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		Reserved_3 = 0x0008,

		/// <summary>
		/// DLL can be relocated at load time.
		/// </summary>
		IMAGE_DLL_CHARACTERISTICS_DYNAMIC_BASE = 0x0040,

		/// <summary>
		/// Code Integrity checks are enforced.
		/// </summary>
		IMAGE_DLL_CHARACTERISTICS_FORCE_INTEGRITY = 0x0080,

		/// <summary>
		/// Image is NX compatible.
		/// </summary>
		IMAGE_DLL_CHARACTERISTICS_NX_COMPAT = 0x0100,

		/// <summary>
		/// Isolation aware, but do not isolate the image.
		/// </summary>
		IMAGE_DLLCHARACTERISTICS_NO_ISOLATION = 0x0200,

		/// <summary>
		/// Does not use structured exception (SE) handling. No SE handler may be called in this image.
		/// </summary>
		IMAGE_DLLCHARACTERISTICS_NO_SEH = 0x0400,

		/// <summary>
		/// Do not bind the image.
		/// </summary>
		IMAGE_DLLCHARACTERISTICS_NO_BIND = 0x0800,

		/// <summary>
		/// Reserved, must be zero.
		/// </summary>
		Reserved_4 = 0x1000,

		/// <summary>
		/// A WDM driver.
		/// </summary>
		IMAGE_DLLCHARACTERISTICS_WDM_DRIVER = 0x2000,

		/// <summary>
		/// Terminal Server aware.
		/// </summary>
		IMAGE_DLLCHARACTERISTICS_TERMINAL_SERVER_AWARE = 0x8000
	}
}