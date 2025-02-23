using System;

namespace tukineko
{
	public class MonocroCommand : VECommand {
		//@Override
		public override bool check(String str) {
			return str.StartsWith("monocro");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] monocro");
			
			Console.Error.WriteLine("not implement: monocro");
		}
	}
}
