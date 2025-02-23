/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 8:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace tukineko
{
	/// <summary>
	/// Description of FileOutputStream.
	/// FIXME: merge into OutputStream class
	/// </summary>
	public class FileOutputStream
	{
		private FileStream aFile;
		
		public FileOutputStream(string filename)
		{
			aFile = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
		}
		
		public FileOutputStream(FileInfo file)
		{
			aFile = new FileStream(file.FullName, FileMode.OpenOrCreate, FileAccess.Write);
		}
		
		public void write(int x)
		{
			if (aFile != null)
			{
				aFile.WriteByte((byte)x);
			}
		}
		
		public void write(byte[] bytes)
		{
			if (aFile != null)
			{
				aFile.Write(bytes, 0, bytes.Length);
			}
		}
		
		public void write(byte[] bytes, int offset, int length)
		{
			if (aFile != null)
			{
				aFile.Write(bytes, offset, length);
			}
		}
		
		public void close()
		{
			if (aFile != null)
			{
				aFile.Close();
				aFile = null;
			}
		}
	}
}
