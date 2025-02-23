using System;

namespace tukineko
{
	public class ResettimerCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("resettimer");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] resettimer");
			
			ns.setMsRest();
			ns.tn.timerClear();		
		}
	}
}
