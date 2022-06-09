using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace KeyAuth
{
	// Token: 0x02000002 RID: 2
	public class api
	{
		// Token: 0x06000001 RID: 1 RVA: 0x0000243C File Offset: 0x0000063C
		public api(string name, string ownerid, string secret, string version)
		{
			bool flag = string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version);
			if (flag)
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000024DC File Offset: 0x000006DC
		public void init()
		{
			this.enckey = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.enckey, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			bool flag = text2 == "KeyAuth_Invalid";
			if (flag)
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_app_data(response_structure.appinfo);
				this.sessionid = response_structure.sessionid;
				this.initzalized = true;
			}
			else
			{
				bool flag2 = response_structure.message == "invalidver";
				if (flag2)
				{
					this.app_data.downloadLink = response_structure.download;
				}
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000003 RID: 3 RVA: 0x00002680 File Offset: 0x00000880
		public static bool IsDebugRelease
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002694 File Offset: 0x00000894
		public void Checkinit()
		{
			bool flag = !this.initzalized;
			if (flag)
			{
				bool isDebugRelease = api.IsDebugRelease;
				if (isDebugRelease)
				{
					api.error("Not initialized Check if KeyAuthApp.init() does exist");
				}
				else
				{
					api.error("Please initialize first");
				}
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000026D8 File Offset: 0x000008D8
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x0000284C File Offset: 0x00000A4C
		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000029A4 File Offset: 0x00000BA4
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.enckey, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			response_structure.success = false;
			this.load_response_struct(response_structure);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002AD4 File Offset: 0x00000CD4
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.enckey, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			if (success)
			{
				this.load_user_data(response_structure.info);
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002C14 File Offset: 0x00000E14
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002CF4 File Offset: 0x00000EF4
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data2 = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data2);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002E08 File Offset: 0x00001008
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002F20 File Offset: 0x00001120
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure data = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(data);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00003000 File Offset: 0x00001200
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x0000312C File Offset: 0x0000132C
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			List<api.msg> result;
			if (success)
			{
				result = response_structure.messages;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00003244 File Offset: 0x00001444
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.enckey, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003370 File Offset: 0x00001570
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			return response_structure.success;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003494 File Offset: 0x00001694
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.enckey, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.enckey, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.enckey, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			string result;
			if (success)
			{
				result = response_structure.response;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000035F8 File Offset: 0x000017F8
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			string text2 = api.req(post_data);
			text2 = encryption.decrypt(text2, this.enckey, text);
			api.response_structure response_structure = this.response_decoder.string_to_generic<api.response_structure>(text2);
			this.load_response_struct(response_structure);
			bool success = response_structure.success;
			byte[] result;
			if (success)
			{
				result = encryption.str_to_byte_arr(response_structure.contents);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003714 File Offset: 0x00001914
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.enckey, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.enckey, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.sessionid));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection post_data = nameValueCollection;
			api.req(post_data);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003808 File Offset: 0x00001A08
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					byte[] value = md.ComputeHash(fileStream);
					result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00003888 File Offset: 0x00001A88
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000038E0 File Offset: 0x00001AE0
		private static string req(NameValueCollection post_data)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", post_data);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
				HttpStatusCode statusCode = httpWebResponse.StatusCode;
				HttpStatusCode httpStatusCode = statusCode;
				if (httpStatusCode != (HttpStatusCode)429)
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					Thread.Sleep(1000);
					result = api.req(post_data);
				}
			}
			return result;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003990 File Offset: 0x00001B90
		private void load_app_data(api.app_data_structure data)
		{
			this.app_data.numUsers = data.numUsers;
			this.app_data.numOnlineUsers = data.numOnlineUsers;
			this.app_data.numKeys = data.numKeys;
			this.app_data.version = data.version;
			this.app_data.customerPanelLink = data.customerPanelLink;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000039F8 File Offset: 0x00001BF8
		private void load_user_data(api.user_data_structure data)
		{
			this.user_data.username = data.username;
			this.user_data.ip = data.ip;
			this.user_data.hwid = data.hwid;
			this.user_data.createdate = data.createdate;
			this.user_data.lastlogin = data.lastlogin;
			this.user_data.subscriptions = data.subscriptions;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003A74 File Offset: 0x00001C74
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002050 File Offset: 0x00000250
		private void load_response_struct(api.response_structure data)
		{
			this.response.success = data.success;
			this.response.message = data.message;
		}

		// Token: 0x04000001 RID: 1
		public string name;

		// Token: 0x04000002 RID: 2
		public string ownerid;

		// Token: 0x04000003 RID: 3
		public string secret;

		// Token: 0x04000004 RID: 4
		public string version;

		// Token: 0x04000005 RID: 5
		private string sessionid;

		// Token: 0x04000006 RID: 6
		private string enckey;

		// Token: 0x04000007 RID: 7
		private bool initzalized;

		// Token: 0x04000008 RID: 8
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x04000009 RID: 9
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x0400000A RID: 10
		public api.response_class response = new api.response_class();

		// Token: 0x0400000B RID: 11
		private json_wrapper response_decoder = new json_wrapper(new api.response_structure());

		// Token: 0x02000003 RID: 3
		[DataContract]
		private class response_structure
		{
			// Token: 0x17000002 RID: 2
			// (get) Token: 0x0600001B RID: 27 RVA: 0x00002077 File Offset: 0x00000277
			// (set) Token: 0x0600001C RID: 28 RVA: 0x0000207F File Offset: 0x0000027F
			[DataMember]
			public bool success { get; set; }

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x0600001D RID: 29 RVA: 0x00002088 File Offset: 0x00000288
			// (set) Token: 0x0600001E RID: 30 RVA: 0x00002090 File Offset: 0x00000290
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000004 RID: 4
			// (get) Token: 0x0600001F RID: 31 RVA: 0x00002099 File Offset: 0x00000299
			// (set) Token: 0x06000020 RID: 32 RVA: 0x000020A1 File Offset: 0x000002A1
			[DataMember]
			public string contents { get; set; }

			// Token: 0x17000005 RID: 5
			// (get) Token: 0x06000021 RID: 33 RVA: 0x000020AA File Offset: 0x000002AA
			// (set) Token: 0x06000022 RID: 34 RVA: 0x000020B2 File Offset: 0x000002B2
			[DataMember]
			public string response { get; set; }

			// Token: 0x17000006 RID: 6
			// (get) Token: 0x06000023 RID: 35 RVA: 0x000020BB File Offset: 0x000002BB
			// (set) Token: 0x06000024 RID: 36 RVA: 0x000020C3 File Offset: 0x000002C3
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000007 RID: 7
			// (get) Token: 0x06000025 RID: 37 RVA: 0x000020CC File Offset: 0x000002CC
			// (set) Token: 0x06000026 RID: 38 RVA: 0x000020D4 File Offset: 0x000002D4
			[DataMember]
			public string download { get; set; }

			// Token: 0x17000008 RID: 8
			// (get) Token: 0x06000027 RID: 39 RVA: 0x000020DD File Offset: 0x000002DD
			// (set) Token: 0x06000028 RID: 40 RVA: 0x000020E5 File Offset: 0x000002E5
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.user_data_structure info { get; set; }

			// Token: 0x17000009 RID: 9
			// (get) Token: 0x06000029 RID: 41 RVA: 0x000020EE File Offset: 0x000002EE
			// (set) Token: 0x0600002A RID: 42 RVA: 0x000020F6 File Offset: 0x000002F6
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.app_data_structure appinfo { get; set; }

			// Token: 0x1700000A RID: 10
			// (get) Token: 0x0600002B RID: 43 RVA: 0x000020FF File Offset: 0x000002FF
			// (set) Token: 0x0600002C RID: 44 RVA: 0x00002107 File Offset: 0x00000307
			[DataMember]
			public List<api.msg> messages { get; set; }
		}

		// Token: 0x02000004 RID: 4
		public class msg
		{
			// Token: 0x1700000B RID: 11
			// (get) Token: 0x0600002E RID: 46 RVA: 0x00002119 File Offset: 0x00000319
			// (set) Token: 0x0600002F RID: 47 RVA: 0x00002121 File Offset: 0x00000321
			public string message { get; set; }

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x06000030 RID: 48 RVA: 0x0000212A File Offset: 0x0000032A
			// (set) Token: 0x06000031 RID: 49 RVA: 0x00002132 File Offset: 0x00000332
			public string author { get; set; }

			// Token: 0x1700000D RID: 13
			// (get) Token: 0x06000032 RID: 50 RVA: 0x0000213B File Offset: 0x0000033B
			// (set) Token: 0x06000033 RID: 51 RVA: 0x00002143 File Offset: 0x00000343
			public string timestamp { get; set; }
		}

		// Token: 0x02000005 RID: 5
		[DataContract]
		private class user_data_structure
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000035 RID: 53 RVA: 0x0000214C File Offset: 0x0000034C
			// (set) Token: 0x06000036 RID: 54 RVA: 0x00002154 File Offset: 0x00000354
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000037 RID: 55 RVA: 0x0000215D File Offset: 0x0000035D
			// (set) Token: 0x06000038 RID: 56 RVA: 0x00002165 File Offset: 0x00000365
			[DataMember]
			public string ip { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x06000039 RID: 57 RVA: 0x0000216E File Offset: 0x0000036E
			// (set) Token: 0x0600003A RID: 58 RVA: 0x00002176 File Offset: 0x00000376
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600003B RID: 59 RVA: 0x0000217F File Offset: 0x0000037F
			// (set) Token: 0x0600003C RID: 60 RVA: 0x00002187 File Offset: 0x00000387
			[DataMember]
			public string createdate { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600003D RID: 61 RVA: 0x00002190 File Offset: 0x00000390
			// (set) Token: 0x0600003E RID: 62 RVA: 0x00002198 File Offset: 0x00000398
			[DataMember]
			public string lastlogin { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x0600003F RID: 63 RVA: 0x000021A1 File Offset: 0x000003A1
			// (set) Token: 0x06000040 RID: 64 RVA: 0x000021A9 File Offset: 0x000003A9
			[DataMember]
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000006 RID: 6
		[DataContract]
		private class app_data_structure
		{
			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000042 RID: 66 RVA: 0x000021B2 File Offset: 0x000003B2
			// (set) Token: 0x06000043 RID: 67 RVA: 0x000021BA File Offset: 0x000003BA
			[DataMember]
			public string numUsers { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000044 RID: 68 RVA: 0x000021C3 File Offset: 0x000003C3
			// (set) Token: 0x06000045 RID: 69 RVA: 0x000021CB File Offset: 0x000003CB
			[DataMember]
			public string numOnlineUsers { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000046 RID: 70 RVA: 0x000021D4 File Offset: 0x000003D4
			// (set) Token: 0x06000047 RID: 71 RVA: 0x000021DC File Offset: 0x000003DC
			[DataMember]
			public string numKeys { get; set; }

			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000048 RID: 72 RVA: 0x000021E5 File Offset: 0x000003E5
			// (set) Token: 0x06000049 RID: 73 RVA: 0x000021ED File Offset: 0x000003ED
			[DataMember]
			public string version { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600004A RID: 74 RVA: 0x000021F6 File Offset: 0x000003F6
			// (set) Token: 0x0600004B RID: 75 RVA: 0x000021FE File Offset: 0x000003FE
			[DataMember]
			public string customerPanelLink { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600004C RID: 76 RVA: 0x00002207 File Offset: 0x00000407
			// (set) Token: 0x0600004D RID: 77 RVA: 0x0000220F File Offset: 0x0000040F
			[DataMember]
			public string downloadLink { get; set; }
		}

		// Token: 0x02000007 RID: 7
		public class app_data_class
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x0600004F RID: 79 RVA: 0x00002218 File Offset: 0x00000418
			// (set) Token: 0x06000050 RID: 80 RVA: 0x00002220 File Offset: 0x00000420
			public string numUsers { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000051 RID: 81 RVA: 0x00002229 File Offset: 0x00000429
			// (set) Token: 0x06000052 RID: 82 RVA: 0x00002231 File Offset: 0x00000431
			public string numOnlineUsers { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000053 RID: 83 RVA: 0x0000223A File Offset: 0x0000043A
			// (set) Token: 0x06000054 RID: 84 RVA: 0x00002242 File Offset: 0x00000442
			public string numKeys { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000055 RID: 85 RVA: 0x0000224B File Offset: 0x0000044B
			// (set) Token: 0x06000056 RID: 86 RVA: 0x00002253 File Offset: 0x00000453
			public string version { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000057 RID: 87 RVA: 0x0000225C File Offset: 0x0000045C
			// (set) Token: 0x06000058 RID: 88 RVA: 0x00002264 File Offset: 0x00000464
			public string customerPanelLink { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x06000059 RID: 89 RVA: 0x0000226D File Offset: 0x0000046D
			// (set) Token: 0x0600005A RID: 90 RVA: 0x00002275 File Offset: 0x00000475
			public string downloadLink { get; set; }
		}

		// Token: 0x02000008 RID: 8
		public class user_data_class
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600005C RID: 92 RVA: 0x0000227E File Offset: 0x0000047E
			// (set) Token: 0x0600005D RID: 93 RVA: 0x00002286 File Offset: 0x00000486
			public string username { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600005E RID: 94 RVA: 0x0000228F File Offset: 0x0000048F
			// (set) Token: 0x0600005F RID: 95 RVA: 0x00002297 File Offset: 0x00000497
			public string ip { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000060 RID: 96 RVA: 0x000022A0 File Offset: 0x000004A0
			// (set) Token: 0x06000061 RID: 97 RVA: 0x000022A8 File Offset: 0x000004A8
			public string hwid { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000062 RID: 98 RVA: 0x000022B1 File Offset: 0x000004B1
			// (set) Token: 0x06000063 RID: 99 RVA: 0x000022B9 File Offset: 0x000004B9
			public string createdate { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000064 RID: 100 RVA: 0x000022C2 File Offset: 0x000004C2
			// (set) Token: 0x06000065 RID: 101 RVA: 0x000022CA File Offset: 0x000004CA
			public string lastlogin { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000066 RID: 102 RVA: 0x000022D3 File Offset: 0x000004D3
			// (set) Token: 0x06000067 RID: 103 RVA: 0x000022DB File Offset: 0x000004DB
			public List<api.Data> subscriptions { get; set; }
		}

		// Token: 0x02000009 RID: 9
		public class Data
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x06000069 RID: 105 RVA: 0x000022E4 File Offset: 0x000004E4
			// (set) Token: 0x0600006A RID: 106 RVA: 0x000022EC File Offset: 0x000004EC
			public string subscription { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600006B RID: 107 RVA: 0x000022F5 File Offset: 0x000004F5
			// (set) Token: 0x0600006C RID: 108 RVA: 0x000022FD File Offset: 0x000004FD
			public string expiry { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600006D RID: 109 RVA: 0x00002306 File Offset: 0x00000506
			// (set) Token: 0x0600006E RID: 110 RVA: 0x0000230E File Offset: 0x0000050E
			public string timeleft { get; set; }
		}

		// Token: 0x0200000A RID: 10
		public class response_class
		{
			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000070 RID: 112 RVA: 0x00002317 File Offset: 0x00000517
			// (set) Token: 0x06000071 RID: 113 RVA: 0x0000231F File Offset: 0x0000051F
			public bool success { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000072 RID: 114 RVA: 0x00002328 File Offset: 0x00000528
			// (set) Token: 0x06000073 RID: 115 RVA: 0x00002330 File Offset: 0x00000530
			public string message { get; set; }
		}
	}
}
