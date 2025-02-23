using System;

namespace tukineko
{
	public class LoadgameCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "loadgame");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] loadgame");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("loadgame");
			} else {
				ns.storageState = 2;
				ns.loadLocalData("SAVE" + ns.nd.evalNum(ns.getArg(0)) + ".DAT");
				ns.makeLineRest(1);
			}		
		}
	}
}
