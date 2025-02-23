using System;

namespace tukineko
{
	public class ResetCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "reset");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] reset");
			
			//FIXME:add null check
			if (ns == null) 
			{
				debug("[ECommand] reset ns == null");
				return;
			}
			
			ns.error("reset");
		}
	}
}
