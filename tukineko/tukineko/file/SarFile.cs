using System;
using System.Collections.Generic;
using System.Text;

namespace tukineko
{
	public class SarFile {
		private RandomAccessFile raf;
		private int num;
		private int top;
		private Dictionary<String, SarEntry> entry;

		public static void main(String[] args) {
			try {
				SarFile file = new SarFile("arc.sar");
				IEnumerable<SarEntry> entries = file.entries();
				Console.WriteLine("size:" + file.size());
				foreach (SarEntry el in entries) {
					Console.WriteLine(el.ToString());
				}
			} catch (IOException) {
				Console.Error.WriteLine("Error: Can' read 'arc.sar' file.");
			}
		}

		private int readByte(RandomAccessFile file) {
			return file.read();
		}

		private int readWord(RandomAccessFile file) {
			int i = readByte(file) << 8;
			return i | readByte(file);
		}

		private int readLong(RandomAccessFile file) {
			int i = readByte(file) << 24;
			i |= readByte(file) << 16;
			i |= readByte(file) << 8;
			return i | readByte(file);
		}

		private String readString(RandomAccessFile file) {
			StringBuilder sb = new StringBuilder();
			char c;
			while ((c = (char) file.read()) != 0) {
				sb.Append(c);
			}
			return sb.ToString();
		}

		public SarFile(String filename) {
			this.entry = new Dictionary<String, SarEntry>();
			this.raf = new RandomAccessFile(filename, "r");
			this.num = readWord(this.raf);
			this.top = readLong(this.raf);
			for (int k = 0; k < this.num; k++) {
				String str = readString(this.raf);
				int i = readLong(this.raf) + this.top;
				int j = readLong(this.raf);
				this.entry.Add(str, new SarEntry(str, i, j));
			}
		}

		public int size() {
			return this.entry.Count;
		}

		public IEnumerable<SarEntry> entries() {
			return this.entry.Values;
		}

		public SarEntry getSarEntry(String key) {
			return this.entry[key];
		}

		public SarInputStream getInputStream(SarEntry se) {
			return new SarInputStream(this.raf, se);
		}
	}
}
