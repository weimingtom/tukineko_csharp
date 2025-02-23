using System;

namespace tukineko
{
	public class AddCommand : FECommand {
		NScripter ns = NScripter.getInstance();	
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "add");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] add");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("add");
			} else {
				if (!ns.getArg(0).StartsWith("%")) {
					ns.error("add");
				} else {
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] += ns.nd.evalNum(ns.getArg(1));
				}
				ns.makeLineRest(2);
			}		
		}
	}
}
