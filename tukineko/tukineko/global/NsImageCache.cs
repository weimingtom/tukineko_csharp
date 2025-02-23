using System;
using System.Collections.Generic;
using System.IO;

namespace tukineko
{
	public class NsImageCache {
		// FIXME:
		// private const int IMAGE_CACHE_MAX = 4;

		private static List<NsImage> cache;
		private static MediaTracker mt;

		public static void init(Component comp) {
			cache = new List<NsImage>();
			mt = new MediaTracker(comp);
		}

		public static bool set(String name) {
			NsImage img = new NsImage(name);
			FileInfo file = new FileInfo(name);
			if (file.Exists == true) {
				img.image = Toolkit.getDefaultToolkit().createImage(name);
				mt.addImage(img.image, 0);
				try {
					mt.waitForID(0);
				} catch (Exception) {
					Console.Error.WriteLine("read direct image");
				}
				mt.removeImage(img.image, 0);
			} else {
				img.image = null;
			}
			cache.Add(img);
			return img.image != null;
		}

		public static Image_ get(String name) {
			NsImage img = new NsImage(name);
			int i = cache.IndexOf(img);
			if (i >= 0) {
				img = cache[i];
				cache.RemoveAt(i);
			} else {
				if (cache.Count >= 4) {
					cache.RemoveAt(0);
				}
				img.setImage(NsResource.readImage(name));
			}
			cache.Add(img);
			return img.getImage();
		}
	}
}
