using System;

namespace tukineko
{
	public class GettimerCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "gettimer");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] gettimer");
			
			ns.error("gettimer");
		}
	}
}
