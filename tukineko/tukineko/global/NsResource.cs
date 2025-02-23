using System;
using System.Collections.Generic;

namespace tukineko
{
	public class NsResource {
		private static MediaTracker mt;
		private static SarFile sar;
		private static NsaFile nsa;
		private static Dictionary<String, int> log;

		public static void initLog(Dictionary<String, int> logtable) {
			log = logtable;
		}

		public static void initSar(String filename, Component comp) {
			mt = new MediaTracker(comp);
			try {
				sar = new SarFile(filename);
				nsa = null;
			} catch (IOException) {
				Console.Error.WriteLine("resource: " + filename);
			}
		}

		public static void initNsa(String filename, Component comp) {
			mt = new MediaTracker(comp);
			try {
				sar = null;
				nsa = new NsaFile(filename);
			} catch (IOException) {
				Console.Error.WriteLine("resource: " + filename);
			}
		}

		public static byte[] read(String key) {
			byte[] bytes = null;
			try {
				int i;
				InputStream istream;
				if (sar != null) {
					SarEntry localSarEntry;
					if ((localSarEntry = sar.getSarEntry(key)) == null) {
						Console.Error.WriteLine("no resource: " + key);
						return null;
					}
					i = localSarEntry.length_();
					bytes = new byte[i];
					istream = sar.getInputStream(localSarEntry);
				} else {
					NsaEntry ne = nsa.getNsaEntry(key);
					if (ne == null) {
						// FIXME:
						// Console.Error.WriteLine("no resource: " + key);
						Console.Error.WriteLine("no resource: " + key);
						//
						return null;
					}
					i = ne.length_();
					bytes = new byte[i];
					istream = nsa.getInputStream(ne);
				}
				istream.read(bytes, 0, i);
				istream.close();
			} catch (IOException) {
				Console.Error.WriteLine("read resource");
			}
			String str = key.ToUpper();
			if (!log.ContainsKey(str)) {
				log.Add(str, 1);
			}
			return bytes;
		}

		public static Image_ readImage(String key) {
			Runtime.getRuntime().runFinalization();
			Runtime.getRuntime().gc();
			int j = 0;
			int i = 0;
			if (key.StartsWith(":") == true)
				if (key.StartsWith(":a;") == true) {
					i = 1;
					j = 3;
				} else if (key.StartsWith(":c;") == true) {
					j = 3;
				} else {
					Console.Error.WriteLine("image: " + key);
					return null;
				}
			byte[] bytes;
			if ((bytes = read(key.Substring(j))) == null) {
				return null;
			}
			Image_ image = Toolkit.getDefaultToolkit().createImage(bytes);
			mt.addImage(image, 0);
			try {
				mt.waitForID(0);
			} catch (Exception) {
				Console.Error.WriteLine("read resource image");
			}
			mt.removeImage(image, 0);
			if (i == 1) {
				return makeAlpha(image);
			}
			return image;
		}

		public static Image_ makeAlpha(Image_ image) {
			int i = image.getWidth(null);
			int j = image.getHeight(null);
			uint[] pix = new uint[i * j];
			try {
				new PixelGrabber(image, 0, 0, i, j, pix, 0, i).grabPixels();
			} catch (InterruptedException) {

			}
			for (int m = 0; m < j; m++) {
				for (int k = 0; k < i >> 1; k++) {
					uint n1 = pix[(k + (i >> 1) + m * i)] & 0xFF;
					uint n2 = 0; //((n1 < 64) ? 255 : 0); //FIXME:???why uint overflow
					if (n1 < 64) {
						n2 = 255;
					} else {
						n2 = 0;
					}
					uint n = n2 << 24;
					pix[(k + m * i)] = (pix[(k + m * i)] & 0xFFFFFF) | n;
				}
			}
			return Toolkit.getDefaultToolkit().createImage(
					new MemoryImageSource(i >> 1, j, pix, 0, i));
		}
	}
}
