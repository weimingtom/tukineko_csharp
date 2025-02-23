using System;

namespace tukineko
{
	public class SaveoffCommand : FECommand {
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "saveoff");
		}
		
		//@Override
		public override void execute() {
			debug("[FECommand] saveoff");
			
			Console.Error.WriteLine("not implement: saveoff");
		}
	}
}
