using System;

namespace tukineko
{
	public class NumaliasCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "numalias");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] numalias");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("numalias");
			} else {
				ns.nd.numalias.Add(ns.getArg(0), ns.getArg(1));
				ns.makeLineRest(2);
			}		
		}
	}
}
