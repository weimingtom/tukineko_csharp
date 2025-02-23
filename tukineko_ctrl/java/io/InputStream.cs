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
	/// Description of InputStream.
	/// https://github.com/cping/LGame/blob/master/C%23/Loon2MonoGame/LoonMonoGame-Lib/java/io/InputStream.cs
	/// </summary>
	public class InputStream : IDisposable
	{
        private long mark_;

        protected Stream Wrapped;

        public Stream Stream
        {
            get
            {
                return Wrapped;
            }
        }

        public static implicit operator InputStream(Stream s)
        {
            return Wrap(s);
        }

        public static implicit operator Stream(InputStream s)
        {
            return s.GetWrappedStream();
        }

        public virtual int available()
        {
            return (int)Wrapped.Length;
        }

        public virtual void close()
        {
            if (Wrapped != null)
            {
                Wrapped.Close();
            }
        }

        public void Dispose()
        {
            close();
        }

        internal Stream GetWrappedStream()
        {
            if (Wrapped != null)
            {
                return Wrapped;
            }
            return new WrappedSystemStream(this);
        }

        public virtual void mark(int readlimit)
        {
            if (Wrapped != null)
            {
                this.mark_ = Wrapped.Position;
            }
        }

        public virtual bool markSupported()
        {
            return ((Wrapped != null) && Wrapped.CanSeek);
        }

        public virtual int read()
        {
            if (Wrapped == null)
            {
                throw new NotImplementedException();
            }

            return Wrapped.ReadByte();
        }

        public virtual int read(byte[] buf)
        {
            return read(buf, 0, buf.Length);
        }

        public virtual int read(byte[] b, int off, int len)
        {
            if (Wrapped != null)
            {
                int num = Wrapped.Read(b, off, len);
                return ((num <= 0) ? -1 : num);
            }
            int totalRead = 0;
            while (totalRead < len)
            {
                int nr = read();
                if (nr == -1)
                    return -1;
                b[off + totalRead] = (byte)nr;
                totalRead++;
            }
            return totalRead;
        }

        public virtual void reset()
        {
            if (Wrapped == null)
            {
                throw new IOException();
            }
            Wrapped.Position = mark_;
        }

        public virtual long skip(long cnt)
        {
            long n = cnt;
            while (n > 0)
            {
                if (read() == -1)
                    return cnt - n;
                n--;
            }
            return cnt - n;
        }

        static internal InputStream Wrap(Stream s)
        {
            InputStream stream = new InputStream
            {
                Wrapped = s
            };
            return stream;
        }
		
       	
//		public virtual int read()
//		{
//			return 0;
//		}
//		
//		public virtual int read(byte[] bytes, int offset, int len)
//		{
//			return 0;
//		}
//		
//		public virtual void close()
//		{
//			
//		}
	}
}
