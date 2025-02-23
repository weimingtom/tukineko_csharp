using System;

namespace tukineko
{
	public class AviCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "avi");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] avi");
			
			ns.error("avi");
		}
	}
}