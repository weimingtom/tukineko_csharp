using System;

namespace tukineko
{
	public class ArcCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "arc");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] arc");
			
			ns.tn.initSar(ns.path + "ARC.SAR");
		}
	}
}
