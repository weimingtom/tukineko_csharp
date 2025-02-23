using System;
using System.Threading;

namespace tukineko
{
	public class NsTimer : Thread_ {
		private int timer;
		private bool clear_;
		private bool loop;

		public NsTimer() 
			: base("NsTimer") {
			this.timer = 0;
			this.clear_ = false;
			this.loop = true;
			start();
		}

		public NsTimer(int paramInt) 
			: base("NsTimer") {
			this.timer = paramInt;
			this.clear_ = false;
			this.loop = true;
			start();
		}

		public void clear() {
			this.clear_ = true;
		}

		public int read() {
			return this.timer;
		}

		public void exit() {
			this.loop = false;
			try {
				join();
			} catch (Exception) {
			}
		}

		//@Override
		public override void run() {
			while (this.loop) {
				if (this.clear_ == true) {
					this.clear_ = false;
					this.timer = -1;
				}
				this.timer += 1;
				try {
					Thread.Sleep(1);
				} catch (Exception) {
				}
			}
		}
	}
}
