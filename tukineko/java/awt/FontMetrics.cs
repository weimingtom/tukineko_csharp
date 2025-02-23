/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 2:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;

namespace tukineko
{
	/// <summary>
	/// Description of FontMetrics.
	/// </summary>
	public class FontMetrics
	{
		public Graphics _graph;
		public Font _font;
		public FontMetrics()
		{
			
		}
		
		public int stringWidth(String str)
		{
			if (_graph != null && _font != null)
			{
				SizeF sizeF = _graph.MeasureString(str, _font);
				return (int)sizeF.Width;
			}
			return 0;
		}
	}
}
