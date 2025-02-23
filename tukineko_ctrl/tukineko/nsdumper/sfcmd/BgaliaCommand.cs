using System;

namespace tukineko
{
	public class BgaliaCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "bgalia");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] bgalia");
		
			ns.error("bgalia");
		}
	}
}
