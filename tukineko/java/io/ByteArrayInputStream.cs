/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 8:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace tukineko
{
	/// <summary>
	/// Description of ByteArrayInputStream.
	/// https://github.com/cping/LGame/blob/master/C%23/Loon2MonoGame/LoonMonoGame-Lib/java/io/ByteArrayInputStream.cs
	/// </summary>
	public class ByteArrayInputStream : InputStream
	{
        public ByteArrayInputStream(byte[] data)
        {
            base.Wrapped = new MemoryStream(data);
        }

        public ByteArrayInputStream(byte[] data, int off, int len)
        {
            base.Wrapped = new MemoryStream(data, off, len);
        }

        public override int available()
        {
            MemoryStream ms = (MemoryStream)Wrapped;
            return (int)(ms.Length - ms.Position);
        }
	}
}
