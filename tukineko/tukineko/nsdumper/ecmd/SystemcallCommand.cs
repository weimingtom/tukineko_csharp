using System;

namespace tukineko
{
	public class SystemcallCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "systemcall");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] systemcall");
			
			ns.error("systemcall");
		}
	}
}