using System;

namespace tukineko
{
	public class NsaCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "nsa");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] nsa");
			
			ns.tn.initNsa(ns.path + "ARC.NSA");
		}
	}
}
