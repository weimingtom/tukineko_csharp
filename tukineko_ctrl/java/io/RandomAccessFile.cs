/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 1:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace tukineko
{
	/// <summary>
	/// Description of RandomAccessFile.
	/// </summary>
	public class RandomAccessFile
	{
		private FileStream aFile;
		
		//use FileStream
//		public RandomAccessFile()
//		{
//			aFile = new FileStream(file.FullName, FileMode.Open, FileAccess.Read);
//		}
		
		public RandomAccessFile(string name, string mode)
		{
			if (mode != null && mode.Equals("r")) {
			    aFile = new FileStream(name, FileMode.Open, FileAccess.Read);
			} else {
				throw new NotSupportedException();
			}
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
		
		public void seek(int offset)
		{
			if (aFile != null)
			{
				aFile.Seek(offset, SeekOrigin.Begin);
			}
		}
		
		public int read(byte[] bytes, int offset, int len)
		{
			if (aFile != null)
			{
				return aFile.Read(bytes, offset, len);
			}
			else
			{
				return 0;
			}
		}
		
		public long skipBytes(int i)
		{
			if (aFile != null)
			{
				long oldPos = aFile.Position;
				long pos = aFile.Seek(i, SeekOrigin.Current);
				return pos - oldPos;
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
