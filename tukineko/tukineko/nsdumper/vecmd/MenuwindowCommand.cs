using System;

namespace tukineko
{
	public class MenuwindowCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("menu_window");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] menu_window");
			
			ns.error("menu_window");
		}
	}
}
