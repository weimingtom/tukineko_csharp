using System;

namespace tukineko
{
	public class LookbackvoiceCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "lookbackvoice");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] lookbackvoice");
			
			ns.error("lookbackvoice");
		}
	}
}
