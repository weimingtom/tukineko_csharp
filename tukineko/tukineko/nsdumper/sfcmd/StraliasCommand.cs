using System;

namespace tukineko
{
	public class StraliasCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "stralias");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] stralias");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("stralias");
			} else {
				ns.nd.stralias.Add(ns.getArg(0), ns.getArg(1));
				ns.makeLineRest(2);
			}		
		}
	}
}
