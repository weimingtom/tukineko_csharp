using System;

namespace tukineko
{
	public class TrapCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "trap");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] trap");
			
			ns.error("trap");
		}
	}
}
