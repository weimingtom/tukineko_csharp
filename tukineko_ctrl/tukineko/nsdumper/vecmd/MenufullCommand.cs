using System;

namespace tukineko
{
	public class MenufullCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("menu_full");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] menu_full");
			
			ns.error("menu_full");
		}
	}
}
