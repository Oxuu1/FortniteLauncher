using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace FNMainLauncher.Providers
{
	// Token: 0x02000009 RID: 9
	internal class Configuration
	{
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600002C RID: 44 RVA: 0x00002940 File Offset: 0x00000B40
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00002948 File Offset: 0x00000B48
		[JsonProperty("InstallLocation")]
		public string InstallLocation { get; set; }

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002951 File Offset: 0x00000B51
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002959 File Offset: 0x00000B59
		[JsonProperty("Arguments")]
		public string Arguments { get; set; }

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00002962 File Offset: 0x00000B62
		// (set) Token: 0x06000031 RID: 49 RVA: 0x0000296A File Offset: 0x00000B6A
		[JsonProperty("Email")]
		public string Email { get; set; }

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00002973 File Offset: 0x00000B73
		// (set) Token: 0x06000033 RID: 51 RVA: 0x0000297B File Offset: 0x00000B7B
		[JsonProperty("Password")]
		public string Password { get; set; }

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000034 RID: 52 RVA: 0x00002984 File Offset: 0x00000B84
		// (set) Token: 0x06000035 RID: 53 RVA: 0x0000298C File Offset: 0x00000B8C
		[JsonProperty("DarkMode")]
		public bool DarkMode { get; set; }

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00002995 File Offset: 0x00000B95
		// (set) Token: 0x06000037 RID: 55 RVA: 0x0000299D File Offset: 0x00000B9D
		[JsonProperty("DisableOnline")]
		public bool DisableOnline { get; set; }

		// Token: 0x06000038 RID: 56 RVA: 0x000029A8 File Offset: 0x00000BA8
		public void Open()
		{
			bool flag = File.Exists(this._path);
			bool flag2 = flag;
			if (flag2)
			{
				Configuration configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(this._path));
				this.InstallLocation = configuration.InstallLocation;
				this.Arguments = configuration.Arguments;
				this.Email = configuration.Email;
				this.Password = configuration.Password;
				this.DarkMode = configuration.DarkMode;
				this.DisableOnline = configuration.DisableOnline;
			}
			else
			{
				foreach (EpicGames.Installed.Installation installation in EpicGames.LauncherInstalled.InstallationList)
				{
					bool flag3 = installation.AppName == "Fortnite";
					bool flag4 = flag3;
					if (flag4)
					{
						this.InstallLocation = installation.InstallLocation;
					}
				}
				this.DarkMode = true;
				this.Save();
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002A8C File Offset: 0x00000C8C
		public void Save()
		{
			File.WriteAllText(this._path, JsonConvert.SerializeObject(this));
		}

		// Token: 0x0400001B RID: 27
		private string _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Configuration.json");
	}
}
