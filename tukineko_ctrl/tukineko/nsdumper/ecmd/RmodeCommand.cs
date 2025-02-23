using System;

namespace tukineko
{
	public class RmodeCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "rmode");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] rmode");
			
			ns.error("rmode");
		}
	}
}
