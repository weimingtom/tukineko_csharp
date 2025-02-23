using System;

namespace tukineko
{
	public class ClickposCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "clickpos");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] clickpos");
			
			ns.error("clickpos");
		}
	}
}
