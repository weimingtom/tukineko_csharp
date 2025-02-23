using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace tukineko
{
	/**
	 * @see http://tlwiki.org/index.php?title=Tools
	 * @see http://nscripter.insani.org/reference/
	 * 
	 * @author 「月猫」 NScripter for PDA in Java (http://www.din.or.jp/~boya/tsukihime/tukineko/index.html)
	 *
	 */
	public class NSParser {
		//TODO: Is the file 'nscript.dat' extracted by ExtractData ?
		protected bool IS_EXTRACTED = false; 
		
		protected byte[] readBuff = new byte[4096];
		protected int readTop = 0;
		protected int readEnd = 0;
		protected int readPos = 0;
		protected RandomAccessFile raf;
		public int storageState = -1;
		public bool exitFlag;
		public String path = "./"; //FIXME:???ns.nd.path
		protected String line = null;
		public String lineRest = null;
		protected bool lineCont = false;
		protected List<String> args = new List<String>();
		private List<SFCommand> sfCommands = new List<SFCommand>();
		private List<SFECommand> sfeCommands = new List<SFECommand>();
		private List<SECommand> seCommands = new List<SECommand>();
		private List<VFECommand> vfeCommands = new List<VFECommand>();
		private List<VECommand> veCommands = new List<VECommand>();
		private List<FCommand> fCommands = new List<FCommand>();
		private List<ECommand> eCommands = new List<ECommand>();
		private List<FECommand> feCommands = new List<FECommand>();
		public bool argCont;

		public NSParser(String path) {
			this.path = path;
		}
		
		protected void initParser() {
			sfCommands.Add(new LookbackbuttonCommand());
			sfCommands.Add(new LookbackcolorCommand());
			sfCommands.Add(new SavenameCommand());
			sfCommands.Add(new ClickstrCommand());
			sfCommands.Add(new FilelogCommand());
			sfCommands.Add(new LabellogCommand());
			sfCommands.Add(new SoundpressplginCommand());
			sfCommands.Add(new VersionstrCommand());
			sfCommands.Add(new EffectblankCommand());
			sfCommands.Add(new BgaliaCommand());
			sfCommands.Add(new CdfadeoutCommand());
			sfCommands.Add(new SpiCommand());
			sfCommands.Add(new ArcCommand());
			sfCommands.Add(new NsaCommand());
			sfCommands.Add(new EffectCommand());
			sfCommands.Add(new TransmodeCommand());
			sfCommands.Add(new StraliasCommand());
			sfCommands.Add(new NumaliasCommand());
			sfCommands.Add(new DefaultfontCommand());
			sfCommands.Add(new SelectcolorCommand());
			sfCommands.Add(new MenuselectcolorCommand());
			sfCommands.Add(new LookbackvoiceCommand());
			sfCommands.Add(new ClickvoiceCommand());
			sfCommands.Add(new SelectvoiceCommand());
			sfCommands.Add(new MenuselectvoiceCommand());
			sfCommands.Add(new GlobalonCommand());
			sfCommands.Add(new HumanzCommand());
			sfCommands.Add(new UnderlineCommand());
			sfCommands.Add(new RlookbackCommand());
			sfCommands.Add(new RoffCommand());
			sfCommands.Add(new RmenuCommand());
			sfCommands.Add(new MenusetwindowCommand());
			sfCommands.Add(new KillmenuCommand());
			sfCommands.Add(new DefSpeedCommand());
			sfCommands.Add(new DsoundCommand());

			sfeCommands.Add(new WindoweffectCommand());
			sfeCommands.Add(new MousecursorCommand());
			sfeCommands.Add(new CaptionCommand());
			sfeCommands.Add(new GetversionCommand());
			
			seCommands.Add(new AbssetcursorCommand());
			seCommands.Add(new SetcursorCommand());
			seCommands.Add(new SetwindowCommand());
			
			vfeCommands.Add(new MesboxCommand());
			
			veCommands.Add(new LocateCommand());
			veCommands.Add(new PuttextCommand());
			veCommands.Add(new AutoclickCommand());
			veCommands.Add(new BrCommand());
			veCommands.Add(new QuakexCommand());
			veCommands.Add(new QuakeyCommand());
			veCommands.Add(new ErasetextwindowCommand());
			veCommands.Add(new TextoffCommand());
			veCommands.Add(new TextonCommand());
			veCommands.Add(new TextclearCommand());
			veCommands.Add(new MenufullCommand());
			veCommands.Add(new MenuwindowCommand());
			veCommands.Add(new MenuclickpageCommand());
			veCommands.Add(new MenuclickdefCommand());
			veCommands.Add(new MonocroCommand());
			veCommands.Add(new NegaCommand());
			veCommands.Add(new BgCommand());
			veCommands.Add(new LdCommand());
			veCommands.Add(new ClCommand());
			veCommands.Add(new PrintCommand());
			veCommands.Add(new TalCommand());
			veCommands.Add(new LspCommand());
			veCommands.Add(new LsphCommand());
			veCommands.Add(new CspCommand());
			veCommands.Add(new VspCommand());
			veCommands.Add(new MspCommand());
			veCommands.Add(new PlayCommand());
			veCommands.Add(new PlayonceCommand());
			veCommands.Add(new StopCommand());
			veCommands.Add(new WaveCommand());
			veCommands.Add(new WaveloopCommand());
			veCommands.Add(new WavestopCommand());
			veCommands.Add(new PlaystopCommand());
			veCommands.Add(new Mp3Command());
			veCommands.Add(new Mp3loopCommand());
			veCommands.Add(new AviCommand());
			veCommands.Add(new DwaveCommand());
			veCommands.Add(new DwaveloopCommand());
			veCommands.Add(new DwavestopCommand());
			veCommands.Add(new BltCommand());
			veCommands.Add(new OfscpyCommand());
			
			fCommands.Add(new IntlimitCommand());
			fCommands.Add(new SavenumberCommand());
			fCommands.Add(new GameCommand());
			
			eCommands.Add(new RmodeCommand());
			eCommands.Add(new SystemcallCommand());
			eCommands.Add(new TrapCommand());
			eCommands.Add(new SelectCommand());
			eCommands.Add(new SelgosubCommand());
			eCommands.Add(new SelnumCommand());
			eCommands.Add(new ResettimerCommand());
			eCommands.Add(new WaittimerCommand());
			eCommands.Add(new GettimerCommand());
			eCommands.Add(new ClickCommand());
			eCommands.Add(new ResetCommand());
			eCommands.Add(new DefineresetCommand());
			eCommands.Add(new DelayCommand());
			eCommands.Add(new WaitCommand());
			eCommands.Add(new TextspeedCommand());
			eCommands.Add(new LookbackflushCommand());
			eCommands.Add(new InputstrCommand());
			eCommands.Add(new ClickposCommand());
			eCommands.Add(new BtndefCommand());
			eCommands.Add(new BtnCommand());
			eCommands.Add(new BtnwaitCommand());
			eCommands.Add(new Btnwait2Command());
			
			feCommands.Add(new EndCommand());
			feCommands.Add(new MovCommand());
			feCommands.Add(new RndCommand());
			feCommands.Add(new Rnd2Command());
			feCommands.Add(new GetregCommand());
			feCommands.Add(new GetiniCommand());
			feCommands.Add(new AddCommand());
			feCommands.Add(new SubCommand());
			feCommands.Add(new IncCommand());
			feCommands.Add(new DecCommand());
			feCommands.Add(new MulCommand());
			feCommands.Add(new DivCommand());
			feCommands.Add(new ModCommand());
			feCommands.Add(new GotoCommand());
			feCommands.Add(new SkipCommand());
			feCommands.Add(new GosubCommand());
			feCommands.Add(new ReturnCommand());
			feCommands.Add(new CmpCommand());
			feCommands.Add(new IfCommand());
			feCommands.Add(new NotifCommand());
			feCommands.Add(new JumpfCommand());
			feCommands.Add(new JumpbCommand());
			feCommands.Add(new LoadgameCommand());
			feCommands.Add(new SavegameCommand());
			feCommands.Add(new AtoiCommand());
			feCommands.Add(new ItoaCommand());
			feCommands.Add(new SaveonCommand());
			feCommands.Add(new SaveoffCommand());
			feCommands.Add(new DateCommand());
			feCommands.Add(new TimeCommand());		
		}

		public virtual void error(String str) {
			Console.Error.WriteLine(str);
			Debug.WriteLine(str);
		}

		public void debug(String str) {
			Console.WriteLine(str);
			Debug.WriteLine(str);
		}

		public void putMess(String str, bool isLineCont) {
			Console.WriteLine(str);
			Debug.WriteLine(str);
		}

		public virtual void run() {
			initParser();
			this.storageState = -2;
			this.storageState = -1;
			this.raf = new RandomAccessFile(this.path, "r");
			this.storageState = 0;
			gotoLabel("*define");
			this.exitFlag = false;
			this.argCont = false;
			while (!this.exitFlag) {
				exec();
			}
			Environment.Exit(0);
		}

		public String newString(String paramString) {
			if (paramString == null) {
				return null;
			}
			return new StringBuilder(paramString).ToString();
		}

		protected int read() {
			if ((this.readTop > this.readPos) || (this.readPos >= this.readEnd)) {
				if (this.readPos == this.readEnd) {
					this.readTop = this.readEnd;
					this.readEnd += this.raf.read(this.readBuff, 0, 4096);
				} else {
					this.raf.seek(this.readPos);
					this.readTop = this.readPos;
					this.readEnd = (this.readTop + this.raf.read(this.readBuff, 0,
							4096));
				}
			}
			if ((this.readTop <= this.readPos) && (this.readPos < this.readEnd)) {
				if (IS_EXTRACTED) {
					return this.readBuff[(this.readPos++ - this.readTop)];
				} else {
					return this.readBuff[(this.readPos++ - this.readTop)] & 0xFF ^ 0x84;
				}
			}
			return -1;
		}

		public int getFilePointer() {
			return this.readPos;
		}

		public String readLine() {
			byte[] arrayOfByte = new byte[1024];
			this.lineCont = false;
			if (this.lineRest == null) {
				addHistory();
				int k;
				int i = k = 0;
				int j;
				while (((j = read()) != 10) && (j != -1)) {
					if (j == 13) {
						continue;
					}
					arrayOfByte[(i++)] = (byte) j;
					if ((j != 32) && (j != 9)) {
						k = i;
					}
					if (j >= 128) {
						int b = read();
						if (b == -1) break;//FIXME:???added
						arrayOfByte[(i++)] = (byte) b;
						k = i;
					}
				}
				if ((i > 0) || (j != -1)) {
					string line_ = Encoding.GetEncoding("Shift-JIS"/*"SJIS"*/).GetString(arrayOfByte, 0, k);
					this.line = line_;
				} else {
					this.line = null;
				}
			} else {
				this.line = this.lineRest;
				this.lineRest = null;
				this.lineCont = true;
			}
			return this.line;
		}

		public virtual void gotoLabel(String paramString) {
			if (!paramString.StartsWith("*")) {
				error("Error Label:" + paramString);
				return;
			}
		}

		public void setMsRest() {
			int i;
			if ((i = this.line.IndexOf(":")) != -1) {
				this.lineRest = this.line.Substring(i + 1);
			}
		}

		public String getArg(int paramInt) {
			return this.args[paramInt];
		}

		public int getArgSize() {
			return this.args.Count;
		}

		public int evalNumAlias(String paramString) {
			return int.Parse(paramString);
		}

		public int evalNum(String paramString) {
			if (paramString.StartsWith("%")) {
				return 0;
			}
			return evalNumAlias(paramString);
		}

		public String evalStrAlias(String paramString) {
			return paramString;
		}

		protected virtual String evalStr(String paramString) {
			if (paramString.StartsWith("$") == true) {
				return "";
			}
			return evalStrAlias(paramString);
		}

		public bool evalBoolean(String paramString) {
			return evalNum(paramString) == 1;
		}

		public bool checkCommand(String paramString1, String paramString2) {
			return (paramString1.Equals(paramString2) == true)
					|| ((paramString1.Length > paramString2.Length)
							&& (paramString1.Substring(0, paramString2.Length)
									.Equals(paramString2) == true) && (" \t"
				                                       .IndexOf(paramString1[paramString2.Length]) != -1));
		}

		public void parseMessageCommand() {
			int j = 0;
			for (; j < this.line.Length; j++) {
				char/*int*/ i;
				//FIXME:Ā
				if (((i = this.line[j]) >= 256/*'Ā'*/) || ((j > 0) && ("!\\".IndexOf((char)i) != -1))) {
					break;
				}
			}
			if (j < this.line.Length) {
				this.lineRest = this.line.Substring(j);
				this.line = this.line.Substring(0, j);
			}
		}

		public virtual void continueSelect() {

		}

		protected int exec() {
			readLine();
			// FIXME: EOF
			if (this.line == null) {
				this.exitFlag = true;
				return this.storageState;
			}
			if (this.line.Length == 0) {
				return this.storageState;
			}
			int i = 0;
			for (; i < this.line.Length; i++) {
				if (" \t".IndexOf(this.line[i]) == -1) {
					break;
				}
			}
			if (i > 0) {
				this.line = this.line.Substring(i);
			}
			if (this.line.StartsWith(";") == true) {
				return this.storageState;
			}
			if (this.line.StartsWith("*") == true) {
				textStar();
				return this.storageState;
			}
			if (settingF(this.line) == true) {
				return this.storageState;
			}
			if (settingFE(this.line) == true) {
				return this.storageState;
			}
			if (settingE(this.line) == true) {
				return this.storageState;
			}
			if (visualE(this.line) == true) {
				return this.storageState;
			}
			if (visualFE(this.line) == true) {
				return this.storageState;
			}
			if (execF(this.line) == true) {
				return this.storageState;
			}
			if (execE(this.line) == true) {
				return this.storageState;
			}
			if (execFE(this.line) == true) {
				return this.storageState;
			}
			if (this.line.StartsWith("\\") == true) {
				parseMessageCommand();
				textPage();
				return this.storageState;
			}
			if (this.line.StartsWith("!sd") == true) {
				parseMessageCommand();
				textSd();
				return this.storageState;
			}
			if (this.line.StartsWith("!w") == true) {
				parseMessageCommand();
				textW();
				return this.storageState;
			}
			if (this.line.StartsWith("#") == true) {
				parseMessageCommand();
				textSharp();
				return this.storageState;
			}
			if (this.line.StartsWith("~") == true) {
				parseMessageCommand();
				textTilde();
				return this.storageState;
			}
			String str1 = evalStr(this.line);
			// FIXME:
			if ((str1.Length > 0) && (str1[0] < 256/*127*/ /* 'Ā' */)) { //FIXME:Ā
				error("Warning: " + str1);
				return this.storageState;
			}
			for (i = 0; i < str1.Length; i++) {
				if (str1[i] == '_' || str1[i] == '@'
				    || str1[i] == '%'
				    || (str1[i] >= '0' && str1[i] <= '9')) {
					str1 = str1.Substring(0, i) + str1.Substring(i + 1);
					i--;
				} else if (str1[i] == '$') {
					int j = i + 1;
					for (; j < str1.Length; j++) {
						if (str1[j] >= 256/*'Ā'*/) { //FIXME:Ā
							break;
						}
					}
					str1 = str1.Substring(0, i) + evalStr(str1.Substring(i, j - i))
							+ str1.Substring(j);
				} else if (str1[i] < 256/*'Ā'*/) { //FIXME:Ā
					this.lineRest = str1.Substring(i);
					str1 = str1.Substring(0, i);
					break;
				}
			}
			textShow(str1);
			return this.storageState;
		}

		public void makeLineRest(int paramInt) {
			if (paramInt >= getArgSize()) {
				return;
			}
			int j = 0;
			int i = 0;
			for (; i < paramInt; i++) {
				j = this.line.IndexOf(getArg(i), j) + getArg(i).Length;
			}
			j = this.line.IndexOf(getArg(i), j);
			this.lineRest = this.line.Substring(j);
		}

		public bool settingF(String paramString) {
			foreach (SFCommand command in sfCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}
			return false;
		}

		public bool settingFE(String paramString) {
			foreach (SFECommand command in sfeCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}
			return false;
		}

		public bool settingE(String paramString) {
			foreach (SECommand command in seCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}
			return false;
		}

		public bool visualE(String paramString) {
			foreach (VECommand command in veCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}		
			return false;
		}

		public bool visualFE(String paramString) {
			foreach (VFECommand command in vfeCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}		
			return false;
		}

		public bool execF(String paramString) {
			foreach (FCommand command in fCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}		
			return false;
		}

		public bool execE(String paramString) {
			foreach (ECommand command in eCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}		
			return false;
		}

		public bool execFE(String paramString) {
			foreach (FECommand command in feCommands) {
				if (command.check(paramString)) {
					command.execute();
					return true;
				}
			}
			return false;
		}
		
		public static void main(String[] args) {
			NSParser parser = new NSParser("data/0.txt");
			//FIXME:added
			parser.IS_EXTRACTED = true;
			parser.run();
		}
		
		//to parser
		public int parseArgs(bool paramBoolean) {
			this.args.Clear(); //removeAllElements();
			int i = 0;
			if (paramBoolean == true) {
				while (" \t".IndexOf(this.line[i]) == -1)
					i++;
			}
			do {
				while (" \t".IndexOf(this.line[i]) != -1)
					i++;
				int j;
				int k;
				if (this.line[i] == '"') {
					i++;
					if ((j = i) >= this.line.Length)
						break;
					do {
						j++;
						if (j >= this.line.Length)
							break;
					} while (this.line[j] != '"');

					this.args.Add(this.line.Substring(i, j - i));
					j++;
				} else {
					j = i + 1;

					while ((j < this.line.Length)
					       && (" \t,:;&\\".IndexOf((char)(k = this.line[j])) == -1)
							&& (k < 256)) {
						j++;
					}
					if ((j < this.line.Length) && (this.line[i] == '&')
					    && (this.line[j] == '&')) {
						j++;
					}
					this.args.Add(this.line.Substring(i, j - i));
				}

				while ((j < this.line.Length)
				       && (" \t".IndexOf(this.line[j]) != -1)) {
					j++;
				}
				this.argCont = false;
				if (j < this.line.Length) {
					if ((k = this.line[j]) == ':') {
						this.lineRest = this.line.Substring(j + 1);
						break;
					}
					if (k > 255) {
						this.lineRest = this.line.Substring(j);
						break;
					}
					if (k == 59)
						break;
					if (k == 44) {
						this.argCont = true;
						j++;
					}
				}
				i = j;
			} while (i < this.line.Length);

			return this.args.Count;
		}	
		
		protected virtual void textStar() {
		}
		
		protected virtual void textPage() {
		}
		
		protected virtual void textSd() {
		}
		
		protected virtual void textW() {
		}
		
		protected virtual void textSharp() {
		}
		
		protected virtual void textTilde() {
		}
		
		protected virtual void textShow(String str1) {
			if (str1.Length > 0) {
				putMess(str1, this.lineCont);
			}
		}
		
		//to parser
		public void setFilePointer(int paramInt) {
			this.readPos = paramInt;
		}	
		
		protected virtual void addHistory() {
		}
	}
}
