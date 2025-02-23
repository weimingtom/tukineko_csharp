using System;

namespace tukineko
{
	public class MovCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "mov");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] mov");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("move");
			} else {
				if (ns.getArg(0).StartsWith("%") == true) {
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = ns.nd.evalNum(ns.getArg(1));
				} else if (ns.getArg(0).StartsWith("$") == true) {
					ns.nd.valueStr[ns.nd.evalNum(ns.getArg(0).Substring(1))] = ns.nd.evalStr(ns.getArg(1));
				} else {
					ns.error("mov");
				}
				ns.makeLineRest(2);
			}		
		}
	}
}
