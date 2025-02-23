using System;

namespace tukineko
{
	public class WaveloopCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("waveloop");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] waveloop");
			
			ns.error("waveloop");
		}
	}
}
