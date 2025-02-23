using System;

namespace tukineko
{
	public class DivCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "div");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] div");
			
			ns.error("div");
		}
	}
}
