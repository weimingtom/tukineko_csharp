using System;

namespace tukineko
{
	public class NsImage {
		public String name;
		public Image_ image;

		public NsImage(String name) {
			this.name = name;
			this.image = null;
		}

		public void setImage(Image_ image) {
			this.image = image;
		}

		public Image_ getImage() {
			return this.image;
		}

		//@Override
		public override bool Equals(Object obj) {
			return this.name.Equals(((NsImage) obj).name);
		}
		public override int GetHashCode()
	    {
			return (name != null ? name.GetHashCode() : 0) ^ 
				(image != null ? image.GetHashCode() : 0);
	    }
	}
}
