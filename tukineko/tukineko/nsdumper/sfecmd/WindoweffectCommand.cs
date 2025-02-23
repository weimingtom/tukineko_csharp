using System;

namespace tukineko
{
	public class WindoweffectCommand : SFECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "windoweffect");
		}
		
		//@Override
		public override void execute() {
			debug("[SFECommand] windoweffect");
			
			//FIXME: put/Add -> set
			switch (ns.parseArgs(true)) {
			case 1:
				ns.nd.effect["window"] = 
						new NsEffect(ns.nd.evalNum(ns.getArg(0)));
				break;

			case 2:
				ns.nd.effect["window"] = 
						new NsEffect(ns.nd.evalNum(ns.getArg(0)), ns.nd.evalNum(ns.getArg(1)));
				break;

			case 3:
				ns.nd.effect["window"] = 
						new NsEffect(ns.nd.evalNum(ns.getArg(0)), ns.nd.evalNum(ns.getArg(1)), ns.nd.evalStr(ns.getArg(2)));
				break;

			default:
				ns.error("windoweffect");
				break;
			}		
		}
	}
}
