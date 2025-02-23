using System;

namespace tukineko
{
	public class ClickCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "click");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] click");
			
			ns.error("click");
		}
	}
}
