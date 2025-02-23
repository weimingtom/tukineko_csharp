using System;

namespace tukineko
{
	public class RmenuCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "rmenu");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] rmenu");
			
			int j;
			if ((j = ns.parseArgs(true)) % 2 != 0) {
				ns.error("rmenu");
			} else {
				for (int i = 0; i < j; i += 2) {
					if ("skip".Equals(ns.nd.evalStr(ns.getArg(i + 1))) == true) {
						ns.nd.rmenu[0] = ns.nd.evalStr(ns.getArg(i));
						if ((ns.nd.rotate == true)
								&& (ns.nd.rmenu[0].Length >= 5)) {
							ns.nd.rmenu[0] = ns.nd.rmenu[0].Substring(0, 5);
						}
						ns.tn.popupMenuAdd(ns.nd.rmenu[0]);
					} else if ("reset".Equals(ns.nd.evalStr(ns.getArg(i + 1))) == true) {
						ns.nd.rmenu[1] = ns.nd.evalStr(ns.getArg(i));
						if ((ns.nd.rotate == true)
								&& (ns.nd.rmenu[1].Length >= 5)) {
							ns.nd.rmenu[1] = ns.nd.rmenu[1].Substring(0, 5);
						}
						ns.tn.popupMenuAdd(ns.nd.rmenu[1]);
					} else if ("save".Equals(ns.nd.evalStr(ns.getArg(i + 1))) == true) {
						ns.nd.rmenu[2] = ns.nd.evalStr(ns.getArg(i));
						if ((ns.nd.rotate == true)
								&& (ns.nd.rmenu[2].Length >= 5)) {
							ns.nd.rmenu[2] = ns.nd.rmenu[2].Substring(0, 5);
						}
						ns.tn.createMenuSave(ns.nd.rmenu[2]);
					} else if ("load".Equals(ns.nd.evalStr(ns.getArg(i + 1))) == true) {
						ns.nd.rmenu[3] = ns.nd.evalStr(ns.getArg(i));
						if ((ns.nd.rotate == true)
								&& (ns.nd.rmenu[3].Length >= 5)) {
							ns.nd.rmenu[3] = ns.nd.rmenu[3].Substring(0, 5);
						}
						ns.tn.createMenuLoad(ns.nd.rmenu[3]);
					} else if ("lookback"
							.Equals(ns.nd.evalStr(ns.getArg(i + 1))) == true) {
						ns.nd.rmenu[4] = ns.nd.evalStr(ns.getArg(i));
						if ((ns.nd.rotate == true)
								&& (ns.nd.rmenu[4].Length >= 5)) {
							ns.nd.rmenu[4] = ns.nd.rmenu[4].Substring(0, 5);
						}
						ns.tn.popupMenuAdd(ns.nd.rmenu[4]);
					} else if ("windowerase".Equals(ns.nd
							.evalStr(ns.getArg(i + 1))) == true) {
						ns.nd.rmenu[5] = ns.nd.evalStr(ns.getArg(i));
						if ((ns.nd.rotate == true)
								&& (ns.nd.rmenu[5].Length >= 5))
							ns.nd.rmenu[5] = ns.nd.rmenu[5].Substring(0, 5);
						ns.tn.popupMenuAdd(ns.nd.rmenu[5]);
					} else {
						ns.error("rmenu: " + ns.nd.evalStr(ns.getArg(i)));
					}
				}
			}		
		}
	}
}
