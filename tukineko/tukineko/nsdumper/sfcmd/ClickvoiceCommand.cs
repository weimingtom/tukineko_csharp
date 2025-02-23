using System;

namespace tukineko
{
	public class ClickvoiceCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "clickvoice");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] clickvoice");
			
			ns.error("clickvoice");
		}
	}
}
