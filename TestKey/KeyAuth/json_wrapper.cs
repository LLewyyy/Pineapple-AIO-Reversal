using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x0200000C RID: 12
	public class json_wrapper
	{
		// Token: 0x0600007D RID: 125 RVA: 0x00002355 File Offset: 0x00000555
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00003E48 File Offset: 0x00002048
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			bool flag = !json_wrapper.is_serializable(type);
			if (flag)
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00003EA0 File Offset: 0x000020A0
		public object string_to_object(string json)
		{
			byte[] bytes = Encoding.Default.GetBytes(json);
			object result;
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002373 File Offset: 0x00000573
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000035 RID: 53
		private DataContractJsonSerializer serializer;

		// Token: 0x04000036 RID: 54
		private object current_object;
	}
}
