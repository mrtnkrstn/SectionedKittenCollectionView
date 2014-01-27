// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace SectionedKittenCollectionView.iOS.Views
{
	[Register ("KittenCollectionViewCell")]
	partial class KittenCollectionViewCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView MainImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NameLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (MainImage != null) {
				MainImage.Dispose ();
				MainImage = null;
			}
		}
	}
}
