using System;

namespace tukineko
{
	public class MesboxCommand : VFECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "mesbox");
		}
		
		//@Override
		public override void execute() {
			debug("[VFECommand] mesbox");
			
			ns.error("mesbox");
		}
	}
}
