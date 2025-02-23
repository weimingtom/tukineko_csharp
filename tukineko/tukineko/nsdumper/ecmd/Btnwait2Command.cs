using System;

namespace tukineko
{
	public class Btnwait2Command : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "btnwait2");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] btnwait2");
			
			ns.error("btnwait2");
		}
	}
}
