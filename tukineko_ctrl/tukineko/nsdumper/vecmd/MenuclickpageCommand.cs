using System;

namespace tukineko
{
	public class MenuclickpageCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("menu_click_page");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] menu_click_page");
			
			ns.error("menu_click_page");
		}
	}
}
