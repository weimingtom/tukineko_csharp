using System;

namespace tukineko
{
	public class SubCommand : FECommand {
		NScripter ns = NScripter.getInstance();	
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "sub");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] sub");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("sub");
			} else if (!ns.getArg(0).StartsWith("%")) {
				ns.error("sub");
			} else {
				ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] -= ns.nd.evalNum(ns.getArg(1));
			}		
		}
	}
}
