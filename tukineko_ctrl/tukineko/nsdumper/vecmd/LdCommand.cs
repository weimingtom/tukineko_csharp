using System;

namespace tukineko
{
	public class LdCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "ld");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] ld");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("ld");
			} else {
				int j;
				if ("l".Equals(ns.nd.evalStr(ns.getArg(0))) == true)
					j = 0;
				else if ("r".Equals(ns.nd.evalStr(ns.getArg(0))) == true)
					j = 2;
				else {
					j = 1;
				}
				String imageName = ns.nd.evalStr(ns.getArg(1));
				ns.nd.shell[j] = new NsShell(imageName,
						ns.nd.evalNum(ns.getArg(2)),
						ns.tn.getImageWidth(imageName),
						ns.tn.getImageHeight(imageName));
				ns.tn.paintB();
				ns.makeLineRest(3);
			}		
		}
	}
}
