using System;

namespace tukineko
{
	public class GlobalonCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "globalon");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] globalon");
			
			ns.setMsRest();
			ns.nd.globalon = true;
			ns.loadGlobalData();		
		}
	}
}
