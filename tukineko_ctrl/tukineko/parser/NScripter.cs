using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace tukineko
{
	public class NScripter : NSParser {
		//private const long serialVersionUID = 1L;

		private static NScripter instance;
		public static NScripter getInstance() {
			return instance;
		}
		
		// --------------------------------

		public NsWindow tn;
		public NsData nd;

		// -------------------------
		//private RandomAccessFile raf;
	//	private byte[] readBuff;
	//	private int readTop;
	//	private int readEnd;
	//	private int readPos;
		//
	//	private String line;
		//to parser
	//	public String lineRest;
	//	private bool lineCont;
	//	private List<String> args;

		// -------------------------

		public NScripter(NsWindow paramtukineko, NsData nd)
			: base("./") {
			instance = this;
			
			this.tn = paramtukineko;
			this.nd = nd;
			
			//
			this.readBuff = new byte[4096];
			this.readTop = 0;
			this.readEnd = 0;
			this.readPos = 0;
			//
			this.line = null;
			this.lineRest = null;
			this.lineCont = false;
			//
	//		this.args = new List<String>();
			this.argCont = false;
			// FIXME:
			// this.tn.initLog(this.nd.fchk);
			// this.tn.initImageCache();
			// this.tn.paintF();
		}

		private void destructor() {
			if (this.nd.globalon == true) {
				saveGlobalData();
			}
			if (this.nd.filelog == true) {
				saveLogData(this.path + "NSCRFLOG.DAT", this.nd.fchk);
			}
			if (this.nd.labellog == true) {
				saveLogData(this.path + "NSCRLLOG.DAT", this.nd.lchk);
			}
			if (this.raf != null)
				try {
					this.raf.close();
				} catch (IOException) {
				}
			this.tn.timerExit();
		}

		/*
		 * public void fadeToggle() { if (!this.nd.fadeMode) { this.nd.fadeMode =
		 * true; this.nd.fadeFlag = false; } else { this.nd.fadeMode = false; }
		 * this.tn.paintB(); }
		 */
		public override void run() {
			initParser();
			bool bool1 = this.tn.setImageCache(this.path + "MOON.PNG");
			bool bool2 = this.tn.setImageCache(this.path + "PLUS.PNG");
			bool bool3 = this.tn.setImageCache(this.path + "KAGETU.PNG");
			
			//FIXME:added
			Debug.WriteLine("INFO: check MOON.PNG, PLUS.PNG, KAGETU.PNG");
			if (bool1 == false)
			{
				Debug.WriteLine("ERROR: image not found: " + this.path + "MOON.PNG");
			}
			if (bool2 == false)
			{
				Debug.WriteLine("ERROR: image not found: " + this.path + "PLUS.PNG");
			}
			if (bool2 == false)
			{
				Debug.WriteLine("ERROR: image not found: " + this.path + "KAGETU.PNG");
			}
			
				
			this.storageState = -2;
			this.tn.paintF();
			while (!this.exitFlag) {
				if (this.nd.click == true) {
					this.nd.click = false;
					if ((this.nd.clickY >= 140) && (this.nd.clickY < 340)) {
						if ((bool1 == true) && (this.nd.clickX >= 10)
								&& (this.nd.clickX < 210)) {
							this.path += "MOON" + File_.separator;
							break;
						}
						if ((bool2 == true) && (this.nd.clickX >= 220)
								&& (this.nd.clickX < 420)) {
							this.path += "PLUS" + File_.separator;
							break;
						}
						if ((bool3 == true) && (this.nd.clickX >= 430)
								&& (this.nd.clickX < 630)) {
							this.path += "KAGETU" + File_.separator;
							break;
						}
					}
				}
				try {
					Thread.Sleep(100);
				} catch (Exception) {
				}
			}
			if (this.exitFlag == true) {
				Environment.Exit(0);
			}
			this.storageState = -1;
			this.tn.paintF();
			try {
				this.raf = new RandomAccessFile(this.path + "NSCRIPT.DAT", "r");
				FileInfo localFile = new FileInfo(this.path + "LABEL.DAT");
				int j;
				byte[] arrayOfByte;
				if (!localFile.Exists) {
					FileOutputStream localObject = new FileOutputStream(localFile);
					while ((this.line = readLine()) != null) {
						int i = 0;
						for (; i < this.line.Length; i++) {
							if (" \t".IndexOf(this.line[i]) == -1) {
								break;
							}
						}
						if (i > 0) {
							this.line = this.line.Substring(i);
						}
						if (this.line.StartsWith("*") == true) {
							j = getFilePointer();
							this.nd.label.Add(this.line.Substring(1), j);
							arrayOfByte = Encoding.GetEncoding("UTF-8").GetBytes(this.line.Substring(1));
							localObject.write(arrayOfByte.Length);
							localObject.write(arrayOfByte, 0, arrayOfByte.Length);
							localObject.write(j & 0xFF);
							localObject.write(j >> 8 & 0xFF);
							localObject.write(j >> 16 & 0xFF);
							localObject.write(j >> 24 & 0xFF);
						}
					}
					localObject.close();
				} else {
					FileInputStream localObject = new FileInputStream(localFile);
					arrayOfByte = new byte[64];
					while ((j = ((FileInputStream) localObject).read()) >= 0) {
						((FileInputStream) localObject).read(arrayOfByte, 0, j);
						int k = ((FileInputStream) localObject).read();
						k |= ((FileInputStream) localObject).read() << 8;
						k |= ((FileInputStream) localObject).read() << 16;
						k |= ((FileInputStream) localObject).read() << 24;
						this.nd.label.Add(Encoding.GetEncoding("Shift-JIS"/*"SJIS"*/).GetString(arrayOfByte, 0, j), k);
					}
					localObject.close();
				}
			//} catch (IOException e) {
			} catch (Exception e) {
				Console.WriteLine("Error: LABEL.DAT" + e);
				Debug.WriteLine("Error: LABEL.DAT " + e.ToString());
				Environment.Exit(1);
			}
			this.storageState = 0;
			//FIXME:run
			try {
				gotoLabel("*define");
				this.exitFlag = false;
				while (!this.exitFlag) {
					switch (exec()) {
					case 1:
						saveLocalData();
						break;
						
					case 2:
						loadLocalData();
						break;
					}
					if (hasError()) {
						this.tn.repaint();
						// FIXME:
						// Console.Error.WriteLine("Error: " + tukineko.getError());
						while (true) {
							try {
								Thread.Sleep(1000);
								continue;
							} catch (Exception) {
							}
						}
					}
				}
			//} catch (IOException) {
			} catch (Exception) {
				error("Error: Read Script");
			}
			destructor();
			Environment.Exit(0);
		}

		public void click(int paramInt1, int paramInt2) {
			if (this.nd.textVisible == true) {
				this.nd.click = true;
				this.nd.clickX = paramInt1;
				this.nd.clickY = paramInt2;
			} else {
				this.nd.textVisible = true;
				this.tn.paintB();
			}
		}

		public void loadGlobalData() {
			try {
				FileInfo localFile = new FileInfo(this.path + "GLOVAL.SAV");
				if (localFile.Exists == true) {
					int i;
					byte[] arrayOfByte = new byte[i = (int) localFile.Length];
					FileInputStream localFileInputStream = new FileInputStream(localFile);
					localFileInputStream.read(arrayOfByte, 0, i);
					localFileInputStream.close();

					ByteArrayInputStream localByteArrayInputStream = new ByteArrayInputStream(arrayOfByte);
					this.tn.loadValueStorage(localByteArrayInputStream, this.nd.valueNum, this.nd.valueStr, 200, 4095);
					localByteArrayInputStream.close();
				}
			//} catch (IOException) {
			} catch (Exception) {
				error("load-gloval: IOException");
			}
		}

		private void saveGlobalData() {
			try {
				ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream();
				this.tn.saveValueStorage(localByteArrayOutputStream,
						this.nd.valueNum, this.nd.valueStr, 200, 4095);
				byte[] arrayOfByte = localByteArrayOutputStream.toByteArray();
				localByteArrayOutputStream.close();

				FileOutputStream localFileOutputStream = new FileOutputStream(this.path + "GLOVAL.SAV");
				localFileOutputStream.write(arrayOfByte, 0, arrayOfByte.Length);
				localFileOutputStream.close();
			//} catch (IOException) {
			} catch (Exception) {
				error("save-global: IOException");
			}
		}

		public static void loadLogData(String paramString,
				Dictionary<String, int> paramDictionary) {
			byte[] arrayOfByte = new byte[1024];
			try {
				FileInputStream localFileInputStream = new FileInputStream(paramString);
				int i = 0;
				int j;
				while ((j = localFileInputStream.read()) != 10) {
					i = i * 10 + (j - 48);
				}
				for (int k = 0; k < i; k++) {
					if (localFileInputStream.read() != 34) {
						Console.Error.WriteLine("error: read " + paramString);
						break;
					}
					int m = 0;
					for (; (j = localFileInputStream.read()) != 34; m++) {
						j ^= 132;
						arrayOfByte[m] = (j < 128 ? (byte) j : (byte) (j - 256));
					}
					paramDictionary.Add(Encoding.GetEncoding("UTF-8").GetString(arrayOfByte, 0, m), 1);
				}
				localFileInputStream.close();
			} catch (Exception) {
				Console.Error.WriteLine("error: read " + paramString);
			}
		}

		private static void saveLogData(String paramString,
				Dictionary<String, int> paramDictionary) {
			try {
				FileOutputStream localFileOutputStream = new FileOutputStream(paramString);
				localFileOutputStream.write(Encoding.GetEncoding("UTF-8").GetBytes(Convert.ToString(paramDictionary.Count)));
				localFileOutputStream.write(10);
				IEnumerable<String> localEnumeration = paramDictionary.Keys;
				foreach (String el in localEnumeration) {
					byte[] arrayOfByte = Encoding.GetEncoding("UTF-8").GetBytes(el);
					for (int i = 0; i < arrayOfByte.Length; i++) {
						arrayOfByte[i] ^= 0x84;
					}
					localFileOutputStream.write(34);
					localFileOutputStream.write(arrayOfByte);
					localFileOutputStream.write(34);
				}
				localFileOutputStream.close();
			} catch (Exception) {
				Console.Error.WriteLine("error: write " + paramString);
			}
		}

		public void loadLocalData(String paramString) {
			this.tn.paintF();
			try {
				FileInfo localFile = new FileInfo(this.path + paramString);
				if (!localFile.Exists) {
					this.storageState = 0;
					this.tn.paintB();
					continueSelect();
					return;
				}
				int j;
				byte[] arrayOfByte = new byte[j = (int) localFile.Length];
				FileInputStream localFileInputStream = new FileInputStream(
						localFile);
				localFileInputStream.read(arrayOfByte, 0, j);
				localFileInputStream.close();

				ByteArrayInputStream localByteArrayInputStream = new ByteArrayInputStream(
						arrayOfByte);

				int i = localByteArrayInputStream.read();
				i |= localByteArrayInputStream.read() << 8;
				i |= localByteArrayInputStream.read() << 16;
				i |= localByteArrayInputStream.read() << 24;
				setFilePointer(i);

				tn.loadValueStorage(localByteArrayInputStream, this.nd.valueNum,
						this.nd.valueStr, 0, 199);

				ObjectInputStream localObjectInputStream = new ObjectInputStream(localByteArrayInputStream);
				NScripter localNScripter = (NScripter) localObjectInputStream.readObject();
				localObjectInputStream.close();
				localByteArrayInputStream.close();

				this.nd.selectState = localNScripter.nd.selectState;

				this.line = newString(localNScripter.line);
				this.lineRest = newString(localNScripter.lineRest);
				this.lineCont = localNScripter.lineCont;

				this.nd.text = new NsText(localNScripter.nd.text.width,
						localNScripter.nd.text.height);
				int k = 0;
				for (; k < localNScripter.nd.text.height; k++) {
					this.nd.text.mess[k] = newString(localNScripter.nd.text.mess[k]);
					this.nd.text.color[k] = localNScripter.nd.text.color[k];
					this.nd.text.attr[k] = localNScripter.nd.text.attr[k];
				}
				this.nd.text.curX = localNScripter.nd.text.curX;
				this.nd.text.curY = localNScripter.nd.text.curY;

				this.nd.textVisible = localNScripter.nd.textVisible;

				for (k = 0; k < 8; k++) {
					this.nd.gosub[k].retpos = localNScripter.nd.gosub[k].retpos;
					this.nd.gosub[k].rest = newString(localNScripter.nd.gosub[k].rest);
				}
				this.nd.gosubPos = localNScripter.nd.gosubPos;

				this.nd.twinLx = localNScripter.nd.twinLx;
				this.nd.twinLy = localNScripter.nd.twinLy;
				this.nd.twinLw = localNScripter.nd.twinLw;
				this.nd.twinLh = localNScripter.nd.twinLh;
				this.nd.twinFw = localNScripter.nd.twinFw;
				this.nd.twinFh = localNScripter.nd.twinFh;
				this.nd.twinSw = localNScripter.nd.twinSw;
				this.nd.twinSh = localNScripter.nd.twinSh;
				this.nd.twinSpeed = localNScripter.nd.twinSpeed;
				this.nd.twinHx = localNScripter.nd.twinHx;
				this.nd.twinHy = localNScripter.nd.twinHy;
				this.nd.twinEx = localNScripter.nd.twinEx;
				this.nd.twinEy = localNScripter.nd.twinEy;
				this.nd.twinBold = localNScripter.nd.twinBold;
				this.nd.twinShadow = localNScripter.nd.twinShadow;
				this.nd.twinColor = newColor(localNScripter.nd.twinColor);
				this.nd.twinImage = newString(localNScripter.nd.twinImage);

				this.nd.bgImage = newString(localNScripter.nd.bgImage);
				this.nd.bgColor = newColor(localNScripter.nd.bgColor);
				this.nd.bgEffect = localNScripter.nd.bgEffect;
				this.nd.autoclick = localNScripter.nd.autoclick;

				for (k = 0; k < 3; k++) {
					if (localNScripter.nd.shell[k] == null) {
						this.nd.shell[k] = null;
					} else {
						this.nd.shell[k] = new NsShell(
								localNScripter.nd.shell[k].image,
								localNScripter.nd.shell[k].effect,
								localNScripter.nd.shell[k].width,
								localNScripter.nd.shell[k].height);
					}
				}

				for (k = 0; k < 50; k++) {
					this.nd.sprite[k].image = newString(localNScripter.nd.sprite[k].image);
					this.nd.sprite[k].x = localNScripter.nd.sprite[k].x;
					this.nd.sprite[k].y = localNScripter.nd.sprite[k].y;
					this.nd.sprite[k].alpha = localNScripter.nd.sprite[k].alpha;
					this.nd.sprite[k].visible = localNScripter.nd.sprite[k].visible;
				}

				this.nd.quakex = localNScripter.nd.quakex;
				this.nd.quakey = localNScripter.nd.quakey;

				this.nd.select.Clear();
				// Object localObject;
				for (k = 0; k < localNScripter.nd.select.Count; k++) {
					NsSelect localObject = localNScripter.nd.select[k];
					this.nd.select.Add(new NsSelect(localObject.message,
							localObject.label, localObject.y, localObject.height,
							localObject.subrutine, localObject.selected));
				}

				this.nd.textSel = localNScripter.nd.textSel;
				this.nd.selSkipFlag = localNScripter.nd.selSkipFlag;
				this.nd.selnum = localNScripter.nd.selnum;
				this.nd.textcolor = localNScripter.nd.textcolor;

				this.nd.btnImage = newString(localNScripter.nd.btnImage);

				this.nd.btn.Clear();
				for (k = 0; k < localNScripter.nd.btn.Count; k++) {
					NsButton localObject = localNScripter.nd.btn[k];
					this.nd.btn.Add(new NsButton(localObject.no,
							localObject.x, localObject.y, localObject.width,
							localObject.height, localObject.u, localObject.v));
				}
				this.nd.btnSel = localNScripter.nd.btnSel;
				this.nd.btnVisible = localNScripter.nd.btnVisible;

				for (k = 0; k < 100; k++) {
					this.nd.history[k] = localNScripter.nd.history[k];
				}
				this.nd.historyPos = localNScripter.nd.historyPos;
				this.nd.historyCount = localNScripter.nd.historyCount;
				this.nd.jumpBack = localNScripter.nd.jumpBack;

				this.args.Clear();
				for (k = 0; k < localNScripter.args.Count; k++) {
					this.args.Add(newString(localNScripter.args[k]));
				}
				this.argCont = localNScripter.argCont;
			} catch (Exception localException) {
				Console.Error.WriteLine(localException);
			}
			this.storageState = 0;
			this.tn.paintB();
		}

		public void saveLocalData(String paramString) {
			this.tn.paintF();
			if (this.nd.globalon == true) {
				saveGlobalData();
			}
			if (this.nd.filelog == true) {
				saveLogData(this.path + "NSCRFLOG.DAT", this.nd.fchk);
			}
			if (this.nd.labellog == true) {
				saveLogData(this.path + "NSCRLLOG.DAT", this.nd.lchk);
			}
			try {
				ByteArrayOutputStream localByteArrayOutputStream = new ByteArrayOutputStream();

				int i = getFilePointer();
				localByteArrayOutputStream.write(i & 0xFF);
				localByteArrayOutputStream.write(i >> 8 & 0xFF);
				localByteArrayOutputStream.write(i >> 16 & 0xFF);
				localByteArrayOutputStream.write(i >> 24 & 0xFF);

				tn.saveValueStorage(localByteArrayOutputStream, this.nd.valueNum, this.nd.valueStr, 0, 199);

				ObjectOutputStream localObjectOutputStream = new ObjectOutputStream(localByteArrayOutputStream);
				localObjectOutputStream.writeObject(this);
				localObjectOutputStream.flush();
				localObjectOutputStream.close();

				byte[] arrayOfByte = localByteArrayOutputStream.toByteArray();
				localByteArrayOutputStream.close();

				FileOutputStream localFileOutputStream = new FileOutputStream(this.path + paramString);
				localFileOutputStream.write(arrayOfByte, 0, arrayOfByte.Length);
				localFileOutputStream.close();
			} catch (Exception localException) {
				Console.Error.WriteLine(localException);
			}
			this.storageState = 0;
			this.tn.paintB();
		}

		private void loadLocalData() {
			loadLocalData("SAVE" + Convert.ToString(this.nd.storageNo) + ".DAT");
			continueSelect();
		}

		private void saveLocalData() {
			saveLocalData("SAVE" + Convert.ToString(this.nd.storageNo) + ".DAT");
			tn.makemenu(this.nd.savenumber, this.path, this.nd.savenameTitle);
			continueSelect();
		}

		public void save(String str) {
			if (this.nd.rmenu[2] != null) {
				this.storageState = 1;
				this.nd.storageNo = int.Parse(str.Substring(
						this.nd.savenameTitle.Length,
						2));
				this.nd.menuVisible = false;
			}
		}

		public void load(String str) {
			if (this.nd.rmenu[3] != null) {
				this.storageState = 2;
				this.nd.storageNo = int.Parse(str.Substring(
						this.nd.savenameTitle.Length,
						2));
				this.nd.menuVisible = false;
			}
		}

		// FIXME:???
		public void menu3(String str) {
			if ((this.nd.rmenu[5] != null) && str.Equals(this.nd.rmenu[5])) {
				this.nd.textVisible = false;
				this.tn.paintB();
				this.nd.menuVisible = false;
			}
		}

		//parser
		//@Override
		public override void gotoLabel(String paramString) {
			if (!paramString.StartsWith("*")) {
				error("Error Label:" + paramString);
				return;
			}
			int localint;
			if (!this.nd.label.ContainsKey(paramString.Substring(1))) {
				error("Error Label:" + paramString);
				return;
			}
			localint = (int) this.nd.label[paramString.Substring(1)];
			setFilePointer(localint);
			this.nd.historyPos = 0;
			this.nd.historyCount = 0;
			this.lineRest = null;
		}

		public void backHistory(int paramInt) {
			if (this.nd.historyPos >= paramInt + 1) {
				this.nd.historyPos -= paramInt + 1;
			} else {
				this.nd.historyPos = (this.nd.historyPos - (paramInt + 1) + 100);
			}
			setFilePointer(this.nd.history[this.nd.historyPos]);
			this.nd.historyPos = 0;
			this.nd.historyCount = 0;
			this.lineRest = null;
		}

		//@Override
		protected override void addHistory() {
			this.nd.history[this.nd.historyPos] = getFilePointer();
			this.nd.historyPos = ((this.nd.historyPos + 1) % 100);
			this.nd.historyCount += 1;
		}

		//@Override
		public override void continueSelect() {
			base.continueSelect();
			
			switch (this.nd.selectState) {
			case 1:
				this.tn.newpage(true);
				break;

			case 2:
				selectWait();
				break;
			}
		}

		public void selectWait() {
			this.nd.selectState = 2;
			this.nd.click = false;
			NsSelect localNsSelect1;
			while (true) {
				if (this.storageState != 0) {
					return;
				}
				if (this.nd.click == true) {
					this.nd.click = false;
					this.nd.textSel = -1;
					int i = 0;
					for (; i < this.nd.select.Count; i++) {
						localNsSelect1 = this.nd.select[i];
						int j = this.nd.twinLy + localNsSelect1.y
								* (this.nd.twinFh + this.nd.twinSh);
						if ((j > this.nd.clickY)
								|| (this.nd.clickY >= j + localNsSelect1.height
										* (this.nd.twinFh + this.nd.twinSh))) {
							continue;
						}
						this.nd.textSel = i;
						break;
					}
					NsSelect localNsSelect2;
					int k;
					if (this.nd.textSel == -1) {
						for (i = 0; i < this.nd.select.Count; i++) {
							localNsSelect2 = this.nd.select[i];
							localNsSelect2.selected = false;
							for (k = 0; k < localNsSelect2.height; k++) {
								this.nd.text.setAttr(localNsSelect2.y + k, false);
							}
						}
					} else {
						localNsSelect1 = this.nd.select[this.nd.textSel];
						if (localNsSelect1.selected) {
							break;
						}
						for (i = 0; i < this.nd.select.Count; i++) {
							localNsSelect2 = this.nd.select[i];
							localNsSelect2.selected = false;
							for (k = 0; k < localNsSelect2.height; k++) {
								this.nd.text.setAttr(localNsSelect2.y + k, false);
							}
						}
						localNsSelect1.selected = true;
						for (k = 0; k < localNsSelect1.height; k++) {
							this.nd.text.setAttr(localNsSelect1.y + k, true);
						}
					}
					if (!this.nd.fadeFlag) {
						this.tn.paintB();
					} else {
						this.tn.paintF();
					}
				}
				try {
					Thread.Sleep(100);
				} catch (Exception) {
				}
			}
			try {
				if (this.nd.selnum != -1) {
					this.nd.valueNum[this.nd.selnum] = int
							.Parse(localNsSelect1.label);
					this.nd.selnum = -1;
					this.tn.newpage(false);
				} else {
					if (!this.nd.selSkipFlag) {
						this.nd.gosub[this.nd.gosubPos].retpos = getFilePointer();
						this.nd.gosub[this.nd.gosubPos].rest = this.lineRest;
						this.nd.gosubPos += 1;
					}
					this.tn.newpage(false);
					gotoLabel(localNsSelect1.label);
				}
			} catch (Exception) {
				error("select|selgosub|selnum");
			}
		}

		//@Override
		public override void error(String str) {
			base.error(str);
			this.nd.error = str;
		}

		private bool hasError() {
			return this.nd.error != null;
		}
		
		private static NsColor newColor(NsColor color) {
			if (color == null) {
				return null;
			}
			return new NsColor(color.getRGB());
		}	
		
		//@Override 
		protected override void textStar() {
			if (this.nd.labellog == true) {
				String str2 = this.line.Substring(1).ToUpper();
				if (!this.nd.lchk.ContainsKey(str2)) {
					this.nd.lchk.Add(str2, 1);
				}
			}
		}
		
		//@Override
		protected override void textPage() {
			//FIXME:"¨‹"
			this.tn.putMess(this.nd.text, "▼", this.nd.textcolor, true, true);
			if (!this.nd.fadeFlag)
				this.tn.paintB();
			else {
				this.tn.paintF();
			}
			this.tn.newpage(true);		
		}
		
		//@Override
		protected override void textSd() {
			this.nd.twinSpeed = this.nd.defSpeed;
		}
		
		//@Override
		protected override void textW() {
			if (!this.nd.fadeFlag) {
				this.tn.paintB();
			} else {
				this.tn.paintF();
			}
			this.tn.wait(int.Parse(this.line.Substring(2)), false);
		}
		
		//@Override
		protected override void textSharp() {
			this.nd.textcolor = nd.evalColor(this.line.Substring(0, 7));
		}
		
		//@Override
		protected override void textTilde() {
			try {
				this.nd.jumpBack = getFilePointer();
			//} catch (IOException e) {
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}
		
		//FIXME:???
		//@Override
		protected override String evalStr(String paramString) {
			return nd.evalStr(paramString);
		}	
		
		//@Override
		protected override void textShow(String str1) {
			if (str1.Length > 0) {
				tn.putMess(this.nd.text, str1, this.nd.textcolor, true, this.lineCont);
				Console.WriteLine(Encoding.GetEncoding("UTF-8").GetString(Encoding.GetEncoding("UTF-8").GetBytes(str1)));
			}
			if (!this.nd.fadeFlag) {
				this.tn.paintB();
			} else {
				this.tn.paintF();
			}		
		}
	}
}
