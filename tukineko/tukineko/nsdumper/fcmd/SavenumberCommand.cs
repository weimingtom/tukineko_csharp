using System;

namespace tukineko
{
	public class SavenumberCommand : FCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "savenumber");
		}
		
		//@Override
		public override void execute() {
			debug("[FCommand] savenumber");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("savenumber");
			} else {
				ns.nd.savenumber = ns.nd.evalNum(ns.getArg(0));
				if (ns.nd.savenumber > 10) {
					ns.nd.savenumber = 10;
				}
				ns.makeLineRest(1);
			}
		}
	}
}
