using System;

namespace tukineko
{
	public class TimeCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "time");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] time");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("time");
			} else {
				DateTime localDate = DateTime.Now;
				if ((ns.getArg(0).StartsWith("%") == true)
						&& (ns.getArg(1).StartsWith("%") == true)
						&& (ns.getArg(2).StartsWith("%") == true)) {
					// FIXME:
					/*
					 * this.valueNum[evalNum(getArg(0).substring(1))] =
					 * localDate .getHours();
					 * this.valueNum[evalNum(getArg(1).substring(1))] =
					 * localDate .getMinutes();
					 * this.valueNum[evalNum(getArg(2).substring(1))] =
					 * localDate .getSeconds();
					 */
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = localDate.Hour;
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(1).Substring(1))] = localDate.Minute;
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(2).Substring(1))] = localDate.Second;
				} else {
					ns.error("time");
				}
				ns.makeLineRest(3);
			}		
		}
	}
}
