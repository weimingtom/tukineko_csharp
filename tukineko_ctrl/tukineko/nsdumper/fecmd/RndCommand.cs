using System;

namespace tukineko
{
	public class RndCommand : FECommand {
		NScripter ns = NScripter.getInstance();	
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "rnd");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] rnd");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("rnd");
			} else {
				if (ns.getArg(0).StartsWith("%") == true) {
					Random random = new Random((int)DateTime.Now.Ticks);
					double randomVal = random.Next(0, 100) / 100.0;
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = (int) (randomVal * ns.nd.evalNum(ns.getArg(1)));
				} else {
					ns.error("rnd");
				}
				ns.makeLineRest(2);
			}		
		}
	}
}
