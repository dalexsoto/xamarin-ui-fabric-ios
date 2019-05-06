using System;
using OfficeUIFabric;
using UIKit;

namespace OfficeUIFabricDemos {
	public class MSLabelDemoController : DemoController {

		public MSLabelDemoController () => Title = "MSLabel";

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			AddRow (new MSLabel (MSTextStyle.Headline, MSTextColorStyle.Regular) {
				Text = "Text Styles",
				TextAlignment = UITextAlignment.Center
			});

			foreach (MSTextStyle style in Enum.GetValues (typeof (MSTextStyle))) {
				var label = GetLabel (style, MSTextColorStyle.Regular);
				label.Text = $"Style: {style} Size: {label.Font.PointSize}pt";
				AddRow (label);
			}

			AddRow (new UIView ());

			AddRow (new MSLabel (MSTextStyle.Headline, MSTextColorStyle.Regular) {
				Text = "Text Color Styles",
				TextAlignment = UITextAlignment.Center
			});

			foreach (MSTextColorStyle color in Enum.GetValues (typeof (MSTextColorStyle))) {
				var label = GetLabel (MSTextStyle.Body, color);
				label.Text = color.ToString ();
				AddRow (label);
			}
		}

		MSLabel GetLabel (MSTextStyle style, MSTextColorStyle colorStyle)
		{
			var label = new MSLabel (style, colorStyle);
			if (colorStyle == MSTextColorStyle.White)
				label.BackgroundColor = MSColors.Black;
			label.WidthAnchor.ConstraintEqualTo (300).Active = true;
			return label;
		}
	}
}
