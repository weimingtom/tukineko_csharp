using System;

namespace tukineko
{
	public class DateCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "date");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] date");
			
			if (ns.parseArgs(true) < 3) {
				ns.error("date");
			} else {
				DateTime localDate = DateTime.Now;
				if ((ns.getArg(0).StartsWith("%") == true)
						&& (ns.getArg(1).StartsWith("%") == true)
						&& (ns.getArg(2).StartsWith("%") == true)) {
					// FIXME:
					/*
					 * this.valueNum[evalNum(getArg(0).substring(1))] =
					 * (localDate .getYear() + 1900);
					 * this.valueNum[evalNum(getArg(1).substring(1))] =
					 * (localDate .getMonth() + 1);
					 * this.valueNum[evalNum(getArg(2).substring(1))] =
					 * localDate .getDate();
					 */
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = localDate.Year;
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(1).Substring(1))] = localDate.Month;
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(2).Substring(1))] = localDate.Day;
				} else {
					ns.error("date");
				}
				ns.makeLineRest(3);
			}		
		}
	}
}
