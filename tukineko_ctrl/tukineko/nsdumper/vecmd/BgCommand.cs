using System;

namespace tukineko
{
	public class BgCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "bg");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] bg");
			
			//FIXME:add null check
			if (ns == null) 
			{
				debug("[VECommand] bg ns == null");
				return;
			}
			
			if (ns.parseArgs(true) < 2) {
				ns.error("bg");
			} else {
				if ("black".Equals(ns.getArg(0)) == true) {
					ns.nd.bgColor = NsColor.black;
					ns.nd.bgImage = null;
				} else if ("white".Equals(ns.getArg(0)) == true) {
					ns.nd.bgColor = NsColor.white;
					ns.nd.bgImage = null;
				} else if (ns.getArg(0).StartsWith("#") == true) {
					ns.nd.bgColor = ns.nd.evalColor(ns.getArg(0));
					ns.nd.bgImage = null;
				} else {
					ns.nd.bgColor = null;
					ns.nd.bgImage = ns.nd.evalStr(ns.getArg(0));
				}
				ns.nd.bgEffect = ns.nd.evalNum(ns.getArg(1));
				for (int i = 0; i < 3; i++) {
					ns.nd.shell[i] = null;
				}
				ns.tn.paintB();
				ns.makeLineRest(2);
			}		
		}
	}
}
