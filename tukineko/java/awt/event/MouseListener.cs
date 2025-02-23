/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 4:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace tukineko
{
	/// <summary>
	/// Description of MouseListener.
	/// </summary>
	public interface MouseListener
	{
		void mouseClicked(MouseEvent event_);
		void mouseEntered(MouseEvent event_);
		void mouseExited(MouseEvent event_);
		void mouseReleased(MouseEvent event_);
		void mousePressed(MouseEvent event_);
	}
}
