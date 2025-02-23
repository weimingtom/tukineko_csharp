using System;

namespace tukineko
{
	public class TextonCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("texton");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] texton");
			
			ns.error("texton");
		}
	}
}
