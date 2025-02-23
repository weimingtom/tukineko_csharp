using System;
using System.Text;

namespace tukineko
{
	public class NsValueStorage {
		public static void save(OutputStream paramOutputStream,
				int[] paramArrayOfInt, String[] paramArrayOfString, int paramInt1,
				int paramInt2) {
			try {
				for (int i = paramInt1; i <= paramInt2; i++) {
					paramOutputStream.write(paramArrayOfInt[i] & 0xFF);
					paramOutputStream.write(paramArrayOfInt[i] >> 8 & 0xFF);
					paramOutputStream.write(paramArrayOfInt[i] >> 16 & 0xFF);
					paramOutputStream.write(paramArrayOfInt[i] >> 24 & 0xFF);
					byte[] arrayOfByte = Encoding.GetEncoding("Shift-JIS"/*"SJIS"*/).GetBytes(paramArrayOfString[i]);
					if (arrayOfByte.Length > 0)
						paramOutputStream.write(arrayOfByte, 0, arrayOfByte.Length);
					paramOutputStream.write(0);
				}
			} catch (IOException) {
				Console.Error.WriteLine("IOException: save");
			}
		}

		public static void load(InputStream paramInputStream,
				int[] paramArrayOfInt, String[] paramArrayOfString, int paramInt1,
				int paramInt2) {
			byte[] arrayOfByte = new byte[1024];
			try {
				for (int i = paramInt1; i <= paramInt2; i++) {
					paramArrayOfInt[i] = paramInputStream.read();
					paramArrayOfInt[i] |= paramInputStream.read() << 8;
					paramArrayOfInt[i] |= paramInputStream.read() << 16;
					paramArrayOfInt[i] |= paramInputStream.read() << 24;
					int j = 0;
					for (; j < 1024; j++) {
						if ((arrayOfByte[j] = (byte) paramInputStream.read()) == 0)
							break;
					}
					if (j == 0) {
						paramArrayOfString[i] = "";
					} else {
						paramArrayOfString[i] = Encoding.GetEncoding("Shift-JIS"/*"SJIS"*/).GetString(arrayOfByte, 0, j);
					}
				}
			} catch (IOException) {
				Console.Error.WriteLine("IOException: load");
			}
		}
	}
}
