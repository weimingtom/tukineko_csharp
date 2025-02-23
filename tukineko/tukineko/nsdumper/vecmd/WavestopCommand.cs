using System;

namespace tukineko
{
	public class WavestopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("wavestop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] wavestop");
			
			ns.error("wavestop");
		}
	}
}
