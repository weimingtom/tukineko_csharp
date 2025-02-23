using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;

namespace tukineko
{
	public class NsWindow : Panel_, MouseListener, ActionListener {
		//-----------------------
		
		//private const long serialVersionUID = 1L;

		private NScripter ns;
		private PopupMenu menuSys;

		// TODO:
		public NsThread thd;
		private PopupMenu menu;
		public Menu menuSave;
		public Menu menuLoad;

		private Image_ frmBuffB;
		private Graphics_ frmBuffBG;
		private Image_ frmBuffF;
		private Graphics_ frmBuffFG;
		private Image_ frmBuffR;

		private NsActionListener al;
		private NsTimer timer;

		private NsData ndata = new NsData();

		public NsWindow() {
	//		String path = "./";
			bool isRotate = false;
			
	//		Frame frame = new Frame();
	//		frame.addNotify();
			_start();
			
			this.ndata = new NsData();
	//		this.ndata.path = path;
			this.ndata.rotate = isRotate;
	//		this.addNotify();
			if (!this.ndata.rotate) {
				this.setSize(320, 240);
			} else {
				this.setSize(240, 320);
			}
			this.addMouseListener(this);
			this.menuSys = new PopupMenu();
			this.ndata.menuVisible = false;
			this.menuSys.add("Fade");
			this.menuSys.addSeparator();
			this.menuSys.add("Exit");
			this.menuSys.addActionListener(this);
			this.add(this.menuSys);

			// //

			//
			this.initGraph();
			//

			this.ns = new NScripter(this, this.ndata);
			//
			NsResource.initLog(this.ndata.fchk);
			NsImageCache.init(this);
			this.paintF();
			//
			this.setVisible(true);
			//
			// TODO:
			this.menu = new PopupMenu();
			//
			this.al = new NsActionListener(this.ns, this);
			this.menu.addActionListener(this.al);
			this.add(this.menu);

			//
			// this.ns.start();
			this.thd = new NsThread(this.ns);
			thd.start();
			//
			this.timer = new NsTimer();
		}
		
		class MyWindowAdapter : WindowAdapter {
				//@Override
				public void windowClosing(WindowEvent e) {
	//				isStopped = true;
	//				if (drawThread != null) {
	//					try {
	//						drawThread.join(1000);
	//					} catch (InterruptedException e1) {
	//						e1.printStackTrace();
	//					}
	//				}
	//				onExit();
					Environment.Exit(0);	
				}
		}
		
		private void _start() {
			setPreferredSize(new Dimension(320, 240));
			Frame frame = new Frame();
			frame.add(this);
			frame.addWindowListener(new MyWindowAdapter());
	//		frame.setTitle(title);	
			
			frame.pack();
			frame.setResizable(false);
			frame.setLocationRelativeTo(null);
			frame.setVisible(true);
			this.requestFocus(); //listen for keyboard event_
	//		bufImage = this.createImage(canvasWidth, canvasHeight);
	//		bufGraph = bufImage.getGraphics();
	//		bufGraph.clearRect(0, 0, canvasWidth, canvasHeight);
	//		drawThread = new Thread(this);
	//		drawThread.start();			
		}

		/*
		 * public void menuVisibleClear() { this.menuVisible = false; }
		 */

		//@Override
		public void mouseClicked(MouseEvent event_) {

		}

		//@Override
		public void mouseEntered(MouseEvent event_) {

		}

		//@Override
		public void mouseExited(MouseEvent event_) {

		}

		//@Override
		public void mouseReleased(MouseEvent event_) {

		}

		//@Override
		public void mousePressed(MouseEvent event_) {
			if (!this.ndata.menuVisible) {
				if (this.ndata.textVisible
						&& ((!this.ndata.rotate && event_.getY() < 16 && event_
								.getX() < 32))
						|| (this.ndata.rotate && event_.getX() < 16 && event_.getY() > 288)) {
					this.menu.show(event_.getComponent(), 0, 0);
					this.ndata.menuVisible = true;
				} else if ((!this.ndata.rotate && event_.getY() > 224 && event_
						.getX() < 32)
						|| (this.ndata.rotate && event_.getX() > 224 && event_.getY() > 288)) {
					this.menuSys.show(event_.getComponent(), 0, 0);
					this.ndata.menuVisible = true;
				} else if (!this.ndata.rotate) {
					this.ns.click(event_.getX() * 2, event_.getY() * 2);
				} else {
					this.ns.click((319 - event_.getY()) * 2, event_.getX() * 2);
				}
			} else {
				this.ndata.menuVisible = false;
			}
		}

