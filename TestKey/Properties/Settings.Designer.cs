using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace TestKey.Properties
{
	// Token: 0x02000011 RID: 17
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00006110 File Offset: 0x00004310
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x04000053 RID: 83
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
