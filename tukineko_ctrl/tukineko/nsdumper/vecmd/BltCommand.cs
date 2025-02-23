using System;

namespace tukineko
{
	public class BltCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "blt");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] blt");
			
			if (ns.parseArgs(true) < 8) {
				// FIXME:
				ns.error("bly");
			} else {
				int j = ns.nd.evalNum(ns.getArg(0));
				int k = ns.nd.evalNum(ns.getArg(1));
				int m = ns.nd.evalNum(ns.getArg(2));
				int n = ns.nd.evalNum(ns.getArg(3));
				int i1 = ns.nd.evalNum(ns.getArg(4));
				int i2 = ns.nd.evalNum(ns.getArg(5));
				// FIXME:
				/* int i3 = */ns.nd.evalNum(ns.getArg(6));
				/* int i4 = */ns.nd.evalNum(ns.getArg(7));
				ns.makeLineRest(8);

				// TODO:
				ns.tn.blt(j, k, m, n, i1, i2);

				ns.tn.paintB();
			}		
		}
	}
}
