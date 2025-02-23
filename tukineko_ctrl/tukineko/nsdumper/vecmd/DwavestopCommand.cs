using System;

namespace tukineko
{
	public class DwavestopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "dwavestop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] dwavestop");
			
			ns.error("dwavestop");
		}
	}
}
