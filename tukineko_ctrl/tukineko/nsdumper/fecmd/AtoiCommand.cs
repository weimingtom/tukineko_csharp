using System;

namespace tukineko
{
	public class AtoiCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "atoi");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] atoi");
			
			ns.error("atoi");
		}
	}
}
