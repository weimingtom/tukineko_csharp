using System;

namespace tukineko
{
	public class NsText {
		//private const long serialVersionUID = 1L;

		public String[] mess;
		public NsColor[] color;
		public bool[] attr;
		public int curX;
		public int curY;
		public int width;
		public int height;

		public NsText(int width, int height) {
			this.width = width;
			this.height = height;
			this.mess = new String[height];
			this.color = new NsColor[height];
			this.attr = new bool[height];
			cls();
		}

		public void cls() {
			this.curX = 0;
			this.curY = 0;
			for (int i = 0; i < this.height; i++) {
				this.mess[i] = "";
				this.color[i] = NsColor.white;
				this.attr[i] = false;
			}
		}

		public void clearY() {

		}

		public int getY() {
			return this.curY;
		}

		public String getMess(int k) {
			if (k < this.height) {
				return this.mess[k];
			}
			return null;
		}

		public NsColor getColor(int k) {
			if (k < this.height) {
				return this.color[k];
			}
			return NsColor.white;
		}

		public bool getAttr(int k) {
			if (k < this.height) {
				return this.attr[k];
			}
			return true;
		}

		public void setAttr(int k, bool v) {
			this.attr[k] = v;
		}
	}
}
