using System;

namespace tukineko
{
	public class NsColor {
		public static NsColor white = new NsColor(255, 255, 255);
		public static NsColor black = new NsColor(0, 0, 0);

		private uint value;

		public NsColor(uint rgb) {
			value = 0xff000000 | rgb;
		}

		public NsColor(uint r, uint g, uint b) : this(r, g, b, 255) {
			
		}

		public NsColor(uint r, uint g, uint b, uint a) {
			value = ((a & 0xFF) << 24) | ((r & 0xFF) << 16) | ((g & 0xFF) << 8)
					| ((b & 0xFF) << 0);
		}

		public uint getRGB() {
			return value;
		}
	}
}
