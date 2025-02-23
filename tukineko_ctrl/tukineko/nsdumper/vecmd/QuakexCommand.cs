using System;
using System.Threading;

namespace tukineko
{
	public class QuakexCommand : VECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return str.StartsWith("quakex");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] quakex");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("quakex");
			} else {
				for (int i = 0; i < ns.nd.evalNum(ns.getArg(0)); i++) {
					ns.nd.quakex += 1;
					ns.tn.paintB();
					try {
						Thread.Sleep(ns.nd.evalNum(ns.getArg(1)));
					} catch (Exception) {
						
					}
				}
				ns.nd.quakex = 0;
				ns.tn.paintB();
				ns.makeLineRest(2);
			}		
		}
	}
}
