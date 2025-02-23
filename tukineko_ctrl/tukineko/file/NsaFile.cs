using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace tukineko
{
	public class NsaFile {
		private RandomAccessFile raf;
		private int num;
		private int top;
		private Dictionary<String, NsaEntry> entry;

		public static void main(String[] args) {
			try {
				NsaFile localNsaFile = new NsaFile("arc.nsa");
				IEnumerable<NsaEntry> localEnumeration = localNsaFile.entries();
				
				Console.WriteLine("size:" + localNsaFile.size());
				Debug.WriteLine("size:" + localNsaFile.size());
				
				foreach (NsaEntry el in localEnumeration) {
					Console.WriteLine(el.ToString());
					Debug.WriteLine(el.ToString());
				}
			} catch (IOException e) {
				Console.Error.WriteLine("Error: Can' read 'arc.nsa' file.");
				Console.Error.WriteLine(e);
				Debug.WriteLine("Error: Can' read 'arc.nsa' file.");
				Debug.WriteLine(e);
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

		public NsaFile(String filename) {
			this.entry = new Dictionary<String, NsaEntry>();
			this.raf = new RandomAccessFile(filename, "r");
			this.num = readWord(this.raf);
			this.top = readLong(this.raf);
			for (int n = 0; n < this.num; n++) {
				String str = readString(this.raf);
				int k = readByte(this.raf);
				int i = readLong(this.raf) + this.top;
				int j = readLong(this.raf);
				int m = readLong(this.raf);
				this.entry.Add(str, new NsaEntry(str, i, j, k, m));
			}
		}

		public int size() {
			return this.entry.Count;
		}

		public IEnumerable<NsaEntry> entries() {
			return this.entry.Values;
		}

		public NsaEntry getNsaEntry(String key) {
			return this.entry[key];
		}

		public NsaInputStream getInputStream(NsaEntry ne) {
			return new NsaInputStream(this.raf, ne);
		}
	}
}
