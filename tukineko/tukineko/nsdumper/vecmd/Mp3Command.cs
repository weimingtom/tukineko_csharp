using System;

namespace tukineko
{
	public class Mp3Command : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("mp3");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] mp3");
			
			ns.error("mp3");
		}
	}
}
