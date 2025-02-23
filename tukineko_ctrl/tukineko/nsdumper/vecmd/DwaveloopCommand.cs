using System;

namespace tukineko
{
	public class DwaveloopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "dwaveloop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] dwaveloop");
			
			ns.error("dwaveloop");
		}
	}
}
