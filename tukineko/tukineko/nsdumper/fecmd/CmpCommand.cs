using System;

namespace tukineko
{
	public class CmpCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "cmp");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] cmp");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("cmp");
			} else if (!ns.getArg(0).StartsWith("%")) {
				ns.error("cmp");
			} else {
				ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = ns.nd.evalStr(ns.getArg(1)).CompareTo(ns.getArg(2));
				ns.makeLineRest(3);
			}		
		}
	}
}
