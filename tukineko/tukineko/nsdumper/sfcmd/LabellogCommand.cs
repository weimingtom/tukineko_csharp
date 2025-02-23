using System;
using System.IO;

namespace tukineko
{
	public class LabellogCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "labellog");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] labellog");
			
			ns.setMsRest();
			ns.nd.labellog = true;
			FileInfo localFile = new FileInfo(ns.path + "NSCRLLOG.DAT");
			if (localFile.Exists == true) {
				NScripter.loadLogData(ns.path + "NSCRLLOG.DAT", ns.nd.lchk);
			}		
		}
	}
}