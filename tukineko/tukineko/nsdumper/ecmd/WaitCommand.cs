using System;

namespace tukineko
{
	public class WaitCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "wait");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] wait");
			
			ns.error("wait");
		}
	}
}
