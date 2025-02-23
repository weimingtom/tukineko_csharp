using System;

namespace tukineko
{
	public class NsaInputStream : InputStream {
		private NsaEntry ne;
		private RandomAccessFile raf;
		private int position;
		private int length;

		public NsaInputStream(RandomAccessFile raf, NsaEntry ne) {
			this.raf = raf;
			this.ne = ne;
			this.raf.seek(this.ne.offset);
			this.position = 0;
			this.length = this.ne.length;
		}

		//@Override
		public override void close() {
			this.position = this.length;
		}

		//@Override
		public override int read() {
			if (this.ne.type != 0) {
				throw new IOException("Not support no-raw type nsa entry.");
			}
			if (this.position < this.length) {
				this.position += 1;
				return this.raf.read();
			}
			return -1;
		}

		//@Override
		public override int read(byte[] bytes) {
			return read(bytes, 0, bytes.Length);
		}

		//@Override
		public override int read(byte[] bytes, int offset, int len) {
			if (this.ne.type != 0) {
				throw new IOException("Not support no-raw type nsa entry.");
			}
			if (this.position < this.length) {
				int i;
				if (this.position + len <= this.length)
					i = len;
				else {
					i = this.length - this.position;
				}
				this.position += i;
				return this.raf.read(bytes, offset, i);
			}
			return -1;
		}

		//@Override
		public override long skip(long len) {
			if (this.ne.type != 0) {
				throw new IOException("Not support no-raw type nsa entry.");
			}
			if (this.position < this.length) {
				int i;
				if (this.position + (int) len <= this.length)
					i = (int) len;
				else {
					i = this.length - this.position;
				}
				this.position += i;
				return this.raf.skipBytes(i);
			}
			return -1L;
		}
	}
}
