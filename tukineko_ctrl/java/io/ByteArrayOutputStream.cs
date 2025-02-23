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
	/// Description of ByteArrayOutputStream.
	/// https://github.com/cping/LGame/blob/master/C%23/Loon2MonoGame/LoonMonoGame-Lib/java/io/ByteArrayOutputStream.cs
	/// </summary>
	public class ByteArrayOutputStream : OutputStream
	{
        public ByteArrayOutputStream()
        {
            base.Wrapped = new MemoryStream();
        }

        public ByteArrayOutputStream(int bufferSize)
        {
            base.Wrapped = new MemoryStream(bufferSize);
        }

        public long size()
        {
            return ((MemoryStream)base.Wrapped).Length;
        }

        public byte[] toByteArray()
        {
            return ((MemoryStream)base.Wrapped).ToArray();
        }

        public override void close()
        {
        }
	}
}
