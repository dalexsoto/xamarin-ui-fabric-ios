﻿using System;

using ObjCRuntime;
using Foundation;
using UIKit;
using CoreGraphics;

namespace OfficeUIFabric {

	[BaseType (typeof (UITableViewCell), Name = ApiDefConstants.MSActionsCell)]
	interface MSActionsCell {

		[Export ("action1Button", ArgumentSemantic.Strong)]
		UIButton Action1Button { get; }

		[Export ("action2Button", ArgumentSemantic.Strong)]
		UIButton Action2Button { get; }

		[Export ("initWithStyle:reuseIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (UITableViewCellStyle style, string reuseIdentifier);

		[Export ("setupWithAction1Title:action2Title:action1IsDestructive:action2IsDestructive:")]
		void Setup (string action1Title, [NullAllowed] string action2Title, bool action1IsDestructive, bool action2IsDestructive);
	}

	[BaseType (typeof (UITableViewCell), Name = ApiDefConstants.MSActivityIndicatorCell)]
	interface MSActivityIndicatorCell {

		[Export ("initWithStyle:reuseIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSActivityIndicatorView)]
	interface MSActivityIndicatorView {

		[Export ("isAnimating")]
		bool IsAnimating { get; }

		[Export ("initWithSize:")]
		IntPtr Constructor (MSActivityIndicatorViewSize size);

		[Export ("initWithSideSize:strokeThickness:")]
		[DesignatedInitializer]
		IntPtr Constructor (nfloat sideSize, nfloat strokeThickness);

		[Export ("startAnimating")]
		void StartAnimating ();

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSAvatarView)]
	interface MSAvatarView {

		[Export ("avatarSize", ArgumentSemantic.Assign)]
		MSAvatarSize AvatarSize { get; set; }

		[Export ("avatarBackgroundColor", ArgumentSemantic.Strong)]
		UIColor AvatarBackgroundColor { get; set; }

		[Export ("style", ArgumentSemantic.Assign)]
		MSAvatarStyle Style { get; set; }

		[Export ("initWithAvatarSize:withBorder:style:")]
		[DesignatedInitializer]
		IntPtr Constructor (MSAvatarSize avatarSize, bool hasBorder, MSAvatarStyle style);

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);

		[Export ("setupWithPrimaryText:secondaryText:image:")]
		void Setup ([NullAllowed] string primaryText, [NullAllowed] string secondaryText, [NullAllowed] UIImage image);

		[Export ("setupWithImage:")]
		void Setup (UIImage image);
	}

	interface IMSBadgeFieldDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSBadgeFieldDelegate)]
	interface MSBadgeFieldDelegate {

		[Abstract]
		[Export ("badgeField:badgeDataSourceForText:")]
		MSBadgeViewDataSource GetBadgeDataSource (MSBadgeField badgeField, string forText);

		[Export ("badgeField:willChangeTextFieldContentWithText:")]
		void WillChangeTextFieldContent (MSBadgeField badgeField, string newText);

		[Export ("badgeFieldDidChangeTextFieldContent:isPaste:")]
		void DidChangeTextFieldContent (MSBadgeField badgeField, bool isPaste);

		[Export ("badgeField:shouldBadgeText:forSoftBadgingString:")]
		bool ShouldBadgeText (MSBadgeField badgeField, string text, string badgingString);

		[Export ("badgeField:didAddBadge:")]
		void DidAddBadge (MSBadgeField badgeField, MSBadgeView badge);

		[Export ("badgeField:didDeleteBadge:")]
		void DidDeleteBadge (MSBadgeField badgeField, MSBadgeView badge);

		[Export ("badgeField:shouldAddBadgeForBadgeDataSource:")]
		bool ShouldAddBadge (MSBadgeField badgeField, MSBadgeViewDataSource badgeDataSource);

		[Export ("badgeField:newBadgeForBadgeDataSource:")]
		MSBadgeView GetNewBadge (MSBadgeField badgeField, MSBadgeViewDataSource badgeDataSource);

		[Export ("badgeField:newMoreBadgeForBadgeDataSources:")]
		MSBadgeView GetNewMoreBadge (MSBadgeField badgeField, MSBadgeViewDataSource [] badgeDataSources);

		[Export ("badgeFieldContentHeightDidChange:")]
		void ContentHeightDidChange (MSBadgeField badgeField);

