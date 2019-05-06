using System;
using MonoTouch.Dialog;
using UIKit;

namespace OfficeUIFabricDemos {
	public class DvcMenu : DialogViewController {
		public DvcMenu () : base (UITableViewStyle.Grouped, null)
		{
			Root = new RootElement ("OfficeUIFabric Demos") {
				new Section {
					new StringElement ("MSActivityIndicatorView", () => {
						var dc = new MSActivityIndicatorViewDemoController ();
						NavigationController.PushViewController (dc, true);
					}),
					new StringElement ("MSLabel", () => {
						var dc = new MSLabelDemoController ();
						NavigationController.PushViewController (dc, true);
					})
				}
			};
		}
	}
}