		//@Override
		public void actionPerformed(ActionEvent event_) {
			String str = event_.getActionCommand();
			if ("Exit".Equals(str)) {
				this.ns.storageState = 3;
				this.paintF();
				this.ns.exitFlag = true;
			} else if ("Fade".Equals(str)) {
				this.fadeToggle();
				this.ndata.menuVisible = false;
			}
		}

		private void fadeToggle() {
			if (!this.ndata.fadeMode) {
				this.ndata.fadeMode = true;
				this.ndata.fadeFlag = false;
			} else {
				this.ndata.fadeMode = false;
			}
			this.paintB();
		}
		
		public override void _paint()
		{
//			if (this.frmBuffF != null) {
//				if (!this.ndata.rotate)
//					g.drawImage(this.frmBuffF, 0, 0, this);
//				else {
//					g.drawImage(this.frmBuffR, 0, 0, this);
//				}
//			}
			_paintF();
			
			if (this.ndata.error != null)
			{
				MainForm.getInstance().label_error_1.BackColor = Color.Transparent;
				MainForm.getInstance().label_error_1.ForeColor = Color.Black;
				MainForm.getInstance().label_error_1.Location = new Point(17, 17);
				MainForm.getInstance().label_error_1.Text = this.ndata.error;
				MainForm.getInstance().label_error_1.Visible = true;
				
				MainForm.getInstance().label_error_2.BackColor = Color.Transparent;
				MainForm.getInstance().label_error_2.ForeColor = Color.White;
				MainForm.getInstance().label_error_2.Location = new Point(16 - 17, 16 - 17);
				MainForm.getInstance().label_error_2.Text = this.ndata.error;
				MainForm.getInstance().label_error_2.Visible = true;
			}
			else
			{
				MainForm.getInstance().label_error_1.Visible = false;
				MainForm.getInstance().label_error_2.Visible = false;
			}
		}

		/*
		 * public static void error(String str) { error = str; }
		 * 
		 * public static bool hasError() { return error != null; }
		 * 
		 * public static String getError() { return error; }
		 */

		private void makeFileMenu(Menu paramMenu, int savenumber, String path,
				String savenameTitle) {
			if (paramMenu != null)
				paramMenu.removeAll();
			for (int i = 0; i < savenumber; i++) {
				FileInfo localFile = new FileInfo(path + "SAVE" + Convert.ToString(i + 1)
						+ ".DAT");
				if (localFile.Exists == true) {
					DateTime localDate = localFile.LastWriteTime;
					// FIXME:
					/*
					 * int j = localDate.getMonth() + 1; int k =
					 * localDate.getDate(); int m = localDate.getHours(); int n =
					 * localDate.getMinutes();
					 */
					int j = localDate.Month;
					int k = localDate.Day;
					int m = localDate.Hour;
					int n = localDate.Minute;
					paramMenu.add(savenameTitle + (i < 9 ? "0" : "")
							+ Convert.ToString(i + 1) + " " + (j < 10 ? "0" : "")
							+ Convert.ToString(j) + "/" + (k < 10 ? "0" : "")
							+ Convert.ToString(k) + " " + (m < 10 ? "0" : "")
							+ Convert.ToString(m) + ":" + (n < 10 ? "0" : "")
							+ Convert.ToString(n));
				} else {
					paramMenu.add(savenameTitle + (i < 9 ? "0" : "")
							+ Convert.ToString(i + 1) + " " + "--/-- --:--");
				}
			}
		}

		public void makemenu(int savenumber, String path, String savenameTitle) {
			this.makeFileMenu(this.menuSave, savenumber, path, savenameTitle);
			this.makeFileMenu(this.menuLoad, savenumber, path, savenameTitle);
		}

		public void createMenuSave(String str) {
			this.menuSave = new Menu(str);
			this.menuSave.addActionListener(this.al);
			this.menu.add(this.menuSave);
		}

		public void createMenuLoad(String str) {
			this.menuLoad = new Menu(str);
			this.menuLoad.addActionListener(this.al);
			this.menu.add(this.menuLoad);
		}

