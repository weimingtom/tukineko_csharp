/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 1:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace tukineko
{
	/// <summary>
	/// Description of MemoryImageSource.
	/// </summary>
	public class MemoryImageSource
	{
		public int w;
		public int h;
		public byte[] bytes;
		public uint[] pix;
		public MemoryImageSource(int w, int h, uint[] pix, int off, int scan)
		{
			//FIXME: no off and scan
			this.w = w;
			this.h = h;
			this.pix = pix;
			this.bytes = new byte[w * h * 4];
			for (int j = 0; j < h; ++j)
			{
				for (int i = 0; i < w; ++i)
				{
					uint pixel = pix[j * w + i];
					bytes[j * w * 4 + i * 4 + 0] = (byte)((pixel >> 24) & 0xff);
					bytes[j * w * 4 + i * 4 + 1] = (byte)((pixel >> 16) & 0xff);
					bytes[j * w * 4 + i * 4 + 2] = (byte)((pixel >>  8) & 0xff);
					bytes[j * w * 4 + i * 4 + 3] = (byte)((pixel >>  0) & 0xff);
				}
			}
		}
	}
}
