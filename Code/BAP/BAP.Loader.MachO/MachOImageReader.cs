using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BAP.Loader.MachO;
using BAP.Loader.MachO.LoadCommands;
using BAP.Utils;

namespace BAP.Loader.MachO
{
	public class MachOImageReader : BinaryReader
	{
		public mach_header Header = default(mach_header);
		public mach_header_64 Header64 = default(mach_header_64);

		public bool Is64Bit { get; set; }

		readonly List<ILoadCommand> LoadCommands = new List<ILoadCommand>();


		/// <inheritDoc/>
		public MachOImageReader(Stream input)
			: base(input)
		{

		}

		/// <inheritDoc/>
		public MachOImageReader(Stream input, Encoding encoding)
			: base(input, encoding)
		{

		}

		/// <inheritDoc/>
		public MachOImageReader(Stream input, Encoding encoding, bool leaveOpen)
			: base(input, encoding, leaveOpen)
		{

		}

		public void ReadImage()
		{
			this.ReadHeader();
			this.ReadLoadCommands();
		}

		private void ReadHeader()
		{
			UInt32 magic = this.ReadUInt32();
			this.BaseStream.Seek(-Utils.Utils.SizeOf<UInt32>(), SeekOrigin.Current);

			if (magic == Consts.MH_MAGIC)
			{
				this.Read(ref this.Header);
			}
			else if (magic == Consts.MH_CIGAM)
			{
				throw new InvalidOperationException();
			}
			else if (magic == Consts.MH_MAGIC_64)
			{
				this.Header = default(mach_header);
				this.Read(ref this.Header64);
				this.Is64Bit = true;
			}
			else if (magic == Consts.MH_CIGAM_64)
			{
				throw new InvalidOperationException();
			}
		}

		private void ReadLoadCommands()
		{
			uint ncmd = this.Is64Bit ? this.Header64.ncmds : this.Header.ncmds;
			for (uint i = 0; i < ncmd; i++)
			{
				this.ReadLoadCommand();
			}
		}

