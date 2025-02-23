using System;

namespace tukineko
{
	public class IncCommand : FECommand {
		NScripter ns = NScripter.getInstance();		
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "inc");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] inc");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("inc");
			} else {
				if (!ns.getArg(0).StartsWith("%")) {
					ns.error("inc");
				} else {
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] += 1;
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
