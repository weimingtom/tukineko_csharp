using System;

namespace tukineko
{
	public class EndCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "end");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] end");
			
			ns.setMsRest();
			ns.exitFlag = true;
		}
	}
}