		[Export ("badgeField:didTapSelectedBadge:")]
		void DidTapSelectedBadge (MSBadgeField badgeField, MSBadgeView badge);

		[Export ("badgeField:shouldDragBadge:")]
		bool ShouldDragBadge (MSBadgeField badgeField, MSBadgeView badge);

		[Export ("badgeField:didEndDraggingOriginBadge:toBadgeField:withNewBadge:")]
		void DidEndDraggingOriginBadge (MSBadgeField originbadgeField, MSBadgeView originBadge, [NullAllowed] MSBadgeField destinationBadgeField, [NullAllowed] MSBadgeView newBadge);

		[Export ("badgeFieldShouldBeginEditing:")]
		bool ShouldBeginEditing (MSBadgeField badgeField);

		[Export ("badgeFieldDidBeginEditing:")]
		void DidBeginEditing (MSBadgeField badgeField);

		[Export ("badgeFieldDidEndEditing:")]
		void DidEndEditing (MSBadgeField badgeField);

		[Export ("badgeFieldShouldReturn:")]
		bool ShouldReturn (MSBadgeField badgeField);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSBadgeField)]
	interface MSBadgeField {

		[Export ("numberOfLines")]
		nint NumberOfLines { get; set; }

		[Export ("isEditable")]
		bool IsEditable { get; set; }

		[Export ("isEnabled")]
		bool IsEnabled { get; set; }

		[Export ("badges", ArgumentSemantic.Copy)]
		MSBadgeView [] Badges { get; }

		[Export ("badgeDataSources", ArgumentSemantic.Copy)]
		MSBadgeViewDataSource [] BadgeDataSources { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IMSBadgeFieldDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);

		[Export ("badgeText")]
		void BadgeText ();

		[Export ("addBadgesWithDataSources:")]
		void AddBadges (MSBadgeViewDataSource [] dataSources);

		[Export ("addBadgeWithDataSource:fromUserAction:updateConstrainedBadges:")]
		void AddBadge (MSBadgeViewDataSource dataSource, bool fromUserAction, bool updateConstrainedBadges);

		[Export ("deleteBadgesWithDataSource:")]
		void DeleteBadges (MSBadgeViewDataSource dataSource);

		[Export ("selectBadge:")]
		void SelectBadge (MSBadgeView badge);

		[Export ("textFieldContent")]
		string TextFieldContent { get; }

		[Export ("resetTextFieldContent")]
		void ResetTextFieldContent ();

		[Export ("accessibilityElementCount")]
		nint AccessibilityElementCount { get; }

		[Export ("accessibilityElementAtIndex:")]
		[return: NullAllowed]
		NSObject GetAccessibilityElement (nint index);

		[Export ("indexOfAccessibilityElement:")]
		nint GetIndexOfAccessibilityElement (NSObject element);

		[Export ("voiceOverFocusOnTextFieldAndAnnounce:")]
		void VoiceOverFocusOnTextField ([NullAllowed] string announcement);
	}

