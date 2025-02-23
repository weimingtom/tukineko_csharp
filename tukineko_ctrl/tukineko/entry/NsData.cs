using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace tukineko
{
	public class NsData {
		//private const long serialVersionUID = 1L;

		public int selectState;
		public bool textVisible; // text
		public int gosubPos; // gosub

		public int twinLx;
		public int twinLy;
		public int twinLw;
		public int twinLh;
		public int twinFw;
		public int twinFh;
		public int twinSw;
		public int twinSh;
		public int twinSpeed;
		public int twinHx;
		public int twinHy;
		public int twinEx;
		public int twinEy;
		public bool twinBold;
		public bool twinShadow;
		public NsColor twinColor;
		public String twinImage;

		public String bgImage;
		public NsColor bgColor;
		public int bgEffect;
		public int autoclick;

		public int quakex;
		public int quakey;

		public int textSel; // select
		public bool selSkipFlag;
		public int selnum;
		public NsColor textcolor;

		public String btnImage; // btn

		public int btnSel;// btn
		public bool btnVisible;

		public int[] history;
		public int historyPos;
		public int historyCount;
		public int jumpBack;

		// not write
		public int effectblank;
		public int cdfadeout;
		public String clickstr;
		public int clickstrLine;
		public NsColor selectcolorOn;
		public NsColor selectcolorOut;
		public int menusetwindowFx;
		public int menusetwindowFy;
		public int menusetwindowSx;
		public int menusetwindowSy;
		public bool menusetwindowBold;
		public bool menusetwindowShadow = false;
		public NsColor menusetwindowColor;
		public NsColor menuselectcolorOn;
		public NsColor menuselectcolorOut;
		public NsColor menuselectcolorNosave;

		// rmenu ?
		public String savenameSave;
		public String savenameLoad;
		public String savenameTitle;

		public NsColor lookbackcolor;

		public bool globalon;
		public bool filelog;
		public bool labellog;

		public int defSpeed;
		public int defSpeedLow;
		public int defSpeedMiddle;
		public int defSpeedHigh;

		public int savenumber;

		public String[] rmenu;

		public uint[] fadeImg; //image pixels
		public bool fadeMode;
		public bool fadeFlag;

		public bool click;
		public int clickX;
		public int clickY;

	//	public bool exitFlag;

	//	public int storageState;
		public int storageNo;

		public int[] valueNum;
		public String[] valueStr;

		public Dictionary<String, int> label;
		public Dictionary<String, String> numalias;
		public Dictionary<String, String> stralias;
		public Dictionary<String, NsEffect> effect;
		public Dictionary<String, int> fchk;
		public Dictionary<String, int> lchk;

		public NsText text;
		public NsGosub[] gosub;
		public NsShell[] shell;
		public NsSprite[] sprite;
		public List<NsSelect> select;
		public List<NsButton> btn;

		public bool menuVisible;
	//	public String path;
		public bool rotate;

		// FIXME: global exit
		public String error;

		public NsData() {
			this.error = null;

			this.click = false;
			this.clickX = -1;
			this.clickY = -1;
			this.valueNum = new int[4096];
			this.valueStr = new String[4096];
			for (int i = 0; i < 4096; i++) {
				this.valueNum[i] = 0;
				this.valueStr[i] = "";
			}
	//		this.storageState = -1;
			this.storageNo = 0;
			//
			this.fadeImg = new uint[320 * 240];
			this.fadeMode = true;
			this.fadeFlag = false;
			this.selectState = 0;
			//
			this.text = null;
			this.textVisible = true;
			this.gosub = new NsGosub[8];
			this.gosubPos = 0;
			for (int i = 0; i < 8; i++) {
				this.gosub[i] = new NsGosub();
			}
			this.label = new Dictionary<String, int>();
			this.numalias = new Dictionary<String, String>();
			this.stralias = new Dictionary<String, String>();
			this.effect = new Dictionary<String, NsEffect>();
			this.fchk = new Dictionary<String, int>();
			this.lchk = new Dictionary<String, int>();
			//
			this.rmenu = new String[6];
			this.globalon = false;
			this.filelog = false;
			this.labellog = false;
			this.defSpeedLow = 20;
			this.defSpeedMiddle = 10;
			this.defSpeedHigh = 0;
			this.defSpeed = this.defSpeedMiddle;
			this.twinSpeed = this.defSpeed;
			this.autoclick = 0;
			this.shell = new NsShell[3];
			this.sprite = new NsSprite[50];
			for (int i = 0; i < 50; i++) {
				this.sprite[i] = new NsSprite();
			}
			this.btn = new List<NsButton>();
			this.btnSel = -1;
			this.btnVisible = false;
			this.quakex = 0;
			this.quakey = 0;
			this.select = new List<NsSelect>();
			this.textSel = -1;
			this.selSkipFlag = false;
			this.selnum = -1;
			this.textcolor = NsColor.white;
			this.history = new int[100];
			this.historyPos = 0;
			this.historyCount = 0;
			this.jumpBack = 0;
		}

		public int evalNumAlias(String paramString) {
			if (this.numalias.ContainsKey(paramString) == true) {
				return int.Parse(this.numalias[paramString]);
			}
			return int.Parse(paramString);
		}

		public int evalNum(String paramString) {
			if (paramString.StartsWith("%")) {
				return this.valueNum[evalNumAlias(paramString.Substring(1))];
			}
			return evalNumAlias(paramString);
		}

		public String evalStrAlias(String paramString) {
			if (this.stralias.ContainsKey(paramString) == true) {
				return this.stralias[paramString];
			}
			return paramString;
		}

		public String evalStr(String paramString) {
			if (paramString.StartsWith("$") == true) {
				return this.valueStr[evalNum(paramString.Substring(1))];
			}
			return evalStrAlias(paramString);
		}

		public bool evalBoolean(String paramString) {
			return evalNum(paramString) == 1;
		}

		public NsColor evalColor(String paramString) {
			if ((paramString.Length != 7) || (!paramString.StartsWith("#"))) {
				Console.Error.WriteLine("color value: " + paramString);
				Debug.WriteLine("color value: " + paramString);
				
				return null;
			}
			try {
				uint color = Convert.ToUInt32(paramString.Substring(1), 16) | 0xFF000000;
				return new NsColor(color);
			} catch (NumberFormatException) {
				Console.Error.WriteLine("color value: " + paramString);
				Debug.WriteLine("color value: " + paramString);
			}
			return null;
		}

	}
}
