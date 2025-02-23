using System;

namespace tukineko
{
	public class SoundpressplginCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "soundpressplgin");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] soundpressplgin");
			
			ns.error("soundpressplgin");
		}
	}
}
