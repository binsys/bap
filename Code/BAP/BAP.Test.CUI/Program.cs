using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BAP.Loader.PE;
using BAP.Loader.MachO;

namespace BAP.Test.CUI
{
	class Program
	{
		static void Main(string[] args)
		{
			//TestPEImageReader();
			TestMachOImageReader();
		}

		public static void TestPEImageReader()
		{
			string Path1 = @"C:\Users\BinSys\Desktop\BAP\BAPTests\Debug\ConsoleApplication1.exe";
			string Path2 = @"C:\Users\BinSys\Desktop\BAP\BAPTests\x64\Debug\ConsoleApplication1.exe";

			using (var FileStream = new FileStream(Path1, FileMode.Open))
			using (var PEImageReader = new PEImageReader(FileStream))
			{
				PEImageReader.ReadImage();
				Debugger.Break();
			}

			Debugger.Break();
		}


		public static void TestMachOImageReader()
		{
			string Path1 = @"D:\Project\My\20140607_Xamarin\Code\Xamarin\Xamarin.BundleTool\bin\Debug\20140822\Mac\mtouch";
			string Path2 = @"D:\Project\My\20140607_Xamarin\Code\Xamarin\Xamarin.BundleTool\bin\Debug\20140822\Mac\mtouch-64";

			using (var FileStream = new FileStream(Path1, FileMode.Open))
			using (var PEImageReader = new MachOImageReader(FileStream))
			{
				PEImageReader.ReadImage();
				Debugger.Break();
			}
		}

	}
}
