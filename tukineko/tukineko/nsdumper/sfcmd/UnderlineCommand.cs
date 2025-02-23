using System;

namespace tukineko
{
	public class UnderlineCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "underline");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] underline");
			
			ns.error("underline");
		}
	}
}
