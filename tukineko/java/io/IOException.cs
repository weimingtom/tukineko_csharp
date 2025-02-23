/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/26
 * Time: 2:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace tukineko
{
	/// <summary>
	/// Description of IOException.
	/// </summary>
	public class IOException : Exception
	{
		public IOException()
		{
		}
		
		public IOException(string str)
			: base(str)
		{
			
		}
	}
}
