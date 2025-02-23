using System;

namespace tukineko
{
	public class VersionstrCommand : SFCommand {
		//@Override
		public override bool check(String str) {
			return checkCommand(str, "versionstr");
		}
		
		//@Override
		public override void execute() {
			debug("[SFCommand] versionstr");
			
			Console.Error.WriteLine("not implement: versionstr");
		}
	}
}
