using System;

namespace tukineko
{
	public class NsEffect {
		//private const long serialVersionUID = 1L;

		public int type;
		public int time;
		public String pattern;

		public NsEffect(int type) {
			this.type = type;
			this.time = 0;
			this.pattern = null;
		}

		public NsEffect(int type, int time) {
			this.type = type;
			this.time = time;
			this.pattern = null;
		}

		public NsEffect(int type, int time, String pattern) {
			this.type = type;
			this.time = time;
			this.pattern = pattern;
		}
	}
}
