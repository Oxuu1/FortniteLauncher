using System;
using System.Diagnostics;
using System.Reflection;

namespace FNMainLauncher.Providers
{
	// Token: 0x02000008 RID: 8
	internal static class App
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002910 File Offset: 0x00000B10
		public static string Version
		{
			get
			{
				return "v" + FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
			}
		}
	}
}
