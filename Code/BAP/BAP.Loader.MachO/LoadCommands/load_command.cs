using System;

namespace BAP.Loader.MachO.LoadCommands
{
	/// <summary>
	/// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/load_command
	/// </summary>
	public struct load_command : ILoadCommand
	{
		public LC cmd;
		public UInt32 cmdsize;
	}

	///// <summary>
	///// https://developer.apple.com/library/mac/documentation/DeveloperTools/Conceptual/MachORuntime/Reference/reference.html#//apple_ref/c/tag/load_command
	///// </summary>
	//public class LoadCommand
	//{
	//	public LC Command { get; set; }
	//	public UInt32 CommandSize { get; set; }
	//	public byte[] CommandData { get; set; }

	//	public LoadCommand()
	//	{

	//	}
	//}
}