using System;

namespace tukineko
{
	public class MulCommand : FECommand {
		NScripter ns = NScripter.getInstance();	
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "mul");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] mul");
			
			ns.error("mul");
		}
	}
}
