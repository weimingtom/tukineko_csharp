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
	/// Description of FileInputStream.
	/// FIXME: merge into InputStream class
	/// </summary>
	public class FileInputStream
	{
		private FileStream aFile;
		
		public FileInputStream(string filename)
		{
			aFile = new FileStream(filename, FileMode.Open, FileAccess.Read);
		}
		
		public FileInputStream(FileInfo file)
		{
			aFile = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
		}
		
		public int read()
		{
			if (aFile != null)
			{
				return aFile.ReadByte();
			}
			else
			{
				return 0;
			}
		}
		
		public int read(byte[] bytes, int offset, int length)
		{
			if (aFile != null)
			{
				return aFile.Read(bytes, offset, length);
			}
			else
			{
				return 0;
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
