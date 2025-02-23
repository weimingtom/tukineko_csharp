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
	/// Description of ObjectOutputStream.
	/// FIXME: merge into OutputStream class
	/// </summary>
	public class ObjectOutputStream
	{
		ByteArrayOutputStream o_;
		public ObjectOutputStream(ByteArrayOutputStream o)
		{
			this.o_ = o;
		}
		
		public void writeObject(NScripter o)
		{
			string jsonData = JsonConvert.SerializeObject(o);
        	byte[] bytes = Encoding.UTF8.GetBytes(jsonData);
        	this.o_.write(bytes);
		}
		
		public void flush()
		{
			
		}
		
		public void close()
		{
			
		}
	}
}
