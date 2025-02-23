/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 1:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading;

namespace tukineko
{
	/// <summary>
	/// Description of Thread_.
	/// </summary>
	public class Thread_
	{
		public Thread_()
		{
		}
		
		public Thread_(String name)
		{
			this.name = name;
		}
		
		String name = null;
		Thread thread1 = null;
		public void start()
		{
			thread1 = new Thread(new ThreadStart(Thread1));
 			thread1.Name = name;
			thread1.Start();
		}
		
		public void Thread1()
		{
			this.run();
		}
		
		public virtual void run()
		{
			
		}
		
		public void join() 
		{
			if (thread1 != null)
			{
				thread1.Join();
			}
		}
	}
}
