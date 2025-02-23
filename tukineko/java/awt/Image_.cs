/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 5:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace tukineko
{
	/// <summary>
	/// Description of Image.
	/// </summary>
	public class Image_
	{
		public Image _bufferBmp;
		public Image_()
		{
		}
		
		public Graphics_ getGraphics()
		{
			Graphics g = Graphics.FromImage(_bufferBmp);
			Graphics_ result = new Graphics_();
			result._graph = g;
			return result;
		}
		
		public int getWidth(object o)
		{
			if (_bufferBmp != null)
			{
				return _bufferBmp.Width;
			}
			else
			{
				return 0;
			}
		}
		
		public int getHeight(object o)
		{
			if (_bufferBmp != null)
			{
				return _bufferBmp.Height;
			}
			else
			{
				return 0;
			}
		}
	}
}
