using System;

namespace tukineko
{
	public class GetversionCommand : SFECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "getversion");
		}
		
		//@Override
		public override void execute() {
			debug("[SFECommand] getversion");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("getversion");
			} else {
				if (!ns.getArg(0).StartsWith("%")) {
					ns.error("getversion");
				} else {
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = 999;
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
