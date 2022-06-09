using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using KeyAuth;
using LogIn_Theme_Dll_By_xVenoxi;
using TestKey.Properties;

namespace TestKey
{
	// Token: 0x0200000D RID: 13
	public partial class Form1 : Form
	{
		// Token: 0x06000081 RID: 129 RVA: 0x00002381 File Offset: 0x00000581
		public Form1()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00003EEC File Offset: 0x000020EC
		private void Form1_Load(object sender, EventArgs e)
		{
			Form1.KeyAuthApp.init();
			bool flag = Form1.KeyAuthApp.response.message == "invalidver";
			if (flag)
			{
				bool flag2 = !string.IsNullOrEmpty(Form1.KeyAuthApp.app_data.downloadLink);
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Yes to open file in browser\nNo to download file automatically", "Auto update", MessageBoxButtons.YesNo);
					DialogResult dialogResult2 = dialogResult;
					DialogResult dialogResult3 = dialogResult2;
					if (dialogResult3 != DialogResult.Yes)
					{
						if (dialogResult3 != DialogResult.No)
						{
							MessageBox.Show("Invalid option");
							Environment.Exit(0);
						}
						else
						{
							WebClient webClient = new WebClient();
							string text = Application.ExecutablePath;
							string str = Form1.random_string();
							text = text.Replace(".exe", "-" + str + ".exe");
							webClient.DownloadFile(Form1.KeyAuthApp.app_data.downloadLink, text);
							Process.Start(text);
							Process.Start(new ProcessStartInfo
							{
								Arguments = "/C choice /C Y /N /D Y /T 3 & Del \"" + Application.ExecutablePath + "\"",
								WindowStyle = ProcessWindowStyle.Hidden,
								CreateNoWindow = true,
								FileName = "cmd.exe"
							});
							Environment.Exit(0);
						}
					}
					else
					{
						Process.Start(Form1.KeyAuthApp.app_data.downloadLink);
						Environment.Exit(0);
					}
				}
				MessageBox.Show("Version of this program does not match the one online. Furthermore, the download link online isn't set. You will need to manually obtain the download link from the developer");
				Thread.Sleep(2500);
				Environment.Exit(0);
			}
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00004060 File Offset: 0x00002260
		private static string random_string()
		{
			string text = null;
			Random random = new Random();
			for (int i = 0; i < 5; i++)
			{
				text += Convert.ToChar(Convert.ToInt32(Math.Floor(26.0 * random.NextDouble() + 65.0))).ToString();
			}
			return text;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000040CC File Offset: 0x000022CC
		private void button2_Click(object sender, EventArgs e)
		{
			Form1.KeyAuthApp.register(this.username.Text, this.password.Text, this.key.Text);
			bool success = Form1.KeyAuthApp.response.success;
			if (success)
			{
				Form2 form = new Form2();
				form.Show();
				base.Hide();
			}
			else
			{
				MessageBox.Show("Invalid");
			}
		}

		// Token: 0x06000085 RID: 133 RVA: 0x00002399 File Offset: 0x00000599
		private void button2_Click_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000086 RID: 134 RVA: 0x00002399 File Offset: 0x00000599
		private void button1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000087 RID: 135 RVA: 0x0000413C File Offset: 0x0000233C
		private void logInButton1_Click(object sender, EventArgs e)
		{
			Form1.KeyAuthApp.login(this.username.Text, this.password.Text);
			bool success = Form1.KeyAuthApp.response.success;
			if (success)
			{
				Form2 form = new Form2();
				form.Show();
				base.Hide();
			}
			else
			{
				MessageBox.Show("Invalid");
			}
		}

		// Token: 0x06000088 RID: 136 RVA: 0x000040CC File Offset: 0x000022CC
		private void logInButton2_Click(object sender, EventArgs e)
		{
			Form1.KeyAuthApp.register(this.username.Text, this.password.Text, this.key.Text);
			bool success = Form1.KeyAuthApp.response.success;
			if (success)
			{
				Form2 form = new Form2();
				form.Show();
				base.Hide();
			}
			else
			{
				MessageBox.Show("Invalid");
			}
		}

		// Token: 0x04000037 RID: 55
		public static api KeyAuthApp = new api("KGB AIO", "nJZupTUgrm", "b8f248fe1bb3cc190382c54ea4e6c77a82fffce0d9ff6e2f588a07473e517ed2", "1.0");

        private void logInThemeContainer1_Click(object sender, EventArgs e)
        {

        }
    }
}
