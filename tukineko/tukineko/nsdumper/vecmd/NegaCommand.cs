using System;

namespace tukineko
{
	public class NegaCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("nega");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] nega");
			
			ns.error("nega");
		}
	}
}
