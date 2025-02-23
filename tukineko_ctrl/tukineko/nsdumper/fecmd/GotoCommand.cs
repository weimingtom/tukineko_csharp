using System;

namespace tukineko
{
	public class GotoCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "goto");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] goto");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("goto");
			} else {
				try {
					ns.gotoLabel(ns.getArg(0));
				} catch (Exception) {
					ns.error("goto");
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
