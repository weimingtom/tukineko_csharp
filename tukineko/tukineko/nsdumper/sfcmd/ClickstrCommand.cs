using System;

namespace tukineko
{
	public class ClickstrCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "clickstr");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] clickstr");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("clickstr");
			} else {
				ns.nd.clickstr = ns.nd.evalStr(ns.getArg(0));
				ns.nd.clickstrLine = ns.nd.evalNum(ns.getArg(1));
				ns.makeLineRest(2);
			}		
		}
	}
}