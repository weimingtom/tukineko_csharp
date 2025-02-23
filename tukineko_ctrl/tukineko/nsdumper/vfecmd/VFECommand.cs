using System;
using System.Diagnostics;

namespace tukineko
{
	public class VFECommand {
		protected bool checkCommand(String paramString1, String paramString2) {
			if (paramString1.Equals(paramString2)) {
				return true;
			}
			if (paramString1.Length > paramString2.Length &&
				paramString1.StartsWith(paramString2) &&
				(" \t".IndexOf(paramString1[paramString2.Length]) != -1)) {
				return true;
			}
			return false;
		}
		
		public virtual bool check(String str) {
			return false;
		}
		
		public virtual void execute() {
			
		}
		
		protected void debug(String str) {
			Console.WriteLine(str);
			Debug.WriteLine(str);
		}
	}
}
