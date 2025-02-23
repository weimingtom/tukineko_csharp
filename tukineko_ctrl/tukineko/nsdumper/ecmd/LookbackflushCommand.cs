using System;

namespace tukineko
{
	public class LookbackflushCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "lookbackflush");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] lookbackflush");
			
			ns.error("lookbackflush");
		}
	}
}
