using System;

namespace tukineko
{
	public class WaveCommand : VECommand {
		//@Override
		public override bool check(String str) {
			return str.StartsWith("wave");
		}
		
		//@Override
		public override void execute() {
			debug("[VECommand] wave");
			
			Console.Error.WriteLine("not implement: wave");
		}
	}
}
