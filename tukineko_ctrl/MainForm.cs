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
using System.Runtime.InteropServices;

namespace tukineko
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{	
//		public PictureBox picture_bg_1;
		public PictureBox panel_bg_1;
		public Label label_bg_info1;
		public Label[] label_msg_arr = new Label[100];
		public PictureBox picturebox_button;
		public PictureBox[] shell_arr = new PictureBox[10]; //3
		public PictureBox[] sprite_arr = new PictureBox[100]; //50
		public PictureBox picture_menu1, picture_menu2, picture_menu3;
		
		public Label label_frmBuffFG_info1, label_frmBuffFG_info2;
		public Label label_error_1, label_error_2;
		
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


			
			panel_bg_1 = new PictureBox();
			panel_bg_1.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Controls.Add(panel_bg_1);
			
			label_bg_info1 = new Label();
			label_bg_info1.AutoSize = true;
			panel_bg_1.Controls.Add(label_bg_info1);
			
			for (int i = 0; i < label_msg_arr.Length; ++i)
			{
				label_msg_arr[i] = new Label();
				label_msg_arr[i].AutoSize = true;
				panel_bg_1.Controls.Add(label_msg_arr[i]);				
			}
			
			picturebox_button = new PictureBox();
			picturebox_button.AutoSize = false;
			picturebox_button.SizeMode = PictureBoxSizeMode.StretchImage;
			panel_bg_1.Controls.Add(picturebox_button);
			
			for (int i = 0; i < shell_arr.Length; ++i)
			{
				shell_arr[i] = new PictureBox();
				shell_arr[i].AutoSize = true;
				shell_arr[i].SizeMode = PictureBoxSizeMode.StretchImage;
				panel_bg_1.Controls.Add(shell_arr[i]);				
			}
			
			for (int i = 0; i < sprite_arr.Length; ++i)
			{
				sprite_arr[i] = new PictureBox();
				sprite_arr[i].AutoSize = true;
				sprite_arr[i].SizeMode = PictureBoxSizeMode.StretchImage;
				panel_bg_1.Controls.Add(sprite_arr[i]);				
			}
			
			
//			picture_bg_1 = new PictureBox();
//			picture_bg_1.AutoSize = true;
//			picture_bg_1.SizeMode = PictureBoxSizeMode.StretchImage;
//			panel_bg_1.Controls.Add(picture_bg_1);
			
			picture_menu1 = new PictureBox();
			picture_menu2 = new PictureBox();
			picture_menu3 = new PictureBox();
			picture_menu1.AutoSize = true; 
			picture_menu2.AutoSize = true;
			picture_menu3.AutoSize = true;
			panel_bg_1.Controls.Add(picture_menu1);
			panel_bg_1.Controls.Add(picture_menu2);
			panel_bg_1.Controls.Add(picture_menu3);
			
			label_frmBuffFG_info1 = new Label();
			label_frmBuffFG_info1.AutoSize = true;
			label_frmBuffFG_info2 = new Label();
			label_frmBuffFG_info2.AutoSize = true;
			panel_bg_1.Controls.Add(label_frmBuffFG_info1);
			label_frmBuffFG_info1.Controls.Add(label_frmBuffFG_info2);		
			
			label_error_1 = new Label();
			label_error_1.AutoSize = true;
			panel_bg_1.Controls.Add(label_error_1);
			label_error_2 = new Label();
			label_error_2.AutoSize = true;
			label_error_1.Controls.Add(label_error_2);
			
			//setTitle("hello");
			//addTimer();
			
			Thread t1 = new Thread(onStart);
			t1.Start();
			
			//FIXME:added
			this.MouseClick += MainFormMouseClick;
			foreach (Control c1 in this.Controls)
			{
				c1.MouseClick += MainFormMouseClick;
				foreach (Control c2 in c1.Controls)
				{
					c2.MouseClick += MainFormMouseClick;
					foreach (Control c3 in c2.Controls)
					{
						c3.MouseClick += MainFormMouseClick;
					}	
				}	
			}
			
			//MouseHook.Start();
            //MouseHook.MouseAction += new MouseEventHandler(MainFormMouseClick);
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
		
		
//		protected override void OnPaint(PaintEventArgs e)
//        {
//            Bitmap bufferBmp = new Bitmap(this.ClientRectangle.Width, this.ClientRectangle.Height);
//            Graphics g = Graphics.FromImage((System.Drawing.Image)bufferBmp);
//            this.DrawGame(g);
//
//            e.Graphics.DrawImage(bufferBmp, 0, 0);
//            g.Dispose();
//            base.OnPaint(e);
//        }
//		
//		private Brush bgBrush = new SolidBrush(Color.Blue);
//        private void DrawGame(Graphics g)
//        {
//        	g.FillRectangle(bgBrush, 0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height);
//        	if (currentPanel != null)
//        	{
//        		Graphics_ graph = new Graphics_();
//        		graph._graph = g;
//        		currentPanel.paint(graph);
//        	}
//        }
        
        public void refresh() 
        {
//        	this.Invalidate();
			this._Invalidate();
        }
        
        public void _Invalidate() {
        	if (currentPanel != null)
        	{
        		currentPanel._paint();
        	}
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
			if (currentMouseListener != null && sender is Control)
        	{
				MouseEvent ev = new MouseEvent();
				Point sp = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
				Point p = this.PointToClient(sp); //convert relative position to windows form client area position
				ev.x = p.X;
				ev.y = p.Y;
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
		
					
		private void Event(object sender, MouseEventArgs e) { 
			Debug.WriteLine("Left mouse click!"); 
		}
    
//		protected override void WndProc(ref Message m)
//		{
////		    const int WM_LBUTTONDOWN = 0x0201;
////		
////		    if (m.Msg == WM_LBUTTONDOWN)
////		    {
////		        int x = (int)m.LParam & 0xffff;
////		        int y = ((int)m.LParam >> 16) & 0xffff;
////		
////		        //处理鼠标按下事件
////		        MainFormMouseClick(null, new MouseEventArgs(MouseButtons.Left, 1, x, y, 0));
////		    }
//
//		    //https://blog.csdn.net/emailqjc/article/details/5302039
//		    const int WM_NCHITTEST = 0x84;
//		    if (m.Msg == 138)//WM_NCHITTEST)
//            {  
//                switch (m.Result.ToInt32())  
//                {  
//                    case 1://客户区
//                        m.Result = new IntPtr(2); 
//                        break;
//                    case 2://标题栏
//                        m.Result = new IntPtr(1); 
//                        break;
//                    case 20: m.Result = new IntPtr(0); break;  
//                    default: Console.WriteLine(m); break;
//                }
//		    }
//			
//		    base.WndProc(ref m);
//		    
//
//		}
		
	}
	
	//https://stackoverflow.com/questions/11607133/global-mouse-event-handler
	public static class MouseHook
    {
        public static event MouseEventHandler MouseAction = delegate { };

        public static void Start()
        {
            _hookID = SetHook(_proc);


        }
        public static void stop()
        {
            UnhookWindowsHookEx(_hookID);
        }

        private static LowLevelMouseProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc,
                  GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(
          int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                MouseAction(null, new MouseEventArgs(MouseButtons.Left, 0, hookStruct.pt.x, hookStruct.pt.y, 0));
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook,
          LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
          IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
