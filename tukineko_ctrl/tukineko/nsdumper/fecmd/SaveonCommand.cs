using System;

namespace tukineko
{
	public class SaveonCommand : FECommand {
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "saveon");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] saveon");
			
			Console.Error.WriteLine("not implement: saveon");
		}
	}
}
