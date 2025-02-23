using System;

namespace tukineko
{
	public class BrCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("br");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] br");
			
			ns.setMsRest();
			ns.tn.putMess(ns.nd.text, "", ns.nd.textcolor, true, false);
			if (!ns.nd.fadeFlag) {
				ns.tn.paintB();
			} else {
				ns.tn.paintF();
			}		
		}
	}
}