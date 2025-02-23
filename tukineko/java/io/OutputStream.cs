/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/25
 * Time: 5:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace tukineko
{
	/// <summary>
	/// Description of OutputStream.
	/// https://github.com/cping/LGame/blob/master/C%23/Loon2MonoGame/LoonMonoGame-Lib/java/io/OutputStream.cs
	/// </summary>
	public class OutputStream
	{
		public Stream Stream
        {
            get
            {
                return Wrapped;
            }
        }

        protected Stream Wrapped;

        public static implicit operator OutputStream(Stream s)
        {
            return Wrap(s);
        }

        public static implicit operator Stream(OutputStream s)
        {
            return s.GetWrappedStream();
        }

        public virtual void close()
        {
            if (this.Wrapped != null)
            {
                this.Wrapped.Close();
            }
        }

        public void Dispose()
        {
            this.close();
        }

        public virtual void Flush()
        {
            if (this.Wrapped != null)
            {
                this.Wrapped.Flush();
            }
        }

        internal Stream GetWrappedStream()
        {
            if (this.Wrapped != null)
            {
                return this.Wrapped;
            }
            return new WrappedSystemStream(this);
        }

        static internal OutputStream Wrap(Stream s)
        {
            OutputStream stream = new OutputStream();
            stream.Wrapped = s;
            return stream;
        }

        public virtual void write(int b)
        {
            if (this.Wrapped == null)
            {
                throw new NotImplementedException();
            }
            this.Wrapped.WriteByte((byte)b);
        }

        public virtual void write(byte[] b)
        {
            this.write(b, 0, b.Length);
        }

        public virtual void write(byte[] b, int offset, int len)
        {
            if (this.Wrapped != null)
            {
                this.Wrapped.Write(b, offset, len);
            }
            else
            {
                for (int i = 0; i < len; i++)
                {
                    this.write(b[i + offset]);
                }
            }
        }
		
//		public OutputStream()
//		{
//		}
//		
//		public void write(int i)
//		{
//			
//		}
//		
//		public void write(byte[] bytes, int offset, int length)
//		{
//			
//		}
	}
}
