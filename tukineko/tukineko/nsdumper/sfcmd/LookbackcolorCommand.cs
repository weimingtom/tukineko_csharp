using System;

namespace tukineko
{
	public class LookbackcolorCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "lookbackcolor");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] lookbackcolor");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("lookbackcolor");
			} else {
				ns.nd.lookbackcolor = ns.nd.evalColor(ns.getArg(0));
				ns.makeLineRest(1);
			}		
		}
	}
}
