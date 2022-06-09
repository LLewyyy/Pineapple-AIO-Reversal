using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace TestKey.Properties
{
	// Token: 0x02000010 RID: 16
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000097 RID: 151 RVA: 0x00002409 File Offset: 0x00000609
		internal Resources()
		{
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00006050 File Offset: 0x00004250
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("TestKey.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00006098 File Offset: 0x00004298
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00002413 File Offset: 0x00000613
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600009B RID: 155 RVA: 0x000060B0 File Offset: 0x000042B0
		internal static Bitmap _788FDDDC_1897_4CCE_BAD4_EEABF9F0A469
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("788FDDDC-1897-4CCE-BAD4-EEABF9F0A469", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600009C RID: 156 RVA: 0x000060E0 File Offset: 0x000042E0
		internal static Bitmap standard
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("standard", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x04000051 RID: 81
		private static ResourceManager resourceMan;

		// Token: 0x04000052 RID: 82
		private static CultureInfo resourceCulture;
	}
}
