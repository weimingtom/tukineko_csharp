using System;

namespace tukineko
{
	public class SarEntry {
		public String name;
		public int offset;
		public int length;

		public SarEntry(String name, int offset, int length) {
			this.name = name;
			this.offset = offset;
			this.length = length;
		}

		public int length_() {
			return this.length;
		}

		//@Override
		public override String ToString() {
			return "SarEntry name:" + this.name + ",offset:"
					+ this.offset + ",length:" + this.length;
		}
	}
}
