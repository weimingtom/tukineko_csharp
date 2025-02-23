/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 1:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;
using System.Drawing;

namespace tukineko
{
	/// <summary>
	/// Description of Toolkit.
	/// </summary>
	public class Toolkit
	{
		private Toolkit()
		{
		}
		
		private static Toolkit instance = new Toolkit();
		public static Toolkit getDefaultToolkit()
		{
			return instance;
		}
		
		public Image_ createImage(MemoryImageSource src)
		{
			Image_ result = new Image_();
			byte[] bytes = src.bytes;
			using (MemoryStream ms = new MemoryStream(bytes))
			{
			    Bitmap bitmap = new Bitmap(src.w, src.h);
			    for (int j = 0; j < src.h; ++j)
			    {
			    	for (int i = 0; i < src.w; ++i)
			    	{
			    		uint p = src.pix[j * src.w + i];
			    		int a = (int)((p >> 24) & 0xff);
			    		int r = (int)((p >> 16) & 0xff);
			    		int g = (int)((p >>  8) & 0xff);
			    		int b = (int)((p >>  0) & 0xff);
			    		bitmap.SetPixel(i, j, Color.FromArgb(a, r, g, b));
			    	}
			    }
			    result._bufferBmp = bitmap;
			}
			return result;
		}
		
		public Image_ createImage(String name)
		{
			Image_ result = new Image_();
			result._bufferBmp = Image.FromFile(name);
			return result;
		}
		
		public Image_ createImage(byte[] bytes)
		{
			Image_ result = new Image_();
			using (MemoryStream ms = new MemoryStream(bytes))
			{
			    Bitmap bitmap = new Bitmap(ms);
			    result._bufferBmp = bitmap;
			}
			return result;
		}
	}
}
