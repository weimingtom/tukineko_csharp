using System;

namespace tukineko
{
	public class BtnCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "btn");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] btn");
			
			if (ns.parseArgs(true) < 7) {
				ns.error("btn");
			} else {
				ns.nd.btn.Add(new NsButton(
						ns.nd.evalNum(ns.getArg(0)), 
						ns.nd.evalNum(ns.getArg(1)), ns.nd.evalNum(ns.getArg(2)), 
						ns.nd.evalNum(ns.getArg(3)), ns.nd.evalNum(ns.getArg(4)), 
						ns.nd.evalNum(ns.getArg(5)), ns.nd.evalNum(ns.getArg(6))));
				ns.makeLineRest(7);
			}
		}
	}
}
