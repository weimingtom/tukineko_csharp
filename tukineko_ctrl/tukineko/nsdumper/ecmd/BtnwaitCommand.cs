using System;
using System.Threading;

namespace tukineko
{
	public class BtnwaitCommand : ECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "btnwait");
		}
		
		//@Override
		public override void execute() {
			debug("[ECommand] btnwait");

			if (ns.parseArgs(true) < 1) {
				ns.error("btnwait");
			} else if (ns.nd.btn.Count == 0) {
				ns.nd.click = false;
				do {
					try {
						Thread.Sleep(100);
					} catch (Exception) {
					}
					if (ns.nd.click) {
						break;
					}
				} while (ns.storageState == 0);
			} else {
				ns.nd.btnVisible = true;
				ns.nd.click = false;
				int k = -1;
				NsButton localNsButton;
				while (ns.storageState == 0) {
					if (ns.nd.click == true) {
						ns.nd.click = false;
						k = -1;
						for (int j = 0; j < ns.nd.btn.Count; j++) {
							localNsButton = ns.nd.btn[j];
							if ((localNsButton.x > ns.nd.clickX) || 
								(ns.nd.clickX >= localNsButton.x + localNsButton.width) || 
								(localNsButton.y > ns.nd.clickY) || 
								(ns.nd.clickY >= localNsButton.y + localNsButton.height)) {
								continue;
							}
							k = j;
							break;
						}
						if (ns.nd.btnSel != k) {
							ns.nd.btnSel = k;
						} else {
							if (ns.nd.btnSel >= 0) {
								break;
							}
						}
						ns.tn.paintB();
					}
					try {
						Thread.Sleep(100);
					} catch (Exception) {

					}
				}
				if (!ns.getArg(0).StartsWith("%")) {
					ns.error("btnwait");
				} else if (k >= 0) {
					localNsButton = ns.nd.btn[k];
					ns.nd.valueNum[ns.nd.evalNum(ns.getArg(0).Substring(1))] = localNsButton.no;
				}
				ns.nd.btnVisible = false;
				ns.makeLineRest(1);
			}
		}
	}
}
