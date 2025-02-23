using System;

namespace tukineko
{
	public class IntlimitCommand : FCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "intlimit");
		}
		
		//@Override
		public override void execute() {
			debug("[FCommand] intlimit");
			
			ns.error("intlimit");
		}
	}
}
