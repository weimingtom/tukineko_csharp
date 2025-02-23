using System;

namespace tukineko
{
	public class AutoclickCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "autoclick");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] autoclick");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("autoclick");
			} else {
				ns.nd.autoclick = ns.nd.evalNum(ns.getArg(0));
				ns.makeLineRest(1);
			}
		}
	}
}
