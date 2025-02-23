using System;

namespace tukineko
{
	public class ReturnCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("return");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] return");
			
			ns.setMsRest();
			ns.nd.historyPos = 0;
			ns.nd.historyCount = 0;
			ns.nd.gosubPos -= 1;
			try {
				ns.setFilePointer(ns.nd.gosub[ns.nd.gosubPos].retpos);
			} catch (IOException) {
				ns.error("return");
			}
			ns.lineRest = ns.nd.gosub[ns.nd.gosubPos].rest;		
		}
	}
}
