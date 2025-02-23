using System;

namespace tukineko
{
	public class JumpbCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "jumpb");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] jumpb");
			
			try {
				ns.setFilePointer(ns.nd.jumpBack);
			} catch (Exception) {

			}
			ns.nd.historyPos = 0;
			ns.nd.historyCount = 0;
			ns.lineRest = null;		
		}
	}
}
