using System;

namespace tukineko
{
	public class DsoundCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "dsound");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] dsound");
			
			ns.error("dsound");
		}
	}
}
