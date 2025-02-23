using System;

namespace tukineko
{
	public class TextspeedCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "textspeed");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] textspeed");
			
			ns.error("textspeed");
		}
	}
}