		private static Image_ createImage(int w, int h, uint[] pix, int off, int scan) {
			return Toolkit.getDefaultToolkit().createImage(new MemoryImageSource(w, h, pix, off, scan));
		}

		private static void grabPixels(Image_ img, int x, int y, int w, int h, uint[] pix, int off, int scansize) {
			try {
				new PixelGrabber(img, x, y, w, h, pix, off, scansize).grabPixels();
			} catch (InterruptedException) {

			}
		}

		private static void drawString(Graphics_ paramGraphics, String paramString,
				int paramInt1, int paramInt2, int paramInt3) {
			if (paramString == null) {
				return;
			}
			
			if (paramString.Length > 0)
			{
				Debug.WriteLine(">> drawString >> " + paramString); //FIXME:added
				if (paramString.EndsWith("¨‹")) //FIXME:see textPage() { this.tn.putMess(this.nd.text, "¨‹",
				{
					Debug.WriteLine("why???");
				}
			}
			
			FontMetrics localFontMetrics = paramGraphics.getFontMetrics();
			for (int i = 0; i < paramString.Length; i++) {
				String str = paramString.Substring(i, 1);
				int j = localFontMetrics.stringWidth(str);
				paramGraphics.drawString(str,
						(paramInt1 + paramInt3 * i + (paramInt3 - j) / 2) / 2,
						paramInt2 / 2);
			}
		}

		public void paintB() {
			MainForm.getInstance().Invoke(new Action(() => {
				_paintF();
			}));
		}
		
