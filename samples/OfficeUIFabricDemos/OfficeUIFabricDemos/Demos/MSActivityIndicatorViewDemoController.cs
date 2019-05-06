using System;
using OfficeUIFabric;
using UIKit;

namespace OfficeUIFabricDemos {
	public class MSActivityIndicatorViewDemoController : DemoController {

		public MSActivityIndicatorViewDemoController () => Title = "MSActivityIndicatorView";

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			foreach (var activitySize in Enum.GetValues (typeof (MSActivityIndicatorViewSize))) {
				var activityIndicatorView = new MSActivityIndicatorView ((MSActivityIndicatorViewSize) activitySize);
				activityIndicatorView.StartAnimating ();
				AddRow (activitySize.ToString (), new [] { activityIndicatorView });
			}
		}
	}
}
