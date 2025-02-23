using System;

namespace tukineko
{
	public class GetiniCommand : FECommand {
		NScripter ns = NScripter.getInstance();		
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "getini");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] getini");
			
			ns.error("getini");
		}
	}
}
