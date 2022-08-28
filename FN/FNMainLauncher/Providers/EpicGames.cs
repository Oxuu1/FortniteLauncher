using System;
using System.IO;
using Newtonsoft.Json;

namespace FNMainLauncher.Providers
{
	// Token: 0x0200000A RID: 10
	internal static class EpicGames
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00002ACC File Offset: 0x00000CCC
		public static EpicGames.Installed LauncherInstalled
		{
			get
			{
				return EpicGames.GetLauncherInstalled();
			}
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002AE4 File Offset: 0x00000CE4
		private static EpicGames.Installed GetLauncherInstalled()
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Epic\\UnrealEngineLauncher\\LauncherInstalled.dat");
			bool flag = !File.Exists(path);
			bool flag2 = flag;
			EpicGames.Installed result;
			if (flag2)
			{
				result = new EpicGames.Installed();
			}
			else
			{
				result = JsonConvert.DeserializeObject<EpicGames.Installed>(File.ReadAllText(path));
			}
			return result;
		}

		// Token: 0x02000016 RID: 22
		public class Installed
		{
			// Token: 0x17000015 RID: 21
			// (get) Token: 0x0600008B RID: 139 RVA: 0x00004175 File Offset: 0x00002375
			// (set) Token: 0x0600008C RID: 140 RVA: 0x0000417D File Offset: 0x0000237D
			[JsonProperty("InstallationList")]
			public EpicGames.Installed.Installation[] InstallationList { get; set; }

			// Token: 0x0200001A RID: 26
			public class Installation
			{
				// Token: 0x17000016 RID: 22
				// (get) Token: 0x0600009A RID: 154 RVA: 0x00004186 File Offset: 0x00002386
				// (set) Token: 0x0600009B RID: 155 RVA: 0x0000418E File Offset: 0x0000238E
				[JsonProperty("InstallLocation")]
				public string InstallLocation { get; set; }

				// Token: 0x17000017 RID: 23
				// (get) Token: 0x0600009C RID: 156 RVA: 0x00004197 File Offset: 0x00002397
				// (set) Token: 0x0600009D RID: 157 RVA: 0x0000419F File Offset: 0x0000239F
				[JsonProperty("AppName")]
				public string AppName { get; set; }

				// Token: 0x17000018 RID: 24
				// (get) Token: 0x0600009E RID: 158 RVA: 0x000041A8 File Offset: 0x000023A8
				// (set) Token: 0x0600009F RID: 159 RVA: 0x000041B0 File Offset: 0x000023B0
				[JsonProperty("AppVersion")]
				public string AppVersion { get; set; }
			}
		}
	}
}
