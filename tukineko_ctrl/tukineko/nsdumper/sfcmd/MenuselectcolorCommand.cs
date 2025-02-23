using System;

namespace tukineko
{
	public class MenuselectcolorCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "menuselectcolor");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] menuselectcolor");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("menuselectcolor");
			} else {
				ns.nd.menuselectcolorOn = ns.nd.evalColor(ns.nd
						.evalStr(ns.getArg(0)));
				ns.nd.menuselectcolorOut = ns.nd.evalColor(ns.nd
						.evalStr(ns.getArg(1)));
				ns.nd.menuselectcolorNosave = ns.nd.evalColor(ns.nd
						.evalStr(ns.getArg(2)));
				ns.makeLineRest(3);
			}		
		}
	}
}
