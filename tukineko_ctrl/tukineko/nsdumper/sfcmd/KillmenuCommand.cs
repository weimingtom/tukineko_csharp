using System;

namespace tukineko
{
	public class KillmenuCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "killmenu");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] killmenu");
			
			ns.error("killmenu");
		}
	}
}
