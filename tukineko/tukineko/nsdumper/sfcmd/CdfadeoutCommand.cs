using System;

namespace tukineko
{
	public class CdfadeoutCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "cdfadeout");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] cdfadeout");
		
			if (ns.parseArgs(true) < 1) {
				ns.error("cdfadeout");
			} else {
				ns.nd.cdfadeout = ns.nd.evalNum(ns.getArg(0));
				ns.makeLineRest(1);
			}		
		}
	}
}