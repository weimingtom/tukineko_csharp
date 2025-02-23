using System;

namespace tukineko
{
	public class DwaveCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "dwave");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] dwave");
			
			ns.error("dwave");
		}
	}
}
