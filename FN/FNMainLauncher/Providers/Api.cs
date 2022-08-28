using System;
using System.Net;
using RestSharp;

namespace FNMainLauncher.Providers
{
	// Token: 0x02000007 RID: 7
	internal static class Api
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000023 RID: 35 RVA: 0x00002764 File Offset: 0x00000964
		public static string Version
		{
			get
			{
				return Api.GetVersion();
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000024 RID: 36 RVA: 0x0000277C File Offset: 0x0000097C
		public static int Clients
		{
			get
			{
				return Api.GetClients();
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00002794 File Offset: 0x00000994
		public static int Parties
		{
			get
			{
				return Api.GetParties();
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x000027AB File Offset: 0x000009AB
		private static void SetApi()
		{
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			Api._client.UserAgent = "FNMainLauncher/" + App.Version;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x000027D4 File Offset: 0x000009D4
		private static string GetVersion()
		{
			Api.SetApi();
			string text = Api._client.Get(new RestRequest("files/version")).Content;
			bool flag = string.IsNullOrEmpty(text);
			bool flag2 = flag;
			if (flag2)
			{
				text = App.Version;
			}
			return text;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000281C File Offset: 0x00000A1C
		private static int GetClients()
		{
			Api.SetApi();
			string content = Api._client.Get(new RestRequest("id/api/clients")).Content;
			int result;
			try
			{
				bool flag = !string.IsNullOrEmpty(content);
				bool flag2 = flag;
				if (flag2)
				{
					result = Convert.ToInt32(content);
				}
				else
				{
					result = 0;
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000288C File Offset: 0x00000A8C
		private static int GetParties()
		{
			Api.SetApi();
			string content = Api._client.Get(new RestRequest("id/api/parties")).Content;
			int result;
			try
			{
				bool flag = !string.IsNullOrEmpty(content);
				bool flag2 = flag;
				if (flag2)
				{
					result = Convert.ToInt32(content);
				}
				else
				{
					result = 0;
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x04000014 RID: 20
		private static RestClient _client = new RestClient("https://www.server.com/");
	}
}
