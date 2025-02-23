using System;

namespace tukineko
{
	public class MenuselectvoiceCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "menuselectvoice");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] menuselectvoice");
			
			ns.error("menuselectvoice");
		}
	}
}