		public void _paintB() {
			Image_ localImage;
			if (this.ndata.bgColor != null) {
				Color_ c = getColor(this.ndata.bgColor);
				MainForm.getInstance().panel_bg_1.BackColor = c.color_;
				MainForm.getInstance().panel_bg_1.Visible = true;
				MainForm.getInstance().panel_bg_1.Location = new Point(0, 0);
				MainForm.getInstance().panel_bg_1.Size = new Size(320, 240);
			} else if (this.ndata.bgImage != null) {
				//FIXME:not implemented
//				if (this.ndata.quakex != 0) {
//					this.frmBuffBG.setColor(Color_.black);
//					this.frmBuffBG.fillRect((this.ndata.quakex & 0x1) == 0 ? 0 : 304, 0, 16, 240);
//				}
//				if (this.ndata.quakey != 0) {
//					this.frmBuffBG.setColor(Color_.black);
//					this.frmBuffBG.fillRect(0, (this.ndata.quakey & 0x1) == 0 ? 0 : 224, 320, 16);
//				}
				if ((localImage = NsImageCache.get(this.ndata.bgImage)) != null) {
					MainForm.getInstance().panel_bg_1.BackColor = Color.Transparent;
					MainForm.getInstance().panel_bg_1.Image = localImage._bufferBmp;
					MainForm.getInstance().panel_bg_1.Visible = true;
					MainForm.getInstance().panel_bg_1.Location = new Point(this.ndata.quakex == 0 ? 0 : 16 - (this.ndata.quakex & 0x1) * 32,
							this.ndata.quakey == 0 ? 0 : 16 - (this.ndata.quakey & 0x1) * 32);
					MainForm.getInstance().panel_bg_1.Size = new Size(320, 240);
				} else {
					MainForm.getInstance().panel_bg_1.BackColor = Color.Black;
					MainForm.getInstance().panel_bg_1.Visible = true;
					MainForm.getInstance().panel_bg_1.Location = new Point(0, 0);
					MainForm.getInstance().panel_bg_1.Size = new Size(320, 240);					
				}
			}
			
			
			
			//FIXME:added
			MainForm.getInstance().picturebox_button.Visible = false;
			//TODO:not implemented
			if ((this.ndata.btnVisible == true) && (this.ndata.btnSel != -1)) {
				NsButton localNsButton = this.ndata.btn[this.ndata.btnSel];
//				this.frmBuffBG.setClip(localNsButton.x >> 1, localNsButton.y >> 1,
//						localNsButton.width >> 1, localNsButton.height >> 1);
				if ((localImage = NsImageCache.get(this.ndata.btnImage)) != null) {
//					this.frmBuffBG.drawImage(localImage, (localNsButton.x >> 1)
//							- (localNsButton.u >> 1), (localNsButton.y >> 1)
//							- (localNsButton.v >> 1), this);
					MainForm.getInstance().picturebox_button.Location = new Point(localNsButton.x >> 1, localNsButton.y >> 1);
					MainForm.getInstance().picturebox_button.Size = new Size(localNsButton.width >> 1, localNsButton.height >> 1);
					Bitmap cloneImage = new Bitmap(localNsButton.width, localNsButton.height);
					if (localImage._bufferBmp is Bitmap)
					{
						Graphics graphics = Graphics.FromImage(cloneImage);
						graphics.DrawImage(localImage._bufferBmp,
						    -localNsButton.u, //(localNsButton.x) - (localNsButton.u), 
						    -localNsButton.v, //(localNsButton.y) - (localNsButton.v),
						    localImage._bufferBmp.Width, 
						    localImage._bufferBmp.Height);
					}
					MainForm.getInstance().picturebox_button.Image = cloneImage;//localImage._bufferBmp;
					MainForm.getInstance().picturebox_button.Visible = true;
//					MainForm.getInstance().picturebox_button.Padding = new Padding(1, 1, 0, 0);
//						(localNsButton.x >> 1) - (localNsButton.u >> 1), 
//						(localNsButton.y >> 1) - (localNsButton.v >> 1), 0, 0);
				}
//				this.frmBuffBG.setClip(0, 0, 320, 240);
			}			
			
			//FIXME:added
			for (int kk = 0; kk < MainForm.getInstance().shell_arr.Length; ++kk)
			{
				MainForm.getInstance().shell_arr[kk].Visible = false;
			}
			//TODO:not implemented
			int j = 0;
			for (; j < 3; j++) {
				if (this.ndata.shell[j] != null) {
					int i;
					switch (j) {
					case 0:
						i = 80 - (this.ndata.shell[j].width >> 1);
						break;
						
					default:
						i = 160 - (this.ndata.shell[j].width >> 1);
						break;
						
					case 2:
						i = 240 - (this.ndata.shell[j].width >> 1);
						break;
					}
					if ((localImage = NsImageCache.get(this.ndata.shell[j].image)) != null) {
						//FIXME:not implemented
//						this.frmBuffBG.drawImage(localImage, i,
//								240 - this.ndata.shell[j].height, this);
						MainForm.getInstance().shell_arr[j].Location = new Point(i, 240 - this.ndata.shell[j].height);
						MainForm.getInstance().shell_arr[j].Size = new Size(localImage._bufferBmp.Width >> 1, localImage._bufferBmp.Height >> 1);
						MainForm.getInstance().shell_arr[j].BackColor = Color.Transparent;
						MainForm.getInstance().shell_arr[j].Image = localImage._bufferBmp;
						MainForm.getInstance().shell_arr[j].Visible = true;
					}
				}
			}
			
			
			//FIXME:added
			for (int kk = 0; kk < MainForm.getInstance().sprite_arr.Length; ++kk)
			{
				MainForm.getInstance().sprite_arr[kk].Visible = false;
			}
			//FIXME:Main Menu->Option->Graphic Mode->Choose Character->Choose Gallery
			for (j = 0; j < 50; j++) {
				if ((this.ndata.sprite[j].visible != true)|| ((localImage = NsImageCache
								.get(this.ndata.sprite[j].image)) == null)) {
					continue;
				}
				//TODO:not implemented
//				this.frmBuffBG.drawImage(localImage, this.ndata.sprite[j].x >> 1,
//						this.ndata.sprite[j].y >> 1, this);
				MainForm.getInstance().sprite_arr[j].Location = new Point(this.ndata.sprite[j].x >> 1, this.ndata.sprite[j].y >> 1);
				MainForm.getInstance().sprite_arr[j].Size = new Size(localImage._bufferBmp.Width >> 1, localImage._bufferBmp.Height >> 1);
				MainForm.getInstance().sprite_arr[j].BackColor = Color.Transparent;
				MainForm.getInstance().sprite_arr[j].Image = localImage._bufferBmp;
				MainForm.getInstance().sprite_arr[j].Visible = true;
			}
			
			
			
			
			
			
			//FIXME:not implemented
			if ((this.ndata.fadeMode == true) && (this.ndata.textVisible == true)
					&& (this.ndata.text != null) && (this.ndata.text.getY() != 0)) {
				//FIXME:added, mod to see bg image
//				NsWindow.grabPixels(this.frmBuffB, 0, 0, 320, 240, this.ndata.fadeImg, 0, 320);
//				for (j = 0; j < 76800; j++) {
//					this.ndata.fadeImg[j] = ((this.ndata.fadeImg[j] & 0xFEFEFE) >> 1) | 0xFF000000;
//				}
//				localImage = NsWindow.createImage(320, 240, this.ndata.fadeImg, 0, 320);
//				this.frmBuffBG.drawImage(localImage, 0, 0, this);
				this.ndata.fadeFlag = true;
			} else {
				this.ndata.fadeFlag = false;
			}
			
			
			
			
			
			
			
			
//			paintF();
		}

