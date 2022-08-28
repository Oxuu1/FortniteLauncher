using FN.FN;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FN
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new BRFORM());
        }
		private static void Swap()
		{
			bool flag = File.Exists("FortniteLauncher.exe.original");
			bool flag2 = flag;
			if (flag2)
			{
				File.Move("FortniteLauncher.exe", "FortniteLauncher.exe.custom");
				File.Move("FortniteLauncher.exe.original", "FortniteLauncher.exe");
			}
			bool flag3 = File.Exists("FortniteLauncher.exe.custom");
			bool flag4 = flag3;
			if (flag4)
			{
				File.Move("FortniteLauncher.exe", "FortniteLauncher.exe.original");
				File.Move("FortniteLauncher.exe.custom", "FortniteLauncher.exe");
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003AF0 File Offset: 0x00001CF0
		private static bool Routine(int dwCtrlType)
		{
			bool flag = dwCtrlType == 2;
			if (flag)
			{
				bool flag2 = !Program._clientProcess.HasExited;
				bool flag3 = flag2;
				if (flag3)
				{
					Program._clientProcess.Kill();
				}
			}
			return false;
		}

		// Token: 0x04000039 RID: 57
		private static Process _clientProcess;

		// Token: 0x0400003A RID: 58
		private static byte _clientAnticheat;
	}
}
