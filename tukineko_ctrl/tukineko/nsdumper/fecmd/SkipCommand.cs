using System;

namespace tukineko
{
	public class SkipCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "skip");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] skip");
			
			int j;
			if (ns.parseArgs(true) < 1) {
				ns.error("skip");
			} else {
				int i = ns.nd.evalNum(ns.getArg(0));
				if (i < 0) {
					if ((i < -99) || (ns.nd.historyCount < -i)) {
						ns.error("skip:" + Convert.ToString(i));
					} else {
						try {
							ns.backHistory(-i);
						} catch (IOException) {
							ns.error("skip-");
						}
					}
				} else if (i > 1) {
					for (j = 0; j < i - 1; j++) {
						try {
							ns.readLine();
						} catch (IOException) {
							ns.error("skip+");
						}
					}
				}
				ns.makeLineRest(1);
			}		
		}
	}
}
