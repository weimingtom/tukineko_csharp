using System;

namespace tukineko
{
	public class LocateCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("locate");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] locate");
			
			ns.error("abssetcursor");
		}
	}
}
