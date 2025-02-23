/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 5:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace tukineko
{
	/// <summary>
	/// Description of Color.
	/// </summary>
	public class Color_
	{
		public Color color_ = Color.Black;
		public Color_()
		{
			color_ = Color.Black;
		}
		
		public Color_(int r, int g, int b)
		{
			color_ = Color.FromArgb((byte)255, (byte)r, (byte)g, (byte)b);
		}
		
		public Color_(uint rgba, bool hasalpha)
		{
			if (hasalpha)
			{
				int a = (int)((rgba >> 24) & 0xff);
				int r = (int)((rgba >> 16) & 0xff);
				int g = (int)((rgba >>  8) & 0xff);
				int b = (int)((rgba >>  0) & 0xff);
				color_ = Color.FromArgb(a, r, g, b);
			}
			else
			{
				int r = (int)((rgba >> 16) & 0xff);
				int g = (int)((rgba >>  8) & 0xff);
				int b = (int)((rgba >>  0) & 0xff);
				color_ = Color.FromArgb(r, g, b);
			}
		}
		
		public static Color_ black = new Color_(0, 0, 0);
		public static Color_ white = new Color_(0xff, 0xff, 0xff);
	}
}
