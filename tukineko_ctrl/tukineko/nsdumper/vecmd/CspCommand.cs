using System;

namespace tukineko
{
	public class CspCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("csp");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] csp");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("csp");
			} else {
				int i = ns.nd.evalNum(ns.getArg(0));
				if (i >= 0) {
					ns.nd.sprite[i].visible = false;
				} else {
					for (int i2 = 0; i2 < 50; i2++) {
						ns.nd.sprite[i2].visible = false;
					}
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
