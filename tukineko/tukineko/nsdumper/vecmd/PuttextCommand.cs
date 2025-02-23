using System;

namespace tukineko
{
	public class PuttextCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("puttext");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] puttext");
			
			ns.error("puttext");
		}
	}
}
