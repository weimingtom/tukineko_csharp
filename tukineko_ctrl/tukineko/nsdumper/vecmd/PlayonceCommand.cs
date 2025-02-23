using System;

namespace tukineko
{
	public class PlayonceCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("playonce");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] playonce");
			
			ns.error("playonce");
		}
	}
}
