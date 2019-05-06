using System;
using CoreGraphics;
using UIKit;

namespace OfficeUIFabricDemos {
	public static class MyUIViewExtensions {
		public static void FitIntoSuperview (this UIView sv, bool usingConstraints = false, bool usingLeadingTrailing = true, UIEdgeInsets margins = default (UIEdgeInsets), bool autoWidth = false, bool autoHeight = false)
		{
			if (margins == default (UIEdgeInsets))
				margins = UIEdgeInsets.Zero;
			if (sv == null || sv.Superview == null)
				return;
			var superview = sv.Superview;

			if (usingConstraints) {
				sv.TranslatesAutoresizingMaskIntoConstraints = false;
				if (usingLeadingTrailing)
					sv.LeadingAnchor.ConstraintEqualTo (superview.LeadingAnchor, margins.Left).Active = true;
				else
					sv.LeftAnchor.ConstraintEqualTo (superview.LeftAnchor, margins.Left).Active = true;
				if (autoWidth) {
					if (usingLeadingTrailing)
						sv.TrailingAnchor.ConstraintEqualTo (superview.TrailingAnchor, -margins.Right).Active = true;
					else
						sv.RightAnchor.ConstraintEqualTo (superview.RightAnchor, -margins.Right).Active = true;
				} else
					sv.WidthAnchor.ConstraintEqualTo (superview.WidthAnchor, -(margins.Left + margins.Right)).Active = true;
				sv.TopAnchor.ConstraintEqualTo (superview.TopAnchor, margins.Top).Active = true;
				if (autoHeight)
					sv.BottomAnchor.ConstraintEqualTo (superview.BottomAnchor, -margins.Bottom).Active = true;
				else
					sv.HeightAnchor.ConstraintEqualTo (superview.HeightAnchor, -(margins.Top + margins.Bottom));
			} else {
				sv.TranslatesAutoresizingMaskIntoConstraints = true;
				sv.Frame = margins.InsetRect (superview.Bounds);
				sv.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			}
		}
	}
}