		/**
		 * fade
		 */
		public void paintF() {
			MainForm.getInstance().Invoke(new Action(() => {
				_paintF();
			}));
		}
		
		public void _paintF() {
			if (this.ns.storageState != 0) {
				MainForm.getInstance().panel_bg_1.BackColor = Color.Black;
				MainForm.getInstance().panel_bg_1.Location = new Point(0, 0);
				MainForm.getInstance().panel_bg_1.Size = new Size(320, 240);
				MainForm.getInstance().panel_bg_1.Visible = true;

				switch (this.ns.storageState) {
				case -2:
					Image_ localImage;
					if ((localImage = NsImageCache.get(this.ns.path + "MOON.PNG")) != null) {
						MainForm.getInstance().picture_menu1.Image = localImage._bufferBmp;
						MainForm.getInstance().picture_menu1.Location = new Point(5, 70);
						MainForm.getInstance().picture_menu1.Visible = true;
					} else {
						MainForm.getInstance().picture_menu1.BorderStyle = BorderStyle.FixedSingle;
						MainForm.getInstance().picture_menu1.Location = new Point(5, 70);
						MainForm.getInstance().picture_menu1.Size = new Size(100, 100);
					}
					if ((localImage = NsImageCache.get(this.ns.path + "PLUS.PNG")) != null) {
						MainForm.getInstance().picture_menu2.Image = localImage._bufferBmp;
						MainForm.getInstance().picture_menu2.Location = new Point(110, 70);
						MainForm.getInstance().picture_menu2.Visible = true;
					} else {
						MainForm.getInstance().picture_menu2.BorderStyle = BorderStyle.FixedSingle;
						MainForm.getInstance().picture_menu2.Location = new Point(110, 70);
						MainForm.getInstance().picture_menu2.Size = new Size(100, 100);
					}
					if ((localImage = NsImageCache.get(this.ns.path + "KAGETU.PNG")) != null) {
						MainForm.getInstance().picture_menu3.Image = localImage._bufferBmp;
						MainForm.getInstance().picture_menu3.Location = new Point(215, 70);
						MainForm.getInstance().picture_menu3.Visible = true;
					} else {
						MainForm.getInstance().picture_menu3.BorderStyle = BorderStyle.FixedSingle;
						MainForm.getInstance().picture_menu3.Location = new Point(215, 70);
						MainForm.getInstance().picture_menu3.Size = new Size(100, 100);
					}
					
					MainForm.getInstance().label_bg_info1.Visible = false;
					break;
					
				case -1:
					MainForm.getInstance().label_bg_info1.BackColor = Color.Transparent;
					MainForm.getInstance().label_bg_info1.ForeColor = Color.White;
					MainForm.getInstance().label_bg_info1.Text = "初期化中";
					MainForm.getInstance().label_bg_info1.Location = new Point(140, 100);
					MainForm.getInstance().label_bg_info1.Visible = true;
					
					MainForm.getInstance().picture_menu1.Visible = false;
					MainForm.getInstance().picture_menu2.Visible = false;
					MainForm.getInstance().picture_menu3.Visible = false;
					break;
					
				case 1:
					MainForm.getInstance().label_bg_info1.BackColor = Color.Transparent;
					MainForm.getInstance().label_bg_info1.ForeColor = Color.White;
					MainForm.getInstance().label_bg_info1.Text = "保存中";
					MainForm.getInstance().label_bg_info1.Location = new Point(140, 100);
					MainForm.getInstance().label_bg_info1.Visible = true;
					
					MainForm.getInstance().picture_menu1.Visible = false;
					MainForm.getInstance().picture_menu2.Visible = false;
					MainForm.getInstance().picture_menu3.Visible = false;
					break;
					
				case 2:
					MainForm.getInstance().label_bg_info1.BackColor = Color.Transparent;
					MainForm.getInstance().label_bg_info1.ForeColor = Color.White;
					MainForm.getInstance().label_bg_info1.Text = "読出中";
					MainForm.getInstance().label_bg_info1.Location = new Point(140, 100);
					MainForm.getInstance().label_bg_info1.Visible = true;
					
					MainForm.getInstance().picture_menu1.Visible = false;
					MainForm.getInstance().picture_menu2.Visible = false;
					MainForm.getInstance().picture_menu3.Visible = false;
					break;
					
				case 3:
					MainForm.getInstance().label_bg_info1.BackColor = Color.Transparent;
					MainForm.getInstance().label_bg_info1.ForeColor = Color.White;
					MainForm.getInstance().label_bg_info1.Text = "終了中";
					MainForm.getInstance().label_bg_info1.Location = new Point(140, 100);
					MainForm.getInstance().label_bg_info1.Visible = true;
					
					MainForm.getInstance().picture_menu1.Visible = false;
					MainForm.getInstance().picture_menu2.Visible = false;
					MainForm.getInstance().picture_menu3.Visible = false;
					break;
					
				case 0:
					MainForm.getInstance().label_bg_info1.Visible = false;
					
					MainForm.getInstance().picture_menu1.Visible = false;
					MainForm.getInstance().picture_menu2.Visible = false;
					MainForm.getInstance().picture_menu3.Visible = false;
					break;
				}
			} else {
				MainForm.getInstance().picture_menu1.Visible = false;
				MainForm.getInstance().picture_menu2.Visible = false;
				MainForm.getInstance().picture_menu3.Visible = false;
				MainForm.getInstance().label_bg_info1.Visible = false;
				
				//this.frmBuffFG.drawImage(this.frmBuffB, 0, 0, this);
				_paintB();
				
				//added, init
				for (int kk = 0; kk < MainForm.getInstance().label_msg_arr.Length; ++kk)
				{
					MainForm.getInstance().label_msg_arr[kk].Visible = false;
				}
				if ((this.ndata.text != null) && (this.ndata.textVisible == true)) {
					int i = this.ndata.twinLx;
					int j = this.ndata.twinLy + this.ndata.twinFh;
					for (int k = 0; k < this.ndata.text.getY(); k++) {
						if (this.ndata.twinShadow == true) {
							//FIXME:not implemented
//							this.frmBuffFG.setColor(Color_.black);
//							NsWindow.drawString(this.frmBuffFG,
//									this.ndata.text.getMess(k), i + 2, j + 2,
//									this.ndata.twinFw + this.ndata.twinSw);
//							if (this.ndata.twinBold == true) {
//								NsWindow.drawString(this.frmBuffFG,
//										this.ndata.text.getMess(k), i + 4, j + 2,
//										this.ndata.twinFw + this.ndata.twinSw);
//							}
							
							//FIXME:
							//copy from NSWindow.drawString()
							string paramString = this.ndata.text.getMess(k);
							bool isShow = true;
							if (paramString == null) {
								isShow = false;
							}
							else 
							{
								if (paramString.Length > 0)
								{
									Debug.WriteLine(">> drawString >> " + paramString); //FIXME:added
									if (paramString.EndsWith("¨‹")) //FIXME:see textPage() { this.tn.putMess(this.nd.text, "¨‹",
									{
										Debug.WriteLine("why???");
									}
								}
							}
							if (isShow)
							{
								MainForm.getInstance().label_msg_arr[k].BackColor = Color.Transparent;
								MainForm.getInstance().label_msg_arr[k].ForeColor = Color.Black;
								MainForm.getInstance().label_msg_arr[k].Visible = true;
								MainForm.getInstance().label_msg_arr[k].Text = paramString;
								MainForm.getInstance().label_msg_arr[k].Location = new Point(i + 2, j + 2 - MainForm.getInstance().label_msg_arr[k].Height * 3);
							}
						}
						if (this.ndata.text.getAttr(k) == true) {
//							this.frmBuffFG.setColor(getColor(this.ndata.text
//									.getColor(k)));
							Color_ co = getColor(this.ndata.text.getColor(k));
							MainForm.getInstance().label_msg_arr[k].ForeColor = co.color_;
						} else {
//							this.frmBuffFG.setColor(new Color_(144, 144, 144));
							MainForm.getInstance().label_msg_arr[k].ForeColor = Color.FromArgb(255, 144, 144, 144);
						}
						
						//FIXME:not implemented
//						NsWindow.drawString(this.frmBuffFG,
//								this.ndata.text.getMess(k), i, j, this.ndata.twinFw
//										+ this.ndata.twinSw);
//						if (this.ndata.twinBold == true) {
//							NsWindow.drawString(this.frmBuffFG,
//									this.ndata.text.getMess(k), i + 2, j,
//									this.ndata.twinFw + this.ndata.twinSw);
//						}
						//FIXME:why j/2 ? see NSWindow.drawString()
						MainForm.getInstance().label_msg_arr[k].Location = new Point((i + 2) / 2, j / 2 - MainForm.getInstance().label_msg_arr[k].Height);
						
						j += this.ndata.twinFh + this.ndata.twinSh;
					}
				}
			}
			string str1 = Convert.ToString((long) Runtime.getRuntime().freeMemory()); //FIXME: int->long
			string str2 = Convert.ToString((long) Runtime.getRuntime().totalMemory());
			string str = str1 + ":" + str2;
			MainForm.getInstance().label_frmBuffFG_info1.BackColor = Color.Transparent;
			MainForm.getInstance().label_frmBuffFG_info1.ForeColor = Color.Black;//Color.Red;
			MainForm.getInstance().label_frmBuffFG_info1.Text = str;
			MainForm.getInstance().label_frmBuffFG_info1.Location = new Point(200, 239 - MainForm.getInstance().label_frmBuffFG_info1.Height);
			MainForm.getInstance().label_frmBuffFG_info2.BackColor = Color.Transparent;
			MainForm.getInstance().label_frmBuffFG_info2.ForeColor = Color.White;
			MainForm.getInstance().label_frmBuffFG_info2.Text = str;
			MainForm.getInstance().label_frmBuffFG_info2.Location = new Point(201 - 200, 238 - 239);
			
//			repaintWin();
		}

