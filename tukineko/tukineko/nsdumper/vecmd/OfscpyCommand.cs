using System;

namespace tukineko
{
	public class OfscpyCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "ofscpy");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] ofscpy");
			
			ns.setMsRest();
			Console.Error.WriteLine("not implement: cfscpy");		
		}
	}
}
