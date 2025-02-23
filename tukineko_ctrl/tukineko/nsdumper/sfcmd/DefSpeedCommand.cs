using System;

namespace tukineko
{
	public class DefSpeedCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "defSpeed");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] defSpeed");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("defSpeed");
			} else {
				ns.nd.defSpeedLow = ns.nd.evalNum(ns.getArg(0));
				ns.nd.defSpeedMiddle = ns.nd.evalNum(ns.getArg(1));
				ns.nd.defSpeedHigh = ns.nd.evalNum(ns.getArg(2));
				ns.makeLineRest(3);
			}		
		}
	}
}
