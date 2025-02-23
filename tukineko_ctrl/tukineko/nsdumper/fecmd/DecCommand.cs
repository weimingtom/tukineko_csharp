using System;

namespace tukineko
{
	public class DecCommand : FECommand {
		NScripter ns = NScripter.getInstance();		
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "dec");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] dec");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("dec");
			} else {
				if (!ns.getArg(0).StartsWith("%")) {
					ns.error("dec");
				} else {
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] -= 1;
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