		private void repaintWin() {
			//FIXME:not implemented
//			if (this.ndata.rotate == true) {
//				uint[] arrayOfInt1 = new uint[320 * 240];
//				uint[] arrayOfInt2 = new uint[320 * 240];
//				NsWindow.grabPixels(this.frmBuffF, 0, 0, 320, 240, arrayOfInt1, 0, 320);
//				int k = 0;
//				for (int i = 0; i < 320; i++) {
//					for (int j = 0; j < 240; j++) {
//						arrayOfInt2[(k++)] = arrayOfInt1[(319 - i + j * 320)];
//					}
//				}
//				this.frmBuffR = NsWindow.createImage(240, 320, arrayOfInt2, 0, 240);
//			}
//			this.repaint();
		}

		public void blt(int j, int k, int m, int n, int i1, int i2) {
			this.frmBuffBG.setClip(j >> 1, k >> 1, m >> 1, n >> 1);
			Image_ localImage;
			if ((localImage = NsImageCache.get(this.ndata.btnImage)) != null) {
				this.frmBuffBG.drawImage(localImage, (j >> 1) - (i1 >> 1), (k >> 1)
						- (i2 >> 1), this);
			}
			this.frmBuffBG.setClip(0, 0, 320, 240);
		}

		private void initGraph() {
			this.frmBuffB = this.createImage(320, 240);
			this.frmBuffBG = this.frmBuffB.getGraphics();
			this.frmBuffF = this.createImage(320, 240);
			this.frmBuffFG = this.frmBuffF.getGraphics();
			this.frmBuffBG.setColor(Color_.black);
			this.frmBuffBG.fillRect(0, 0, 320, 240);
		}

