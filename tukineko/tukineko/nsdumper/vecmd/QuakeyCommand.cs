using System;
using System.Threading;

namespace tukineko
{
	public class QuakeyCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("quakey");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] quakey");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("quakey");
			} else {
				for (int i = 0; i < ns.nd.evalNum(ns.getArg(0)); i++) {
					ns.nd.quakey += 1;
					ns.tn.paintB();
					try {
						Thread.Sleep(ns.nd.evalNum(ns.getArg(1)));
					} catch (Exception) {

					}
				}
				ns.nd.quakey = 0;
				ns.tn.paintB();
				ns.makeLineRest(2);
			}		
		}
	}
}
