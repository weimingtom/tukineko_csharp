/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 2:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace tukineko
{
	/// <summary>
	/// Description of Runtime.
	/// </summary>
	public class Runtime
	{
		private static Runtime instance = new Runtime();
		
		private Runtime()
		{
		}
		
		public static Runtime getRuntime()
		{
			return instance;
		}
		
		public long freeMemory()
		{
			//return Convert.ToUInt32(MemoryManager.AppMemoryUsageLimit - MemoryManager.AppMemoryUsage);
			return GC.GetTotalMemory(true);
//			return 0x10000000;
		}
		
		public long totalMemory()
		{
			//MemoryManager.AppMemoryUsageLimit
			//return GC.GetTotalMemory(false);
			//return MemoryManager.AppMemoryUsageLimit;
			return 4L * 1024L * 1024L * 1024L;
		}
		
		public void runFinalization()
		{
			//skip
			GC.WaitForPendingFinalizers();
		}
		
		public void gc()
		{
			GC.Collect();
		}
	}
}