		public int putMess(NsText nt, String mess, NsColor color,
				bool paramBoolean1, bool paramBoolean2) {
			String str;
			if (!paramBoolean2) {
				str = mess;
			} else {
				if (nt.curY > 0) {
					nt.curY -= 1;
				}
				str = nt.mess[nt.curY] + mess;
				nt.mess[nt.curY] = "";
			}
			int j = str.Length;
			int i = 0;
			if (j < 2) {
				i = 1;
			} else {
				i = (j - 1) / nt.width + 1;
			}
			if (j == 0) {
				nt.mess[nt.curY] = "";
				nt.color[nt.curY] = color;
				nt.attr[(nt.curY++)] = paramBoolean1;
				return 1;
			}
			i = 0;
			for (int k = 0; k < str.Length; k += nt.width) {
				if (nt.curY >= nt.height - 1) {
					nt.mess[nt.curY - 1] += "▼";
					if (!this.ndata.fadeFlag) {
						this.paintB();
					} else {
						this.paintF();
					}
					this.newpage(true);
				}
				if (k + nt.width < str.Length) {
					int m = 0;
					for (; m < 1 && k + nt.width + m < j; m++) {
						if ("、。」▼▽".IndexOf(str[k + nt.width + m]) == -1) {
							break;
						}
					}
					nt.mess[nt.curY] = this.ndata.evalStr(str.Substring(k, nt.width + m));
					k += m;
				} else {
					nt.mess[nt.curY] = this.ndata.evalStr(str.Substring(k));
				}
				nt.color[nt.curY] = color;
				nt.attr[(nt.curY++)] = paramBoolean1;
				i++;
			}
			return i;
		}

