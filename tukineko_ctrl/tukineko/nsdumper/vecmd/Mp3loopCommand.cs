using System;

namespace tukineko
{
	public class Mp3loopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "mp3loop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] mp3loop");
			
			ns.error("mp3loop");
		}
	}
}
