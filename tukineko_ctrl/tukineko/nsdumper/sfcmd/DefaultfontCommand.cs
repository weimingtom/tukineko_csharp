using System;

namespace tukineko
{
	public class DefaultfontCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "defaultfont");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] defaultfont");
			
			ns.error("defaultfont");
		}
	}
}
