using System;

namespace tukineko
{
	public class ClCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("cl");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] cl");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("cl");
			} else {
				if ("l".Equals(ns.nd.evalStr(ns.getArg(0))) == true) {
					ns.nd.shell[0] = null;
				} else if ("c".Equals(ns.nd.evalStr(ns.getArg(0))) == true) {
					ns.nd.shell[1] = null;
				} else if ("r".Equals(ns.nd.evalStr(ns.getArg(0))) == true) {
					ns.nd.shell[2] = null;
				} else {
					ns.nd.shell[0] = null;
					ns.nd.shell[1] = null;
					ns.nd.shell[2] = null;
				}
				ns.tn.paintB();
				ns.makeLineRest(2);
			}		
		}
	}
}
