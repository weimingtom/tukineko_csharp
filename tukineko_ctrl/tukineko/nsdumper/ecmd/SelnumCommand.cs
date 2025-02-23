using System;

namespace tukineko
{
	public class SelnumCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "selnum");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] selnum");
			
			if (ns.parseArgs(true) < 2) {
				ns.error("selnum");
			} else {
				if (!ns.getArg(0).StartsWith("%")) {
					ns.error("selnum");
					return;
				}
				ns.nd.selnum = ns.nd.evalNum(ns.getArg(0).Substring(1));
				int i = ns.getArgSize();
				int m = 0;
				while (true) {
					for (int j = m == 0 ? 1 : 0; j < i; j++) {
						ns.nd.select.Add(new NsSelect(
								ns.getArg(j),
								Convert.ToString(m++),
								ns.nd.text.getY(),
								ns.tn.putMess(ns.nd.text, ns.getArg(j), ns.nd.textcolor, false, false),
								false));
					}
					if (!ns.argCont) {
						break;
					}
					try {
						String paramString = ns.readLine();
						i = ns.parseArgs(false);
					} catch (IOException) {
					}
				}
				if (!ns.nd.fadeFlag) {
					ns.tn.paintB();
				} else {
					ns.tn.paintF();
				}
				ns.selectWait();
			}		
		}
	}
}

