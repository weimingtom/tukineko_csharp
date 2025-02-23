using System;

namespace tukineko
{
	public class PlayCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "play");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] play");
			
			// FIMXE:
			Console.Error.WriteLine("not implement: play");
			//ns.error("play");
			//		
		}
	}
}
