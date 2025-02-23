using System;

namespace tukineko
{
	public class InputstrCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "inputstr");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] inputstr");
			
			ns.error("inputstr");
		}
	}
}
