using System;

namespace tukineko
{
	public class SelectvoiceCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "selectvoice");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] selectvoice");
			
			ns.error("selectvoice");
		}
	}
}
