using System;

namespace tukineko
{
	public class SavegameCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "savegame");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] savegame");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("savegame");
			} else {
				ns.storageState = 1;
				ns.saveLocalData("SAVE" + ns.nd.evalNum(ns.getArg(0)) + ".DAT");
				ns.makeLineRest(1);
			}		
		}
	}
}
