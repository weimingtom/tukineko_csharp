using System;

namespace tukineko
{
	public class VspCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("vsp");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] vsp");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("vsp");
			} else {
				ns.nd.sprite[ns.nd.evalNum(ns.getArg(0))].visible = 
						(ns.nd.evalNum(ns.getArg(1)) == 1);
				ns.makeLineRest(2);
			}		
		}
	}
}
