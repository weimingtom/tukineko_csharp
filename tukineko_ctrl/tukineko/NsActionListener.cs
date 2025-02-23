using System;

namespace tukineko
{
	public class NsActionListener : ActionListener {
		private NScripter ns;
		private NsWindow tn;

		public NsActionListener(NScripter ns, NsWindow tn) {
			this.ns = ns;
			this.tn = tn;
		}

		//@Override
		public void actionPerformed(ActionEvent event_) {
			Object localObject = event_.getSource();
			String str = event_.getActionCommand();
			if (localObject == tn.menuSave) {
				ns.save(str);
				return;
			} else if (localObject == tn.menuLoad) {
				ns.load(str);
				return;
			} else {
				ns.menu3(str);
				return;
			}
		}
	}
}
