using System;

namespace tukineko
{
	public class ErasetextwindowCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("erasetextwindow");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] erasetextwindow");
			
			ns.error("erasetextwindow");
		}
	}
}
