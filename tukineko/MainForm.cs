/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/23
 * Time: 6:09
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
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{	
		public MouseListener currentMouseListener;
		public Panel_ currentPanel;		
		private static MainForm instance;
		public static MainForm getInstance()
		{
			return instance;
		}
		
		public MainForm()
		{
			instance = this;
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.Size = new Size(640, 480);
			this.MaximizeBox = false;
			this.Size = new Size(640, 480 + (480 - this.ClientRectangle.Height));
			this.CenterToScreen();
			
			//setTitle("hello");
			addTimer();
			
			Thread t1 = new Thread(onStart);
			t1.Start();
			
			//FIXME:added
			this.MouseClick += MainFormMouseClick;
		}
		
		public void onStart()
		{
			Debug.WriteLine("onStart");
			//int main( int argc, CharPtr[] argv )
			string[] args = Environment.GetCommandLineArgs();
			string[] argv = new string[args.Length + 1]; //FIXME:???why add one argv
			for (int i = 0; i < args.Length; ++i)
			{
				argv[i] = args[i];
			}
			//FIXME:
			if (true)
			{
				Tukineko.main(argv);
			}
			else if (false)
			{
				NSParser.main(argv);
			}
		}
		
		
		protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bufferBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
            Graphics g = Graphics.FromImage((System.Drawing.Image)bufferBmp);
            this.DrawGame(g);

            e.Graphics.DrawImage(bufferBmp, 0, 0);
            g.Dispose();
            base.OnPaint(e);
        }
		
		private Brush bgBrush = new SolidBrush(Color.Blue);
        private void DrawGame(Graphics g)
        {
        	g.FillRectangle(bgBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
        	if (currentPanel != null)
        	{
        		Graphics_ graph = new Graphics_();
        		graph._graph = g;
        		currentPanel.paint(graph);
        	}
        }
        
        public void refresh() 
        {
        	this.Invalidate();
        }
        
        void MainFormKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
        	Debug.WriteLine("MainFormKeyDown " + e.KeyCode);
		}
		
		void MainFormKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			Debug.WriteLine("MainFormKeyUp " + e.KeyCode);
		}
		
		void MainFormMouseClick(object sender, MouseEventArgs e)
		{
			Debug.WriteLine("MainFormMouseClick " + e.X + ", " + e.Y);
			if (currentMouseListener != null)
        	{
				MouseEvent ev = new MouseEvent();
				ev.x = e.X;
				ev.y = e.Y;
				currentMouseListener.mousePressed(ev);
        	}
		}
		
		public void addTimer()
		{
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += timer1_Tick;
            timer.Enabled = true;
            timer.Start();
		}
		
		private void timer1_Tick(object sender, EventArgs e)
        {
            Debug.WriteLine("timer1_Tick");
		}
		
		public void setTitle(string str)
		{
			this.Text = str;
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
			Environment.Exit(0);
		}
		
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			Application.Exit();
			Environment.Exit(0);
		}
	}
}
