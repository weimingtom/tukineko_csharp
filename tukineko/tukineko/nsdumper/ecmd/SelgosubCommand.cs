using System;

namespace tukineko
{
	public class SelgosubCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "selgosub");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] selgosub");
			
			if (ns.parseArgs(true) % 2 != 0) {
				ns.error("select|selgosub");
			} else {
				int i = ns.getArgSize();
				while (true) {
					for (int j = 0; j < i; j += 2) {
						ns.nd.select.Add(new NsSelect(ns.getArg(j),
								ns.getArg(j + 1), 
								ns.nd.text.getY(), 
								ns.tn.putMess(ns.nd.text, ns.getArg(j), ns.nd.textcolor, false, false), 
								false));
					}
					if (!ns.argCont)
						break;
					try {
						String paramString = ns.readLine();
						i = ns.parseArgs(false);
					} catch (IOException) {
					
					}
				}
				if (!ns.nd.fadeFlag)
					ns.tn.paintB();
				else {
					ns.tn.paintF();
				}
				ns.selectWait();
			}		
		}
	}
}
