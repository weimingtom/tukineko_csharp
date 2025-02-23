using System;

namespace tukineko
{
	public class SetwindowCommand : SECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "setwindow");
		}
		
		//@Override
		public override void execute() {
			debug("[SECommand] setwindow");
			
			//FIXME:add null check
			if (ns == null) 
			{
				debug("[SECommand] setwindow ns == null");
				return;
			}
			
			if (ns.parseArgs(true) < 14) {
				ns.error("setwindow");
			} else {
				ns.nd.twinLx = ns.nd.evalNum(ns.getArg(0));
				ns.nd.twinLy = ns.nd.evalNum(ns.getArg(1));
				ns.nd.twinLw = ns.nd.evalNum(ns.getArg(2));
				ns.nd.twinLh = ns.nd.evalNum(ns.getArg(3));
				ns.nd.twinFw = ns.nd.evalNum(ns.getArg(4));
				ns.nd.twinFh = ns.nd.evalNum(ns.getArg(5));
				ns.nd.twinSw = ns.nd.evalNum(ns.getArg(6));
				ns.nd.twinSh = ns.nd.evalNum(ns.getArg(7));
				ns.nd.twinSpeed = ns.nd.evalNum(ns.getArg(8));
				ns.nd.twinBold = false;
				ns.nd.twinShadow = ns.nd.evalBoolean(ns.getArg(10));
				int i;
				if (ns.getArg(11).StartsWith("#") == true) {
					ns.nd.twinColor = ns.nd.evalColor(ns.getArg(11));
					ns.nd.twinImage = null;
					ns.nd.twinHx = ns.nd.evalNum(ns.getArg(12));
					ns.nd.twinHy = ns.nd.evalNum(ns.getArg(13));
					ns.nd.twinEx = ns.nd.evalNum(ns.getArg(14));
					ns.nd.twinEy = ns.nd.evalNum(ns.getArg(15));
					i = 16;
				} else {
					ns.nd.twinColor = null;
					ns.nd.twinImage = ns.nd.evalStr(ns.getArg(11));
					ns.nd.twinHx = ns.nd.evalNum(ns.getArg(12));
					ns.nd.twinHy = ns.nd.evalNum(ns.getArg(13));
					i = 14;
				}
				ns.nd.text = new NsText(ns.nd.twinLw, ns.nd.twinLh);
				ns.makeLineRest(i);
			}		
		}
	}
}
