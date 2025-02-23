using System;

namespace tukineko
{
	public class DefineresetCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "definereset");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] definereset");
			
			ns.error("definereset");
		}
	}
}
