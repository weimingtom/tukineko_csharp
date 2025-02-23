using System;

namespace tukineko
{
	public class ModCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "mod");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] mod");
			
			ns.error("mod");
		}
	}
}
