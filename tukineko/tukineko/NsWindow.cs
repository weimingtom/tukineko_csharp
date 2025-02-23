using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace tukineko
{
	public class NsWindow : Panel_, MouseListener, ActionListener {
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

		//@Override
		public override void update(Graphics_ g) {
			paint(g);
		}

		//@Override
		public override void paint(Graphics_ g) {
			if (this.frmBuffF != null) {
				if (!this.ndata.rotate)
					g.drawImage(this.frmBuffF, 0, 0, this);
				else {
					g.drawImage(this.frmBuffR, 0, 0, this);
				}
			}
			if (this.ndata.error != null) {
				g.setColor(Color_.black);
				g.drawString(this.ndata.error, 17, 17);
				g.setColor(Color_.white);
				g.drawString(this.ndata.error, 16, 16);
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
			Image_ localImage;
			if (this.ndata.bgColor != null) {
				this.frmBuffBG.setColor(getColor(this.ndata.bgColor));
				this.frmBuffBG.fillRect(0, 0, 320, 240);
			} else if (this.ndata.bgImage != null) {
				if (this.ndata.quakex != 0) {
					this.frmBuffBG.setColor(Color_.black);
					this.frmBuffBG.fillRect((this.ndata.quakex & 0x1) == 0 ? 0
							: 304, 0, 16, 240);
				}
				if (this.ndata.quakey != 0) {
					this.frmBuffBG.setColor(Color_.black);
					this.frmBuffBG.fillRect(0, (this.ndata.quakey & 0x1) == 0 ? 0
							: 224, 320, 16);
				}

				if ((localImage = NsImageCache.get(this.ndata.bgImage)) != null) {
					this.frmBuffBG.drawImage(localImage, this.ndata.quakex == 0 ? 0
							: 16 - (this.ndata.quakex & 0x1) * 32,
							this.ndata.quakey == 0 ? 0
									: 16 - (this.ndata.quakey & 0x1) * 32, this);
				} else {
					this.frmBuffBG.setColor(Color_.black);
					this.frmBuffBG.fillRect(0, 0, 320, 240);
				}
			}
			if ((this.ndata.btnVisible == true) && (this.ndata.btnSel != -1)) {
				NsButton localNsButton = this.ndata.btn[this.ndata.btnSel];
				this.frmBuffBG.setClip(localNsButton.x >> 1, localNsButton.y >> 1,
						localNsButton.width >> 1, localNsButton.height >> 1);
				if ((localImage = NsImageCache.get(this.ndata.btnImage)) != null) {
					this.frmBuffBG.drawImage(localImage, (localNsButton.x >> 1)
							- (localNsButton.u >> 1), (localNsButton.y >> 1)
							- (localNsButton.v >> 1), this);
				}
				this.frmBuffBG.setClip(0, 0, 320, 240);
			}
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
						this.frmBuffBG.drawImage(localImage, i,
								240 - this.ndata.shell[j].height, this);
					}
				}
			}
			for (j = 0; j < 50; j++) {
				if ((this.ndata.sprite[j].visible != true)
						|| ((localImage = NsImageCache
								.get(this.ndata.sprite[j].image)) == null)) {
					continue;
				}
				this.frmBuffBG.drawImage(localImage, this.ndata.sprite[j].x >> 1,
						this.ndata.sprite[j].y >> 1, this);
			}
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
			paintF();
		}

		/**
		 * fade
		 */
		public void paintF() {
			if (this.ns.storageState != 0) {
				this.frmBuffFG.setColor(Color_.black);
				this.frmBuffFG.fillRect(0, 0, 320, 240);
				this.frmBuffFG.setColor(Color_.white);
				switch (this.ns.storageState) {
				case -2:
					Image_ localImage;
					if ((localImage = NsImageCache
							.get(this.ns.path + "MOON.PNG")) != null) {
						this.frmBuffFG.drawImage(localImage, 5, 70, this);
					} else {
						this.frmBuffFG.drawRect(5, 70, 100, 100);
					}
					if ((localImage = NsImageCache
							.get(this.ns.path + "PLUS.PNG")) != null) {
						this.frmBuffFG.drawImage(localImage, 110, 70, this);
					} else {
						this.frmBuffFG.drawRect(110, 70, 100, 100);
					}
					if ((localImage = NsImageCache.get(this.ns.path
							+ "KAGETU.PNG")) != null)
						this.frmBuffFG.drawImage(localImage, 215, 70, this);
					else {
						this.frmBuffFG.drawRect(215, 70, 100, 100);
					}
					break;
					
				case -1:
					this.frmBuffFG.drawString("初期化中", 140, 100);
					break;
					
				case 1:
					this.frmBuffFG.drawString("保存中", 140, 100);
					break;
					
				case 2:
					this.frmBuffFG.drawString("読出中", 140, 100);
					break;
					
				case 3:
					this.frmBuffFG.drawString("終了中", 140, 100);
					break;
					
				case 0:
					break;
				}
			} else {
				this.frmBuffFG.drawImage(this.frmBuffB, 0, 0, this);
				if ((this.ndata.text != null) && (this.ndata.textVisible == true)) {
					int i = this.ndata.twinLx;
					int j = this.ndata.twinLy + this.ndata.twinFh;
					for (int k = 0; k < this.ndata.text.getY(); k++) {
						if (this.ndata.twinShadow == true) {
							this.frmBuffFG.setColor(Color_.black);
							NsWindow.drawString(this.frmBuffFG,
									this.ndata.text.getMess(k), i + 2, j + 2,
									this.ndata.twinFw + this.ndata.twinSw);
							if (this.ndata.twinBold == true) {
								NsWindow.drawString(this.frmBuffFG,
										this.ndata.text.getMess(k), i + 4, j + 2,
										this.ndata.twinFw + this.ndata.twinSw);
							}
						}
						if (this.ndata.text.getAttr(k) == true) {
							this.frmBuffFG.setColor(getColor(this.ndata.text
									.getColor(k)));
						} else {
							this.frmBuffFG.setColor(new Color_(144, 144, 144));
						}
						NsWindow.drawString(this.frmBuffFG,
								this.ndata.text.getMess(k), i, j, this.ndata.twinFw
										+ this.ndata.twinSw);
						if (this.ndata.twinBold == true) {
							NsWindow.drawString(this.frmBuffFG,
									this.ndata.text.getMess(k), i + 2, j,
									this.ndata.twinFw + this.ndata.twinSw);
						}
						j += this.ndata.twinFh + this.ndata.twinSh;
					}
				}
			}
			this.frmBuffFG.setColor(Color_.black);
			string str1 = Convert.ToString((long) Runtime.getRuntime().freeMemory()); //FIXME: int->long
			string str2 = Convert.ToString((long) Runtime.getRuntime().totalMemory());
			string str = str1 + ":" + str2;
			this.frmBuffFG.drawString(str, 200, 239);
			this.frmBuffFG.setColor(Color_.white);
			this.frmBuffFG.drawString(str, 201, 238);
			repaintWin();
		}

		private void repaintWin() {
			if (this.ndata.rotate == true) {
				uint[] arrayOfInt1 = new uint[320 * 240];
				uint[] arrayOfInt2 = new uint[320 * 240];
				NsWindow.grabPixels(this.frmBuffF, 0, 0, 320, 240, arrayOfInt1, 0, 320);
				int k = 0;
				for (int i = 0; i < 320; i++) {
					for (int j = 0; j < 240; j++) {
						arrayOfInt2[(k++)] = arrayOfInt1[(319 - i + j * 320)];
					}
				}
				this.frmBuffR = NsWindow.createImage(240, 320, arrayOfInt2, 0, 240);
			}
			this.repaint();
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
