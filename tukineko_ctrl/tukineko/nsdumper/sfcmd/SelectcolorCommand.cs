using System;

namespace tukineko
{
	public class SelectcolorCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "selectcolor");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] selectcolor");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("selectcolor");
			} else {
				ns.nd.selectcolorOn = ns.nd.evalColor(ns.nd
						.evalStr(ns.getArg(0)));
				ns.nd.selectcolorOut = ns.nd.evalColor(ns.nd
						.evalStr(ns.getArg(1)));
				ns.makeLineRest(2);
			}		
		}
	}
}
