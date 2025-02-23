using System;

namespace tukineko
{
	public class JumpfCommand : FECommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "jumpf");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] jumpf");
			
			ns.lineRest = null;
			while (true) {
				try {
					String paramString = ns.readLine();
					if (paramString.StartsWith("~") == true) {
						break;
					}
					continue;
				} catch (IOException) {

				}
				ns.error("jumpf");
			}
			try {
				ns.nd.jumpBack = ns.getFilePointer();
			} catch (Exception) {

			}		
		}
	}
}