		public void timerExit() {
			this.timer.exit();
		}

		public void timerClear() {
			this.timer.clear();
		}

		public int timerRead() {
			return this.timer.read();
		}

		public void initSar(String filename) {
			NsResource.initSar(filename, this);
		}

		public void initNsa(String filename) {
			NsResource.initNsa(filename, this);
		}

		public bool setImageCache(String name) {
			return NsImageCache.set(name);
		}

		public void loadValueStorage(InputStream paramInputStream,
				int[] paramArrayOfInt, String[] paramArrayOfString, int paramInt1,
				int paramInt2) {
			NsValueStorage.load(paramInputStream, paramArrayOfInt,
					paramArrayOfString, paramInt1, paramInt2);
		}

		public void saveValueStorage(OutputStream paramOutputStream,
				int[] paramArrayOfInt, String[] paramArrayOfString, int paramInt1,
				int paramInt2) {
			NsValueStorage.save(paramOutputStream, paramArrayOfInt,
					paramArrayOfString, paramInt1, paramInt2);
		}

		/*
		 * Image localImage = NsImageCache.get(image); if (localImage != null) {
		 * this.width = localImage.getWidth(null); this.height =
		 * localImage.getHeight(null); } else { this.width = 0; this.height = 0; }
		 */
		public int getImageWidth(String image) {
			Image_ localImage = NsImageCache.get(image);
			if (localImage != null) {
				return localImage.getWidth(null);
			} else {
				return 0;
			}
		}

		public int getImageHeight(String image) {
			Image_ localImage = NsImageCache.get(image);
			if (localImage != null) {
				return localImage.getHeight(null);
			} else {
				return 0;
			}
		}

		private static Color_ getColor(NsColor color) {
			return new Color_(color.getRGB(), true);
		}

		/*
		 * private static NsColor toNsColor(Color color) { return new NsColor(
		 * color.getRed(), color.getGreen(), color.getBlue(), color.getAlpha()); }
		 */
		public void popupMenuAdd(String str) {
			this.menu.add(str);
		}

		public void wait(int paramInt, bool paramBoolean) {
			if (!paramBoolean) {
				try {
					Thread.Sleep(paramInt);
				} catch (Exception) {
				}
			} else {
				this.ndata.click = false;
				if (paramInt == 0) {
					do {
						try {
							Thread.Sleep(100);
						} catch (Exception) {
						}
						if (this.ndata.click) {
							break;
						}
					} while (this.ns.storageState == 0);
				} else {
					int i = paramInt;
					while ((this.ndata.click != true)
							&& (this.ns.storageState == 0)) {
						if (i > 100) {
							try {
								Thread.Sleep(100);
							} catch (Exception) {
							}
							i -= 100;
							continue;
						}
						try {
							Thread.Sleep(i);
						} catch (Exception) {
						}
					}
				}
			}
		}

		public void newpage(bool paramBoolean) {
			this.ndata.selectState = 1;
			if (paramBoolean == true) {
				this.wait(this.ndata.autoclick, true);
			}
			if (this.ns.storageState == 0) {
				this.ndata.select.Clear();
				this.ndata.text.cls();
			}
		}
	}
}