	interface IMSBadgeViewDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSBadgeViewDelegate)]
	interface MSBadgeViewDelegate {

		[Abstract]
		[Export ("didSelectBadge:")]
		void DidSelectBadge (MSBadgeView badge);

		[Abstract]
		[Export ("didTapSelectedBadge:")]
		void DidTapSelectedBadge (MSBadgeView badge);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSBadgeView)]
	interface MSBadgeView {

		[Export ("initWithFrame:")]
		IntPtr Constructor (CGRect frame);

		[NullAllowed, Export ("dataSource", ArgumentSemantic.Strong)]
		MSBadgeViewDataSource DataSource { get; set; }

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSBadgeViewDataSource)]
	[DisableDefaultCtor]
	interface MSBadgeViewDataSource {

		[Export ("text")]
		string Text { get; }

		[Export ("initWithText:style:")]
		[DesignatedInitializer]
		IntPtr Constructor (string text, MSBadgeViewStyle style);
	}

	[BaseType (typeof (UIButton), Name = ApiDefConstants.MSButton)]
	interface MSButton {

		[Export ("style", ArgumentSemantic.Assign)]
		MSButtonStyle Style { get; set; }

		[Export ("initWithStyle:")]
		[DesignatedInitializer]
		IntPtr Constructor (MSButtonStyle style);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSCalendarConfiguration)]
	[DisableDefaultCtor]
	interface MSCalendarConfiguration {

		[Static]
		[Export ("default_", ArgumentSemantic.Strong)]
		MSCalendarConfiguration GetDefault { [Bind ("default")] get; }

		[Export ("firstWeekday")]
		nint FirstWeekday { get; set; }
	}

	[BaseType (typeof (UITableViewCell), Name = ApiDefConstants.MSCenteredLabelCell)]
	interface MSCenteredLabelCell {

		[Export ("initWithStyle:reuseIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSColors)]
	[DisableDefaultCtor]
	interface MSColors {

		[Static]
		[Export ("primary", ArgumentSemantic.Strong)]
		UIColor Primary { get; set; }

		[Static]
		[Export ("lightPrimary", ArgumentSemantic.Strong)]
		UIColor LightPrimary { get; set; }

		[Static]
		[Export ("lightGray", ArgumentSemantic.Strong)]
		UIColor LightGray { get; set; }

		[Static]
		[Export ("gray", ArgumentSemantic.Strong)]
		UIColor Gray { get; set; }

		[Static]
		[Export ("darkGray", ArgumentSemantic.Strong)]
		UIColor DarkGray { get; set; }

		[Static]
		[Export ("backgroundLightGray", ArgumentSemantic.Strong)]
		UIColor BackgroundLightGray { get; set; }

		[Static]
		[Export ("backgroundGray", ArgumentSemantic.Strong)]
		UIColor BackgroundGray { get; set; }

		[Static]
		[Export ("borderLightGray", ArgumentSemantic.Strong)]
		UIColor BorderLightGray { get; set; }

		[Static]
		[Export ("borderGray", ArgumentSemantic.Strong)]
		UIColor BorderGray { get; set; }

		[Static]
		[Export ("white", ArgumentSemantic.Strong)]
		UIColor White { get; set; }

		[Static]
		[Export ("black", ArgumentSemantic.Strong)]
		UIColor Black { get; set; }

		[Static]
		[Export ("error", ArgumentSemantic.Strong)]
		UIColor Error { get; set; }

		[Static]
		[Export ("lightError", ArgumentSemantic.Strong)]
		UIColor LightError { get; set; }

		[Static]
		[Export ("warning", ArgumentSemantic.Strong)]
		UIColor Warning { get; set; }

		[Static]
		[Export ("lightWarning", ArgumentSemantic.Strong)]
		UIColor LightWarning { get; set; }

		[Static]
		[Export ("avatarBackgroundColors", ArgumentSemantic.Copy)]
		UIColor [] AvatarBackgroundColors { get; set; }

		[Static]
		[Export ("background", ArgumentSemantic.Strong)]
		UIColor Background { get; set; }

		[Static]
		[Export ("buttonImage", ArgumentSemantic.Strong)]
		UIColor ButtonImage { get; set; }

		[Static]
		[Export ("disabled", ArgumentSemantic.Strong)]
		UIColor Disabled { get; set; }

		[Static]
		[Export ("foregroundRegular", ArgumentSemantic.Strong)]
		UIColor ForegroundRegular { get; set; }

		[Static]
		[Export ("foregroundSecondary", ArgumentSemantic.Strong)]
		UIColor ForegroundSecondary { get; set; }

		[Static]
		[Export ("activityIndicator", ArgumentSemantic.Strong)]
		UIColor ActivityIndicator { get; set; }

		[Static]
		[Export ("centeredLabelText", ArgumentSemantic.Strong)]
		UIColor CenteredLabelText { get; set; }

		[Static]
		[Export ("separator", ArgumentSemantic.Strong)]
		UIColor Separator { get; set; }
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSDateTimePicker)]
	interface MSDateTimePicker {

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IMSDateTimePickerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export ("presentFrom:with:startDate:endDate:")]
		void PresentFrom (UIViewController presentingController, MSDateTimePickerMode mode, NSDate startDate, [NullAllowed] NSDate endDate);

		[Export ("dismiss")]
		void Dismiss ();
	}

	interface IMSDateTimePickerDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSDateTimePickerDelegate)]
	interface MSDateTimePickerDelegate {

		[Abstract]
		[Export ("dateTimePicker:didPickStartDate:endDate:")]
		void DidPickDate (MSDateTimePicker dateTimePicker, NSDate startDate, NSDate endDate);

		[Export ("dateTimePicker:shouldEndPickingStartDate:endDate:")]
		bool ShouldEndPickingDate (MSDateTimePicker dateTimePicker, NSDate startDate, NSDate endDate);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSDotView)]
	interface MSDotView {

		[NullAllowed, Export ("color", ArgumentSemantic.Strong)]
		UIColor Color { get; set; }

		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);

		[Export ("drawRect:")]
		void DrawRect (CGRect rect);
	}

	[BaseType (typeof (UIViewController), Name = ApiDefConstants.MSDrawerController)]
	interface MSDrawerController {

		[NullAllowed, Export ("contentController", ArgumentSemantic.Strong)]
		UIViewController ContentController { get; set; }

		[NullAllowed, Export ("contentView", ArgumentSemantic.Strong)]
		UIView ContentView { get; set; }

		[Export ("resizingBehavior", ArgumentSemantic.Assign)]
		MSDrawerResizingBehavior ResizingBehavior { get; set; }

		[Export ("isExpanded")]
		bool IsExpanded { get; set; }

		[Export ("permittedArrowDirections", ArgumentSemantic.Assign)]
		UIPopoverArrowDirection PermittedArrowDirections { get; set; }

		[NullAllowed, Export ("onDismiss", ArgumentSemantic.Copy)]
		Action OnDismiss { get; set; }

		[NullAllowed, Export ("onDismissCompleted", ArgumentSemantic.Copy)]
		Action OnDismissCompleted { get; set; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IMSDrawerControllerDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export ("initWithSourceView:sourceRect:presentationOrigin:presentationDirection:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIView sourceView, CGRect sourceRect, nfloat presentationOrigin, MSDrawerPresentationDirection presentationDirection);

		[Export ("initWithBarButtonItem:presentationOrigin:presentationDirection:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIBarButtonItem barButtonItem, nfloat presentationOrigin, MSDrawerPresentationDirection presentationDirection);
	}

	interface IMSDrawerControllerDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSDrawerControllerDelegate)]
	interface MSDrawerControllerDelegate {

		[Export ("drawerControllerDidChangeExpandedState:")]
		void DidChangeExpandedState (MSDrawerController controller);

		[Export ("drawerControllerWillDismiss:")]
		void WillDismiss (MSDrawerController controller);

		[Export ("drawerControllerDidDismiss:")]
		void DidDismiss (MSDrawerController controller);
	}

	[BaseType (typeof (UIButton), Name = ApiDefConstants.MSEasyTapButton)]
	interface MSEasyTapButton {

		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSFonts)]
	[DisableDefaultCtor]
	interface MSFonts {

		[Static]
		[Export ("title1", ArgumentSemantic.Strong)]
		UIFont Title1 { get; }

		[Static]
		[Export ("title2", ArgumentSemantic.Strong)]
		UIFont Title2 { get; }

		[Static]
		[Export ("headline", ArgumentSemantic.Strong)]
		UIFont Headline { get; }

		[Static]
		[Export ("body", ArgumentSemantic.Strong)]
		UIFont Body { get; }

		[Static]
		[Export ("subhead", ArgumentSemantic.Strong)]
		UIFont Subhead { get; }

		[Static]
		[Export ("footnote", ArgumentSemantic.Strong)]
		UIFont Footnote { get; }

		[Static]
		[Export ("caption1", ArgumentSemantic.Strong)]
		UIFont Caption1 { get; }

		[Static]
		[Export ("caption2", ArgumentSemantic.Strong)]
		UIFont Caption2 { get; }
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSHud)]
	[DisableDefaultCtor]
	interface MSHud {

		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		MSHud Shared { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		IMSHudDelegate Delegate { get; set; }

		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		[Export ("showIn:")]
		void ShowIn (UIView view);

		[Export ("showIn:with:")]
		void ShowIn (UIView view, MSHudParams parameters);

		[Export ("showFrom:")]
		void ShowFrom (UIViewController controller);

		[Export ("showFrom:with:")]
		void ShowFrom (UIViewController controller, MSHudParams parameters);

		[Export ("showSuccessIn:with:")]
		void ShowSuccess (UIView view, string caption);

		[Export ("showSuccessFrom:with:")]
		void ShowSuccess (UIViewController controller, string caption);

		[Export ("showFailureIn:with:")]
		void ShowFailure (UIView view, string caption);

		[Export ("showFailureFrom:with:")]
		void ShowFailure (UIViewController controller, string caption);

		[Export ("hideAnimated:")]
		void Hide (bool animated);
	}

	interface IMSHudDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSHudDelegate)]
	interface MSHudDelegate {

		[Abstract]
		[Export ("defaultWindowForHUD:")]
		[return: NullAllowed]
		UIWindow GetDefaultWindow (MSHud hud);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSHudParams)]
	interface MSHudParams {

		[Export ("caption")]
		string Caption { get; set; }

		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; set; }

		[Export ("isBlocking")]
		bool IsBlocking { get; set; }

		[Export ("isPersistent")]
		bool IsPersistent { get; set; }

		[Export ("initWithCaption:image:isPersistent:isBlocking:")]
		IntPtr Constructor (string caption, [NullAllowed] UIImage image, bool isPersistent, bool isBlocking);
	}

	[BaseType (typeof (UILabel), Name = ApiDefConstants.MSLabel)]
	interface MSLabel {

		[Export ("colorStyle", ArgumentSemantic.Assign)]
		MSTextColorStyle ColorStyle { get; set; }

		[Export ("style", ArgumentSemantic.Assign)]
		MSTextStyle Style { get; set; }

		[Export ("initWithStyle:colorStyle:")]
		[DesignatedInitializer]
		IntPtr Constructor (MSTextStyle style, MSTextColorStyle colorStyle);
	}

	[BaseType (typeof (UIViewController), Name = ApiDefConstants.MSPageCardPresenterController)]
	interface MSPageCardPresenterController {
	}

	interface IMSPersona { }

	[Protocol (Name = ApiDefConstants.MSPersona)]
	interface MSPersona {

		[Abstract]
		[NullAllowed, Export ("avatarImage", ArgumentSemantic.Strong)]
		UIImage AvatarImage { get; }

		[Abstract]
		[Export ("email")]
		string Email { get; }

		[Abstract]
		[Export ("name")]
		string Name { get; }

		[Abstract]
		[Export ("subtitle")]
		string Subtitle { get; }
	}

	[BaseType (typeof (UITableViewCell), Name = ApiDefConstants.MSTableViewCell)]
	interface MSTableViewCell {

		[Static]
		[Export ("smallHeight")]
		nfloat SmallHeight { get; }

		[Static]
		[Export ("mediumHeight")]
		nfloat MediumHeight { get; }

		[Static]
		[Export ("largeHeight")]
		nfloat LargeHeight { get; }

		[Static]
		[Export ("identifier")]
		string Identifier { get; }

		[Static]
		[Export ("separatorLeftInsetForSmallCustomView")]
		nfloat SeparatorLeftInsetForSmallCustomView { get; }

		[Static]
		[Export ("separatorLeftInsetForMediumCustomView")]
		nfloat SeparatorLeftInsetForMediumCustomView { get; }

		[Static]
		[Export ("separatorLeftInsetForNoCustomView")]
		nfloat SeparatorLeftInsetForNoCustomView { get; }

		[Static]
		[Export ("heightWithTitle:subtitle:footer:customViewSize:customAccessoryView:accessoryType:titleNumberOfLines:subtitleNumberOfLines:footerNumberOfLines:containerWidth:")]
		nfloat GetHeightWithTitle (string title, string subtitle, string footer, MSCustomViewSize customViewSize, [NullAllowed] UIView customAccessoryView, MSTableViewCellAccessoryType accessoryType, nint titleNumberOfLines, nint subtitleNumberOfLines, nint footerNumberOfLines, nfloat containerWidth);

		[Export ("titleNumberOfLines")]
		nint TitleNumberOfLines { get; set; }

		[Export ("subtitleNumberOfLines")]
		nint SubtitleNumberOfLines { get; set; }

		[Export ("footerNumberOfLines")]
		nint FooterNumberOfLines { get; set; }

		[Export ("titleLineBreakMode", ArgumentSemantic.Assign)]
		UILineBreakMode TitleLineBreakMode { get; set; }

		[Export ("subtitleLineBreakMode", ArgumentSemantic.Assign)]
		UILineBreakMode SubtitleLineBreakMode { get; set; }

		[Export ("footerLineBreakMode", ArgumentSemantic.Assign)]
		UILineBreakMode FooterLineBreakMode { get; set; }

		[Export ("customViewSize")]
		MSCustomViewSize CustomViewSize { get; }

		[NullAllowed, Export ("onAccessoryTapped", ArgumentSemantic.Copy)]
		Action OnAccessoryTapped { get; set; }

		[NullAllowed, Export ("onSelected", ArgumentSemantic.Copy)]
		Action OnSelected { get; set; }

		[Export ("initWithStyle:reuseIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);

		[Export ("setupWithTitle:subtitle:footer:customView:customAccessoryView:accessoryType:")]
		void Setup (string title, string subtitle, string footer, [NullAllowed] UIView customView, [NullAllowed] UIView customAccessoryView, MSTableViewCellAccessoryType accessoryType);

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);

		[Export ("touchesBegan:withEvent:")]
		void TouchesBegan (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		[Export ("touchesCancelled:withEvent:")]
		void TouchesCancelled (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);

		[Export ("touchesEnded:withEvent:")]
		void TouchesEnded (NSSet<UITouch> touches, [NullAllowed] UIEvent @event);
	}

	[BaseType (typeof (MSTableViewCell), Name = ApiDefConstants.MSPersonaCell)]
	interface MSPersonaCell {

		[Export ("initWithStyle:reuseIdentifier:")]
		[DesignatedInitializer]
		IntPtr Constructor (UITableViewCellStyle style, [NullAllowed] string reuseIdentifier);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSPersonaData)]
	[DisableDefaultCtor]
	interface MSPersonaData : MSPersona {

		[Export ("initWithName:email:subtitle:avatarImage:")]
		[DesignatedInitializer]
		IntPtr Constructor (string name, string email, string subtitle, [NullAllowed] UIImage avatarImage);
	}

	[BaseType (typeof (UITableView), Name = ApiDefConstants.MSPersonaListView)]
	interface MSPersonaListView {

		[Export ("personaList", ArgumentSemantic.Copy)]
		IMSPersona [] PersonaList { get; set; }

		[Export ("accessoryType", ArgumentSemantic.Assign)]
		MSTableViewCellAccessoryType AccessoryType { get; set; }

		[Export ("showsSearchDirectoryButton")]
		bool ShowsSearchDirectoryButton { get; set; }

		[Wrap ("WeakSearchDirectoryDelegate")]
		[NullAllowed]
		IMSPersonaListViewSearchDirectoryDelegate SearchDirectoryDelegate { get; set; }

		[NullAllowed, Export ("searchDirectoryDelegate", ArgumentSemantic.Weak)]
		NSObject WeakSearchDirectoryDelegate { get; set; }

		[NullAllowed, Export ("onPersonaSelected", ArgumentSemantic.Copy)]
		Action<IMSPersona> OnPersonaSelected { get; set; }

		[Export ("pickPersona")]
		void PickPersona ();

		[Export ("selectPersonaWithDirection:")]
		void SelectPersona (MSPersonaListViewSelectionDirection direction);
	}

	interface IMSPersonaListViewSearchDirectoryDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSPersonaListViewSearchDirectoryDelegate)]
	interface MSPersonaListViewSearchDirectoryDelegate {

		[Abstract]
		[Export ("personaListSearchDirectory:completion:")]
		void SearchDirectoryCompletion (MSPersonaListView personaListView, Action<bool> completion);
	}

	[BaseType (typeof (MSDrawerController), Name = ApiDefConstants.MSPopupMenuController)]
	interface MSPopupMenuController {

		[NullAllowed, Export ("headerItem", ArgumentSemantic.Strong)]
		MSPopupMenuItem HeaderItem { get; set; }

		[NullAllowed, Export ("selectedItemIndexPath", ArgumentSemantic.Copy)]
		NSIndexPath SelectedItemIndexPath { get; set; }

		[Export ("addItems:")]
		void AddItems (MSPopupMenuItem [] items);

		[Export ("addSection:")]
		void AddSection (MSPopupMenuSection section);

		[Export ("addSections:")]
		void AddSections (MSPopupMenuSection [] sections);

		[Export ("initWithSourceView:sourceRect:presentationOrigin:presentationDirection:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIView sourceView, CGRect sourceRect, nfloat presentationOrigin, MSDrawerPresentationDirection presentationDirection);

		[Export ("initWithBarButtonItem:presentationOrigin:presentationDirection:")]
		[DesignatedInitializer]
		IntPtr Constructor (UIBarButtonItem barButtonItem, nfloat presentationOrigin, MSDrawerPresentationDirection presentationDirection);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSPopupMenuItem)]
	[DisableDefaultCtor]
	interface MSPopupMenuItem {

		[NullAllowed, Export ("image", ArgumentSemantic.Strong)]
		UIImage Image { get; }

		[NullAllowed, Export ("selectedImage", ArgumentSemantic.Strong)]
		UIImage SelectedImage { get; }

		[Export ("title")]
		string Title { get; }

		[NullAllowed, Export ("subtitle")]
		string Subtitle { get; }

		[Export ("isEnabled")]
		bool IsEnabled { get; set; }

		[Export ("isSelected")]
		bool IsSelected { get; set; }

		[NullAllowed, Export ("onSelected", ArgumentSemantic.Copy)]
		Action OnSelected { get; }

		[Export ("initWithImage:selectedImage:title:subtitle:isEnabled:isSelected:onSelected:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] UIImage image, [NullAllowed] UIImage selectedImage, string title, [NullAllowed] string subtitle, bool isEnabled, bool isSelected, [NullAllowed] Action onSelected);

		[Export ("initWithImageName:generateSelectedImage:title:subtitle:isEnabled:isSelected:onSelected:")]
		IntPtr Constructor (string imageName, bool generateSelectedImage, string title, [NullAllowed] string subtitle, bool isEnabled, bool isSelected, [NullAllowed] Action onSelected);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSPopupMenuSection)]
	[DisableDefaultCtor]
	interface MSPopupMenuSection {

		[NullAllowed, Export ("title")]
		string Title { get; }

		[Export ("items", ArgumentSemantic.Copy)]
		MSPopupMenuItem [] Items { get; set; }

		[Export ("initWithTitle:items:")]
		[DesignatedInitializer]
		IntPtr Constructor ([NullAllowed] string title, MSPopupMenuItem [] items);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSResizingHandleView)]
	interface MSResizingHandleView {

		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);
	}

	[BaseType (typeof (UIControl), Name = ApiDefConstants.MSSegmentedControl)]
	interface MSSegmentedControl {

		[Export ("isAnimated")]
		bool IsAnimated { get; set; }

		[Export ("numberOfSegments")]
		nint NumberOfSegments { get; }

		[Export ("selectedSegmentIndex")]
		nint SelectedSegmentIndex { get; set; }

		[Export ("initWithItems:")]
		[DesignatedInitializer]
		IntPtr Constructor (string [] items);

		[Export ("insertSegmentWithTitle:at:")]
		void InsertSegment (string title, nint index);

		[Export ("removeSegmentAt:")]
		void RemoveSegment (nint index);

		[Export ("selectSegmentAt:animated:")]
		void SelectSegment (nint index, bool animated);

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSTouchForwardingView)]
	interface MSTouchForwardingView {

		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);
	}

	[BaseType (typeof (UIView), Name = ApiDefConstants.MSTwoLinesTitleView)]
	interface MSTwoLinesTitleView {

		[Export ("initWithStyle:")]
		IntPtr Constructor (MSTwoLinesTitleStyle style);

		[Export ("initWithFrame:")]
		[DesignatedInitializer]
		IntPtr Constructor (CGRect frame);

		[Export ("sizeThatFits:")]
		CGSize GetSizeThatFits (CGSize size);

		[Export ("accessibilityElementCount")]
		nint AccessibilityElementCount { get; }

		[Export ("accessibilityElementAtIndex:")]
		[return: NullAllowed]
		NSObject GetAccessibilityElement (nint index);

		[Export ("indexOfAccessibilityElement:")]
		nint GetIndexOfAccessibilityElement (NSObject element);
	}

	interface IMSTwoLinesTitleViewDelegate { }

	[Protocol, Model (AutoGeneratedName = true)]
	[BaseType (typeof (NSObject), Name = ApiDefConstants.MSTwoLinesTitleViewDelegate)]
	interface MSTwoLinesTitleViewDelegate {

		[Abstract]
		[Export ("twoLinesTitleView:didTapOnTitle:")]
		void DidTapOnTitle (MSTwoLinesTitleView twoLinesTitleView, string title);
	}

	[BaseType (typeof (NSObject), Name = ApiDefConstants.OfficeUIFabricFramework)]
	interface OfficeUIFabricFramework {
	}
}
