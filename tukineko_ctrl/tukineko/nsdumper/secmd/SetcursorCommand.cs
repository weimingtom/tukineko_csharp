using System;

namespace tukineko
{
	public class SetcursorCommand : SECommand {
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "setcursor");
		}
		
		//@Override
		public override void execute() {
			debug("[SECommand] setcursor");
			
			Console.Error.WriteLine("not implement: setcursor");
		}
	}
}
