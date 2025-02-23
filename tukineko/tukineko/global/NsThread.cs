using System;

namespace tukineko
{
	public class NsThread : Thread_ {
		private NScripter ns;

		public NsThread(NScripter ns) 
			: base("NsThread") {
			this.ns = ns;
		}

		//@Override
		public override void run() {
			this.ns.run();
		}
	}
}
