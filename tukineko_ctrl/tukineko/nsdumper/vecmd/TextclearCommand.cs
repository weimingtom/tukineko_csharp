using System;

namespace tukineko
{
	public class TextclearCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("textclear");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] textclear");
			
			ns.error("textclear");
		}
	}
}
