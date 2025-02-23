using System;

namespace tukineko
{
	public class PlaystopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("playstop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] playstop");
			
			ns.setMsRest();
			//
			// FIXME:
			Console.Error.WriteLine("not implement: playstop");
			//ns.error("playstop");
			//		
		}
	}
}
