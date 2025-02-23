using System;

namespace tukineko
{
	public class NotifCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "notif");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] notif");
			
			bool bl = true; // ???
			int j = 1;
			int k = 0;
			int i1 = 0;
			int m = 0;
			ns.parseArgs(true);
			while (true) {
				String str = ns.getArg(k);
				if ("fchk".Equals(str) == true) {
					k++;
					bl = ns.nd.fchk.ContainsKey(ns.nd.evalStr(ns.getArg(k)).ToUpper());
				} else if ("lchk".Equals(str) == true) {
					k++;
					bl = ns.nd.lchk.ContainsKey(ns.getArg(k).Substring(1).ToUpper());
				} else {
					int n;
					if ((n = str.IndexOf(">=")) >= 0) {
						i1 = n + 2;
						m = 0;
					} else if ((n = str.IndexOf("<=")) >= 0) {
						i1 = n + 2;
						m = 1;
					} else if ((n = str.IndexOf("<>")) >= 0) {
						i1 = n + 2;
						m = 2;
					} else if ((n = str.IndexOf("!=")) >= 0) {
						i1 = n + 2;
						m = 2;
					} else if ((n = str.IndexOf("==")) >= 0) {
						i1 = n + 2;
						m = 3;
					} else if ((n = str.IndexOf("=")) >= 0) {
						i1 = n + 1;
						m = 3;
					} else if ((n = str.IndexOf(">")) >= 0) {
						i1 = n + 1;
						m = 4;
					} else if ((n = str.IndexOf("<")) >= 0) {
						i1 = n + 1;
						m = 5;
					}
					if (n < 0) {
						ns.error("if: " + n);
						return;
					}
					int i2 = ns.nd.evalNum(str.Substring(0, n));
					int i3 = ns.nd.evalNum(str.Substring(i1));
					switch (m) {
					case 0:
						bl = i2 >= i3;
						break;
						
					case 1:
						bl = i2 <= i3;
						break;
						
					case 2:
						bl = i2 != i3;
						break;
						
					case 3:
						bl = i2 == i3;
						break;
						
					case 4:
						bl = i2 > i3;
						break;
						
						
					case 5:
						bl = i2 < i3;
						break;
					}
				}
				if (bl) //notif
					j = 0;
				if ((!"&".Equals(ns.getArg(k + 1))) && (!"&&".Equals(ns.getArg(k + 1)))) {
					break;
				}
				k += 2;
			}
			if (j == 1) {
				ns.makeLineRest(k + 1);
			} else {
				ns.lineRest = null;
			}		
		}
	}
}
