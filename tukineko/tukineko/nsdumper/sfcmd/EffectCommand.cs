using System;

namespace tukineko
{
	public class EffectCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "effect");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] effect");
			
			switch (ns.parseArgs(true)) {
			case 2:
				ns.nd.effect.Add(
						Convert.ToString(ns.nd.evalNum(ns.getArg(0))),
						new NsEffect(ns.nd.evalNum(ns.getArg(1))));
				break;

			case 3:
				ns.nd.effect.Add(
						Convert.ToString(ns.nd.evalNum(ns.getArg(0))),
						new NsEffect(ns.nd.evalNum(ns.getArg(1)), 
								ns.nd.evalNum(ns.getArg(2))));
				break;

			case 4:
				ns.nd.effect.Add(
						Convert.ToString(ns.nd.evalNum(ns.getArg(0))),
						new NsEffect(ns.nd.evalNum(ns.getArg(1)),
								ns.nd.evalNum(ns.getArg(2)), 
								ns.nd.evalStr(ns.getArg(3))));
				break;

			default:
				ns.error("effect");
				break;
			}		
		}
	}
}
