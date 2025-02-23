using System;

namespace tukineko
{
	public class GetregCommand : FECommand {
		NScripter ns = NScripter.getInstance();		
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "getreg");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] getreg");
			
			ns.error("getreg");
		}
	}
}
