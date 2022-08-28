using FNainLauncher.Providers;
using FNMainLauncher.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FN.FN
{
    public partial class BRFORM : Form
    {
        public BRFORM()
        {
            InitializeComponent();
			this.Configuration = new Configuration();
			this.Configuration.Open();
			this._commonHeartbeat = new Thread(new ThreadStart(this.CommonHeartbeat));
			this._commonHeartbeat.IsBackground = true;
			this._commonHeartbeat.Start();
		}
		// Token: 0x0600004D RID: 77 RVA: 0x00002D1C File Offset: 0x00000F1C
		private void SetOnlineText(string text)
		{
			bool invokeRequired = base.InvokeRequired;
			bool flag = invokeRequired;
			if (flag)
			{
				BRFORM.SetOnlineTextDelegate method = new BRFORM.SetOnlineTextDelegate(this.SetOnlineText);
				base.Invoke(method, new object[]
				{
					text
				});
			}
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00002D58 File Offset: 0x00000F58
		private void SetShow()
		{
			bool invokeRequired = base.InvokeRequired;
			bool flag = invokeRequired;
			if (flag)
			{
				BRFORM.SetShowDelegate method = new BRFORM.SetShowDelegate(this.SetShow);
				base.Invoke(method);
			}
			else
			{
				base.Show();
			}
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00002D94 File Offset: 0x00000F94
		private void SetHide()
		{
			bool invokeRequired = base.InvokeRequired;
			bool flag = invokeRequired;
			if (flag)
			{
				BRFORM.SetHideDelegate method = new BRFORM.SetHideDelegate(this.SetHide);
				base.Invoke(method);
			}
			else
			{
				base.Hide();
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00002DD0 File Offset: 0x00000FD0
		private void CommonHeartbeat()
		{
			for (; ; )
			{
				bool isHandleCreated = base.IsHandleCreated;
				bool flag = isHandleCreated;
				if (flag)
				{
					bool flag2 = this._clientProcess != null;
					bool flag3 = flag2;
					if (flag3)
					{
						bool flag4 = !this._clientProcess.HasExited;
						bool flag5 = flag4;
						if (flag5)
						{
							this._onlinePaused = true;
							this.SetHide();
						}
						else
						{
							this._clientProcess = null;
						}
					}
					else
					{
						this._onlinePaused = false;
						this.SetShow();
					}
					Thread.Sleep(2000);
				}
				Thread.Sleep(1);
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00002E5C File Offset: 0x0000105C
		private void OnlineHeartbeat()
		{
			for (; ; )
			{
				bool flag = base.IsHandleCreated && !this._onlinePaused;
				bool flag2 = flag;
				if (flag2)
				{
					this.SetOnlineText(string.Format("Online: {0}, Parties: {1}", Api.Clients, Api.Parties));
					Thread.Sleep(4000);
				}
				Thread.Sleep(1);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x00002EC4 File Offset: 0x000010C4
		private bool CheckUpdates(string source = "")
		{
			bool flag = !Launcher.IsUpToDate;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				bool flag4 = source != "Launch";
				bool flag5 = flag4;
				if (flag5)
				{
					bool flag6 = !this._showedUpdate;
					bool flag7 = flag6;
					if (flag7)
					{
						this._showedUpdate = true;
					}
				}
				this.siticoneButton3.Text = "Update";
			}
			return flag;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x00002F2D File Offset: 0x0000112D
		private void materialSingleLineTextFieldEmail_TextChanged(object sender, EventArgs e)
		{
			this.Configuration.Email = this.materialSingleLineTextFieldEmail.Text;
			this.Configuration.Save();
		}

		// Token: 0x06000054 RID: 84 RVA: 0x00002F53 File Offset: 0x00001153
		private void materialSingleLineTextFieldPassword_TextChanged(object sender, EventArgs e)
		{
			this.Configuration.Save();
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00002F64 File Offset: 0x00001164
		public static bool IsValidPath(string path)
		{
			Regex regex = new Regex("^[a-zA-Z]:\\\\$");
			bool flag = !regex.IsMatch(path.Substring(0, 3));
			bool flag2 = flag;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				string text = new string(Path.GetInvalidPathChars());
				text += ":/?*\"";
				Regex regex2 = new Regex("[" + Regex.Escape(text) + "]");
				bool flag3 = regex2.IsMatch(path.Substring(3, path.Length - 3));
				result = !flag3;
			}
			return result;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00002FF8 File Offset: 0x000011F8
		private bool IsValidEmail(string address)
		{
			bool result;
			try
			{
				new MailAddress(address);
				result = true;
			}
			catch (FormatException)
			{
				result = false;
			}
			return result;
		}
		public object folderBrowserDialogBrowse { get; private set; }
        internal Configuration Configuration { get => configuration; set => configuration = value; }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {

			Settings form2 = new Settings();
			form2.Show();
		}

        private Configuration configuration;

        // Token: 0x0400002A RID: 42
        private Settings _settings;

		// Token: 0x0400002B RID: 43
		private Thread _commonHeartbeat;

		// Token: 0x0400002C RID: 44
		private Thread _onlineHeartbeat;

		// Token: 0x0400002D RID: 45
		private bool _onlinePaused;

		// Token: 0x0400002E RID: 46
		private bool _showedUpdate;

		// Token: 0x0400002F RID: 47
		private Process _clientProcess;

		// Token: 0x04000030 RID: 48
		private int _clientAnticheat = 1;

		// Token: 0x04000031 RID: 49
		private object folderBrowserDialogInstallLocationBrowse;

		// Token: 0x02000017 RID: 23
		// (Invoke) Token: 0x0600008F RID: 143
		private delegate void SetOnlineTextDelegate(string text);

		// Token: 0x02000018 RID: 24
		// (Invoke) Token: 0x06000093 RID: 147
		private delegate void SetShowDelegate();

		// Token: 0x02000019 RID: 25
		// (Invoke) Token: 0x06000097 RID: 151
		private delegate void SetHideDelegate();

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
			bool flag = string.IsNullOrEmpty(this.materialSingleLineTextFieldEmail.Text) || this.materialSingleLineTextFieldEmail.Text.Length < 3;
			bool flag2 = flag;
			if (flag2)
			{
				MessageBox.Show("Username cannot be empty or below 3 characters.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				try
				{
					bool flag3 = !BRFORM.IsValidPath(this.Configuration.InstallLocation);
					bool flag4 = flag3;
					if (flag4)
					{
						MessageBox.Show("Invalid installation path.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				catch
				{
					MessageBox.Show("Invalid installation path.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				string text = Path.Combine(this.Configuration.InstallLocation, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
				bool flag5 = !File.Exists(text);
				bool flag6 = flag5;
				if (flag6)
				{
					string text2 = "\"" + text + "\" was not found, please make sure it exists.\n\nDid you set the Install Location correctly?\n\nTIP: The Install Location must be set to a folder that contains 2 folders named \"Engine\" and \"FortniteGame\".";
					MessageBox.Show(text2, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					string text3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Platanium.dll");
					bool flag7 = !File.Exists(text3);
					bool flag8 = flag7;
					if (flag8)
					{
						string text4 = "\"" + text3 + "\" was not found, please make sure it exists.\n\nDid you extract all files from the ZIP when you downloaded  Launcher?\n\nTIP: \"Platanium.dll\" must be in the same directory as FN Launcher.";
						MessageBox.Show(text4, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						string text5 = string.Concat(new string[]
						{
							"-AUTH_LOGIN=",
							this.Configuration.Email,
							" -AUTH_PASSWORD=",
							this.Configuration.Password,
							" -AUTH_TYPE=epic ",
							this.Configuration.Arguments,
							" -epiclocale=en -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -frombe"
						});
						bool flag9 = this._clientAnticheat == 0;
						bool flag10 = flag9;
						if (flag10)
						{
							text5 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -skippatchcheck -epiclocale=en -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -frombe";
						}
						else
						{
							bool flag11 = this._clientAnticheat == 1;
							bool flag12 = flag11;
							if (flag12)
							{
								text5 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -skippatchcheck -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac ";
							}
							else
							{
								bool flag13 = this._clientAnticheat == 2;
								bool flag14 = flag13;
								if (flag14)
								{
									text5 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -skippatchcheck -nobe -fromfl=eac -fltoken=h1h4370717422124b232eFac ";
								}
							}
						}
						this._clientProcess = new Process
						{
							StartInfo = new ProcessStartInfo(text, text5)
							{
								UseShellExecute = false,
								RedirectStandardOutput = true,
								CreateNoWindow = true
							}
						};
						this._clientProcess.Start();
						Helper.InjectDll(this._clientProcess.Id, text3);
					}
				}
			}
		}

        private void BRFORM_Load(object sender, EventArgs e)
        {

        }

        private void BRFORM_Load_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
			Settings form2 = new Settings();
			form2.Show();
		}

        private void button1_Click(object sender, EventArgs e)
        {
			bool flag = string.IsNullOrEmpty(this.textBox1.Text) || this.textBox1.Text.Length < 3;
			bool flag2 = flag;
			if (flag2)
			{
				MessageBox.Show("Username cannot be empty or below 3 characters.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				try
				{
					bool flag3 = !BRFORM.IsValidPath(this.Configuration.InstallLocation);
					bool flag4 = flag3;
					if (flag4)
					{
						MessageBox.Show("Invalid installation path.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				catch
				{
					MessageBox.Show("Invalid installation path.", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
				string text = Path.Combine(this.Configuration.InstallLocation, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe");
				bool flag5 = !File.Exists(text);
				bool flag6 = flag5;
				if (flag6)
				{
					string text2 = "\"" + text + "\" was not found, please make sure it exists.\n\nDid you set the Install Location correctly?\n\nTIP: The Install Location must be set to a folder that contains 2 folders named \"Engine\" and \"FortniteGame\".";
					MessageBox.Show(text2, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					string text3 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Platanium.dll");
					bool flag7 = !File.Exists(text3);
					bool flag8 = flag7;
					if (flag8)
					{
						string text4 = "\"" + text3 + "\" was not found, please make sure it exists.\n\nDid you extract all files from the ZIP when you downloaded  Launcher?\n\nTIP: \"Platanium.dll\" must be in the same directory as FN Launcher.";
						MessageBox.Show(text4, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					else
					{
						string text5 = string.Concat(new string[]
						{
							"-AUTH_LOGIN=",
							this.Configuration.Email,
							" -AUTH_PASSWORD=",
							this.Configuration.Password,
							" -AUTH_TYPE=epic ",
							this.Configuration.Arguments,
							" -epiclocale=en -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -frombe"
						});
						bool flag9 = this._clientAnticheat == 0;
						bool flag10 = flag9;
						if (flag10)
						{
							text5 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -skippatchcheck -epiclocale=en -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -frombe";
						}
						else
						{
							bool flag11 = this._clientAnticheat == 1;
							bool flag12 = flag11;
							if (flag12)
							{
								text5 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -skippatchcheck -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac ";
							}
							else
							{
								bool flag13 = this._clientAnticheat == 2;
								bool flag14 = flag13;
								if (flag14)
								{
									text5 += " -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1h4370717422124b232eFac  -skippatchcheck -nobe -fromfl=eac -fltoken=h1h4370717422124b232eFac ";
								}
							}
						}
						this._clientProcess = new Process
						{
							StartInfo = new ProcessStartInfo(text, text5)
							{
								UseShellExecute = false,
								RedirectStandardOutput = true,
								CreateNoWindow = true
							}
						};
						this._clientProcess.Start();
						Helper.InjectDll(this._clientProcess.Id, text3);
					}
				}
			}
		}
    }
}
