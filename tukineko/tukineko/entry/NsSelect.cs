using System;

namespace tukineko
{
	public class NsSelect {
		//private const long serialVersionUID = 1L;

		public String message;
		public String label;
		public int y;
		public int height;
		public bool subrutine;
		public bool selected;

		public NsSelect(String message, String label, int y, int height,
				bool subrutine) {
			this.message = message;
			this.label = label;
			this.y = y;
			this.height = height;
			this.subrutine = subrutine;
			this.selected = false;
		}

		public NsSelect(String message, String label, int y, int height,
				bool subrutine, bool selected) {
			this.message = message;
			this.label = label;
			this.y = y;
			this.height = height;
			this.subrutine = subrutine;
			this.selected = selected;
		}
	}
}
