using System;

namespace tukineko
{
	public class GosubCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "gosub");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] gosub");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("gosub");
			} else if (ns.nd.gosubPos >= 8) {
				ns.error("gosub: nesting");
			} else {
				try {
					ns.nd.gosub[ns.nd.gosubPos].retpos = ns.getFilePointer();
					ns.nd.gosub[ns.nd.gosubPos].rest = ns.lineRest;
					ns.nd.gosubPos += 1;
					ns.gotoLabel(ns.getArg(0));
				} catch (Exception) {
					ns.error("gosub");
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
