using System;

namespace tukineko
{
	public class WaittimerCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "waittimer");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] waittimer");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("waittimer");
			} else {
				int i = ns.nd.evalNum(ns.getArg(0)) - ns.tn.timerRead();
				if (i > 0) {
					ns.tn.wait(i, false);
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
