using System;

namespace tukineko
{
	public class AbssetcursorCommand : SECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("abssetcursor");
		}
		
		//@Override
		public override void execute() {
			debug("[SECommand] abssetcursor");
			
			ns.error("abssetcursor");
		}
	}
}
