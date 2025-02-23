/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 5:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace tukineko
{
	/// <summary>
	/// Description of MouseEvent.
	/// </summary>
	public class MouseEvent
	{
		public int x;
		public int y;
		public MouseEvent()
		{
		}
		
		public int getX()
		{
			return x;
		}
		
		public int getY()
		{
			return y;
		}
		
		public Component getComponent()
		{
			return null;
		}
	}
}
