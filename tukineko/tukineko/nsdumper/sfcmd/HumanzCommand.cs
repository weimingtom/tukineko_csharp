using System;

namespace tukineko
{
	public class HumanzCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "humanz");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] humanz");
			
			ns.error("humanz");
		}
	}
}
