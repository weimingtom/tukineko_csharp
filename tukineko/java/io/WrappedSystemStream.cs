/*
 * Created by SharpDevelop.
 * User: admin
 * Date: 2025/1/28
 * Time: 8:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace tukineko
{
	/// <summary>
	/// Description of WrappedSystemStream.
	/// </summary>
	public class WrappedSystemStream : Stream
	{
//		public WrappedSystemStream()
//		{
//		}
		
		private InputStream ist;

        private OutputStream ost;

        public WrappedSystemStream(InputStream ist)
        {
            this.ist = ist;
        }

        public WrappedSystemStream(OutputStream ost)
        {
            this.ost = ost;
        }

        public override void Close()
        {
            if (this.ist != null)
            {
                this.ist.close();
            }
            if (this.ost != null)
            {
                this.ost.close();
            }
        }

        public override void Flush()
        {
            this.ost.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int res = this.ist.read(buffer, offset, count);
            return res != -1 ? res : 0;
        }

        public override int ReadByte()
        {
            return this.ist.read();
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            this.ost.write(buffer, offset, count);
        }

        public override void WriteByte(byte value)
        {
            this.ost.write(value);
        }

        public override bool CanRead
        {
            get { return (this.ist != null); }
        }

        public override bool CanSeek
        {
            get { return false; }
        }

        public override bool CanWrite
        {
            get { return (this.ost != null); }
        }

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }
	}
}
