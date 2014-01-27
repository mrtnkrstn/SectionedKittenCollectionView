using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using SectionedKittenCollectionView.Core.ViewModels;

namespace SectionedKittenCollectionView.iOS.Views
{
	public partial class KittenCollectionViewCell : MvxCollectionViewCell
	{
		public static readonly UINib Nib = UINib.FromName ("KittenCollectionViewCell", NSBundle.MainBundle);
		public static readonly NSString Key = new NSString ("KittenCollectionViewCell");

		private readonly MvxImageViewLoader _loader;

		public UILabel Label
		{
			get {
				return this.NameLabel;
			}
			set {
				this.NameLabel = value;
			}
		}

		public KittenCollectionViewCell (IntPtr handle) : base (handle)
		{
			_loader = new MvxImageViewLoader(() => MainImage);

			this.DelayBind (() => {
				var set = this.CreateBindingSet<KittenCollectionViewCell, Kitten>();
				set.Bind(NameLabel).To(vm => vm.Name);
				set.Bind (_loader).To (kitten => kitten.ImageUrl);
				set.Apply();
			});
		}

		public static KittenCollectionViewCell Create ()
		{
			return (KittenCollectionViewCell)Nib.Instantiate (null, null) [0];
		}
	}
}

