using System;

namespace tukineko
{
	public class SpiCommand : SFCommand {
		NScripter ns = NScripter.getInstance();
		
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "spi");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] spi");
			
			// FIXME:
			Console.Error.WriteLine("not implement: spi");
			//ns.error("not implement: spi");
			//		
		}
	}
}
