using System;

namespace tukineko
{
	public class ItoaCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "itoa");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] itoa");
			
			ns.error("itoa");
		}
	}
}
