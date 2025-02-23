using System;

namespace tukineko
{
	public class PrintCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "print");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] print");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("print");
			} else {
				ns.tn.paintB();
				ns.makeLineRest(1);
			}		
		}
	}
}
