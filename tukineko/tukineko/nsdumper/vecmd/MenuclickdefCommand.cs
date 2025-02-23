using System;

namespace tukineko
{
	public class MenuclickdefCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("menu_click_def");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] menu_click_def");
			
			ns.error("menu_click_def");
		}
	}
}
