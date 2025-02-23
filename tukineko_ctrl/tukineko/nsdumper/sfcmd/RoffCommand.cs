using System;

namespace tukineko
{
	public class RoffCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "roff");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] roff");
			
			ns.error("roff");
		}
	}
}
