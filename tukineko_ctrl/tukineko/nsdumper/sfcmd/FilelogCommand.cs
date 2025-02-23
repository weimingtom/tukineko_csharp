using System;
using System.IO;

namespace tukineko
{
	public class FilelogCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "filelog");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] filelog");
			
			ns.setMsRest();
			ns.nd.filelog = true;
			FileInfo localFile = new FileInfo(ns.path + "NSCRFLOG.DAT");
			if (localFile.Exists == true) {
				NScripter.loadLogData(ns.path + "NSCRFLOG.DAT", ns.nd.fchk);
			}		
		}
	}
}
