using System;

namespace tukineko
{
	public class TalCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("tal");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] tal");
			
			ns.error("tal");
		}
	}
}