		private void ReadLoadCommand()
		{
			load_command lc = default(load_command);

			if (this.Read(ref lc))
			{
				this.BaseStream.Seek(-Utils.Utils.SizeOf<load_command>(), SeekOrigin.Current);

				switch (lc.cmd)
				{
					case LC.LC_SEGMENT:
						{
							var orgipos = this.BaseStream.Position;

							segment_command newlc = default(segment_command);
							if (this.Read(ref newlc))
							{
								if (newlc.nsects != 0)
								{
									section[] secs = new section[newlc.nsects];

									if (this.Read(ref secs))
									{

									}
								}
							}

							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					case LC.LC_SYMTAB:
						{
							var orgipos = this.BaseStream.Position;
							symtab_command newlc = default(symtab_command);
							if (this.Read(ref newlc))
							{

							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_SYMSEG:
					//	break;
					//case LC.LC_THREAD:
					//	break;
					case LC.LC_UNIXTHREAD:
						{
							var orgipos = this.BaseStream.Position;
							thread_command newlc = default(thread_command);
							if (this.Read(ref newlc))
							{
#warning "Thread status"
								var bytes = this.ReadBytes((int) (newlc.cmdsize - Utils.Utils.SizeOf<thread_command>()));
							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_LOADFVMLIB:
					//	break;
					//case LC.LC_IDFVMLIB:
					//	break;
					//case LC.LC_IDENT:
					//	break;
					//case LC.LC_FVMFILE:
					//	break;
					//case LC.LC_PREPAGE:
					//	break;
					case LC.LC_DYSYMTAB:
						{
							var orgipos = this.BaseStream.Position;
							dysymtab_command newlc = default(dysymtab_command);
							if (this.Read(ref newlc))
							{

							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_LOAD_DYLIB:
					//	break;
					//case LC.LC_ID_DYLIB:
					//	break;
					case LC.LC_LOAD_DYLINKER:
						{
							var orgipos = this.BaseStream.Position;
							dylinker_command newlc = default(dylinker_command);
							if (this.Read(ref newlc))
							{
								if (newlc.cmdsize > Utils.Utils.SizeOf<dylinker_command>())
								{
									Debug.Assert(newlc.name.offset == Utils.Utils.SizeOf<dylinker_command>());

									var ssize = newlc.cmdsize - Utils.Utils.SizeOf<dylinker_command>();

									var bytes = this.ReadBytes((int)ssize);

									string a = Encoding.ASCII.GetString(bytes).Trim('\0');
								}
							}

							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_ID_DYLINKER:
					//	break;
					//case LC.LC_PREBOUND_DYLIB:
					//	break;
					//case LC.LC_ROUTINES:
					//	break;
					//case LC.LC_SUB_FRAMEWORK:
					//	break;
					//case LC.LC_SUB_UMBRELLA:
					//	break;
					//case LC.LC_SUB_CLIENT:
					//	break;
					//case LC.LC_SUB_LIBRARY:
					//	break;
					//case LC.LC_TWOLEVEL_HINTS:
					//	break;
					//case LC.LC_PREBIND_CKSUM:
					//	break;
					//case LC.LC_LOAD_WEAK_DYLIB:
					//	break;
					case LC.LC_SEGMENT_64:
						{
							var orgipos = this.BaseStream.Position;
							segment_command_64 newlc = default(segment_command_64);
							if (this.Read(ref newlc))
							{
								if (newlc.nsects != 0)
								{
									section_64[] secs = new section_64[newlc.nsects];

									if (this.Read(ref secs))
									{

									}
								}
							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_ROUTINES_64:
					//	break;
					case LC.LC_UUID:
						{
							var orgipos = this.BaseStream.Position;
							uuid_command newlc = default(uuid_command);
							if (this.Read(ref newlc))
							{

							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_RPATH:
					//	break;
					//case LC.LC_CODE_SIGNATURE:
					//	break;
					//case LC.LC_SEGMENT_SPLIT_INFO:
					//	break;
					//case LC.LC_REEXPORT_DYLIB:
					//	break;
					//case LC.LC_LAZY_LOAD_DYLIB:
					//	break;
					//case LC.LC_ENCRYPTION_INFO:
					//	break;
					case LC.LC_DYLD_INFO:
					case LC.LC_DYLD_INFO_ONLY:
						{
							var orgipos = this.BaseStream.Position;
							dyld_info_command newlc = default(dyld_info_command);
							if (this.Read(ref newlc))
							{

							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_LOAD_UPWARD_DYLIB:
					//	break;
					case LC.LC_VERSION_MIN_MACOSX:
					case LC.LC_VERSION_MIN_IPHONEOS:
						{
							var orgipos = this.BaseStream.Position;
							version_min_command newlc = default(version_min_command);
							if (this.Read(ref newlc))
							{

							}
							var newpos = this.BaseStream.Position;
							var readlen = newpos - orgipos;
							Debug.Assert(readlen == newlc.cmdsize);
						}
						break;
					//case LC.LC_FUNCTION_STARTS:
					//	break;
					//case LC.LC_DYLD_ENVIRONMENT:
					//	break;
					//case LC.LC_MAIN:
					//	break;
					//case LC.LC_DATA_IN_CODE:
					//	break;
					//case LC.LC_SOURCE_VERSION:
					//	break;
					//case LC.LC_DYLIB_CODE_SIGN_DRS:
					//	break;
					//case LC.LC_ENCRYPTION_INFO_64:
					//	break;
					//case LC.LC_LINKER_OPTION:
					//	break;
					default:
						var cmd = lc.cmd;


						Debugger.Break();
						break;
				}

				//LoadCommand lca = new LoadCommand() { Command = lc.cmd, CommandSize = lc.cmdsize };


				//if (lca.CommandSize > 0)
				//{
				//	lca.CommandData = this.ReadBytes((int)lca.CommandSize - 8);
				//}

				//this.LoadCommands.Add(lca);
			}
		}
	}
}
