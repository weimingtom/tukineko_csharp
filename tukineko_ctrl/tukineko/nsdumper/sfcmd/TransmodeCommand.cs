using System;

namespace tukineko
{
	public class TransmodeCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "transmode");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] transmode");
			
			ns.error("transmode");
		}
	}
}
