using System;

namespace tukineko
{
	public class SavenameCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "savename");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] savename");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("savename");
			} else {
				ns.nd.savenameSave = ns.nd.evalStr(ns.getArg(0));
				ns.nd.savenameLoad = ns.nd.evalStr(ns.getArg(1));
				ns.nd.savenameTitle = ns.nd.evalStr(ns.getArg(2));
				ns.makeLineRest(3);
			}		
		}
	}
}
