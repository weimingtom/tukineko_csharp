using System;

namespace tukineko
{
	public class TextoffCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("textoff");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] textoff");
			
			ns.error("textoff");
		}
	}
}
