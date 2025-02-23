using System;

namespace tukineko
{
	public class StopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("stop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] stop");
			
			ns.error("stop");
		}
	}
}
