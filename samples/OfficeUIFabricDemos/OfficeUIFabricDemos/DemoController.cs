using System;
using CoreGraphics;
using Foundation;
using OfficeUIFabric;
using UIKit;

namespace OfficeUIFabricDemos {
	public class DemoController : UIViewController {

		static UIStackView CreateVerticalContainer () => new UIStackView (CGRect.Empty) {
			Axis = UILayoutConstraintAxis.Vertical,
			LayoutMargins = new UIEdgeInsets (16, 16, 16, 16),
			LayoutMarginsRelativeArrangement = true,
			Spacing = 16
		};

		UIStackView container = CreateVerticalContainer ();
		UIScrollView scrollingContainer = new UIScrollView (CGRect.Empty);

		public MSButton CreateButton (string title, EventHandler action)
		{
			var button = new MSButton ();
			button.SetTitle (title, UIControlState.Normal);
			button.AddTarget (action, UIControlEvent.TouchUpInside);
			return button;
		}

		public void AddTitle (string title)
		{
			var titleLabel = new MSLabel (MSTextStyle.Headline, MSTextColorStyle.Regular) {
				Text = title,
				TextAlignment = UITextAlignment.Center
			};
			container.AddArrangedSubview (titleLabel);
		}

		public void AddRow (UIView item) => AddRow (items: new [] { item });

		public void AddRow (string text = null, UIView [] items = null, float itemSpacing = 40)
		{
			var itemsContainer = new UIStackView {
				Axis = UILayoutConstraintAxis.Vertical,
				Alignment = UIStackViewAlignment.Leading
			};

			var itemRow = new UIStackView {
				Axis = UILayoutConstraintAxis.Horizontal,
				Alignment = UIStackViewAlignment.Center,
				Spacing = itemSpacing
			};

			if (text != null) {
				var label = new MSLabel (MSTextStyle.Subhead, MSTextColorStyle.Error) {
					Text = text,
				};
				label.WidthAnchor.ConstraintEqualTo (75).Active = true;
				itemRow.AddArrangedSubview (label);
			}

			foreach (var item in items)
				itemRow.AddArrangedSubview (item);
			itemsContainer.AddArrangedSubview (itemRow);
			container.AddArrangedSubview (itemsContainer);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = MSColors.Background;

			View.AddSubview (scrollingContainer);
			scrollingContainer.FitIntoSuperview ();
			scrollingContainer.AddSubview (container);
			container.FitIntoSuperview (usingConstraints: true, usingLeadingTrailing: false, autoHeight: true);
		}
	}
}