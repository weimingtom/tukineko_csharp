using System;

namespace tukineko
{
	public class GameCommand : FCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("game");
		}
		
		//@Override
		public override void execute() {
			debug("[FCommand] game");
			
			//FIXME:add null check
			if (ns == null) 
			{
				debug("[FCommand] game ns == null");
				return;
			}
			
			ns.setMsRest();
			ns.tn.makemenu(ns.nd.savenumber, ns.path, ns.nd.savenameTitle);
				
			try {
				ns.gotoLabel("*start");
			} catch (Exception) {
				ns.error("game");
			}		
		}
	}
}
