using System;

namespace tukineko
{
	public class NsShell {
		//private const long serialVersionUID = 1L;

		public String image;
		public int effect;
		public int width;
		public int height;

		public NsShell(String image, int effect, int width, int height) {
			this.image = image;
			this.effect = effect;
			this.width = width;
			this.height = height;
		}
	}
}
