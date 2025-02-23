using System;

namespace tukineko
{
	public class EffectblankCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "effectblank");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] effectblank");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("effectblank");
			} else {
				ns.nd.effectblank = ns.nd.evalNum(ns.getArg(0));
				ns.makeLineRest(1);
			}		
		}
	}
}
