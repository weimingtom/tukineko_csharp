using System;

namespace tukineko
{
	public class CaptionCommand : SFECommand {
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "caption");
		}
		
		//@Override
		public override void execute() {
			debug("[SFECommand] caption");
			
			Console.Error.WriteLine("not implement: caption");
		}
	}
}
