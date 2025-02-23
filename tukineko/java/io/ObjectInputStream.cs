/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 8:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace tukineko
{
	/// <summary>
	/// Description of ObjectInputStream.
	/// FIXME: merge into InputStream class
	/// </summary>
	public class ObjectInputStream
	{
		ByteArrayInputStream i_;
		public ObjectInputStream(ByteArrayInputStream i)
		{
			this.i_ = i;
		}
		
		public NScripter readObject()
		{
			byte[] bytes = new byte[this.i_.available()];
			this.i_.read(bytes);
			string jsonData = Encoding.UTF8.GetString(bytes);
			return (NScripter) JsonConvert.DeserializeObject(jsonData, typeof(NScripter));
		}
		
		public void close()
		{
			
		}
	}
}
