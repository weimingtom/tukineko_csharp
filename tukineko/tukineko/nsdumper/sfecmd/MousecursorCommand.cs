using System;

namespace tukineko
{
	public class MousecursorCommand : SFECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "mousecursor");
		}
		
		//@Override
		public override void execute() {
			debug("[SFECommand] mousecursor");
			
			ns.error("mousecursor");
		}
	}
}
