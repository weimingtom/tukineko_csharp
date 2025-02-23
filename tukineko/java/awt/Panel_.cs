/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 4:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace tukineko
{
	/// <summary>
	/// Description of Panel.
	/// </summary>
	public class Panel_ : Component
	{
		public Panel_()
		{
			MainForm _this = MainForm.getInstance();
			_this.currentPanel = this;
		}
		
		public void setSize(int w, int h)
		{
			MainForm _this = MainForm.getInstance();
			_this.Invoke(new Action(() => {
				_this.Size = new Size(w, h);
				_this.MaximizeBox = false;
				_this.Size = new Size(w, h + (h - _this.ClientRectangle.Height));
			}));
		}
		
		public void addMouseListener(MouseListener l)
		{
			MainForm _this = MainForm.getInstance();
			_this.currentMouseListener = l;
		}
		
		public void add(PopupMenu menu)
		{
			
		}
		
		public void setVisible(bool v)
		{
			MainForm _this = MainForm.getInstance();
			_this.Invoke(new Action(() => {
				_this.Visible = v;
			}));
		}
		
		public void setPreferredSize(Dimension d)
		{
			MainForm _this = MainForm.getInstance();
			_this.Invoke(new Action(() => {
				_this.Size = new Size(d.w, d.h);
				_this.MaximizeBox = false;
				_this.Size = new Size(d.w, d.h + (d.h - _this.ClientRectangle.Height));
			}));
		}
				
		public void requestFocus()
		{
			MainForm _this = MainForm.getInstance();
			_this.Invoke(new Action(() => {
				_this.Focus();
			}));
		}
		
		public void repaint()
		{
			MainForm _this = MainForm.getInstance();
			_this.Invoke(new Action(() => {
				_this.Invalidate();
			}));
		}
				
		//from java.awt.Component
		public Image_ createImage(int w, int h)
		{
			Bitmap bufferBmp = new Bitmap(w, h);
			Image_ result = new Image_();
			result._bufferBmp = bufferBmp;
            return result;
		}
		
		public virtual void update(Graphics_ g) {
			
		}

		public virtual void paint(Graphics_ g) {
			
		}
	}
}
