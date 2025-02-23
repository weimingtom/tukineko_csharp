using System;

namespace tukineko
{
	public class LookbackbuttonCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "lookbackbutton");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] lookbackbutton");
			
			// FIXME:
			 Console.Error.WriteLine("not implement: lookbackbutton");
			//ns.error("not implement: lookbackbutton");
			//
		}
	}
}
