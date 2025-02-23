using System;

namespace tukineko
{
	public class RlookbackCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "rlookback");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] rlookback");
			
			ns.error("rlookback");
		}
	}
}
