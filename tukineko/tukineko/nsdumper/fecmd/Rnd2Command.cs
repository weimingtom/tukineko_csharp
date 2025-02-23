using System;

namespace tukineko
{
	public class Rnd2Command : FECommand {
		NScripter ns = NScripter.getInstance();	
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "rnd2");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] rnd2");
			
			ns.error("rnd2");
		}
	}
}
