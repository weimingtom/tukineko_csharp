using System;

namespace tukineko
{
	public class DelayCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "delay");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] delay");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("delay");
			} else {
				ns.tn.wait(ns.nd.evalNum(ns.getArg(0)), true);
				ns.makeLineRest(1);
			}
		}
	}
}
