using FNMainLauncher.Providers;
using System;

namespace FNainLauncher.Providers
{
	// Token: 0x0200000B RID: 11
	internal static class Launcher
	{
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00002B34 File Offset: 0x00000D34
		public static bool IsUpToDate
		{
			get
			{
				return Api.Version == App.Version;
			}
		}
	}
}
