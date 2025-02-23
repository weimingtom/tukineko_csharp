using System;

namespace tukineko
{
	public class BtndefCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "btndef");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] btndef");
			
			if (ns.parseArgs(true) < 1) {
				ns.error("btndef");
			} else {
				ns.nd.btnImage = ns.nd.evalStr(ns.getArg(0));
				ns.nd.btnSel = -1;
				ns.nd.btn.Clear();
				ns.makeLineRest(1);
			}
		}
	}
}
