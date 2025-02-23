/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 5:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace tukineko
{
	/// <summary>
	/// Description of Graphics.
	/// </summary>
	public class Graphics_
	{
		public Font _font = new Font("SimSun", 10, FontStyle.Regular); //FIXME:???why this font size ?
		public Graphics _graph;
		public Graphics_()
		{
		}
		
		public void drawImage(Image_ i, int x, int y, Panel_ p)
		{
			if (_graph != null)
			{
				if (x == 0 && y == 0)
				{
					_graph.DrawImage(i._bufferBmp, x, y, 320, 240);
				}
				else
				{
					_graph.DrawImage(i._bufferBmp, x, y, i._bufferBmp.Width, i._bufferBmp.Height);
				}
			}
		}
		
		private Color_ mColor = new Color_();
		public void setColor(Color_ c)
		{
			this.mColor = c;
		}
		
		public void drawString(String str, int x, int y)
		{
			if (_graph != null)
			{
				Brush br = new SolidBrush(mColor.color_);
				_graph.DrawString(str, _font, br, x, y);
			}
		}
		
		public void fillRect(int x, int y, int w, int h)
		{
			if (_graph != null)
			{
				Brush br = new SolidBrush(mColor.color_);
				_graph.FillRectangle(br, new RectangleF(x, y, w, h));
			}
		}
		
		public FontMetrics getFontMetrics()
		{
			FontMetrics result = new FontMetrics();
			result._graph = this._graph;
			result._font = this._font;
			return result;
		}
		
		public void setClip(int x, int y, int w, int h)
		{
			if (_graph != null)
			{
				_graph.SetClip(new Rectangle(x, y, w, h));
			}
		}
		
		public void drawRect(int x, int y, int w, int h)
		{
			if (_graph != null)
			{
				Pen pen = new Pen(mColor.color_);
				_graph.DrawRectangle(pen, new Rectangle(x, y, w, h));
			}
		}
	}
}
