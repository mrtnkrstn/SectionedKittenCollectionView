using System.Drawing;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Touch.Views;
using MonoTouch.ObjCRuntime;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using Cirrious.MvvmCross.Binding.Touch.Views;
using SectionedKittenCollectionView.Core.ViewModels;

namespace SectionedKittenCollectionView.iOS.Views
{
	[Register("KittensView")]
	public class KittensView : MvxCollectionViewController
    {

		public KittensView() : base(new UICollectionViewFlowLayout { 
			ItemSize = new SizeF(122, 33), 
			SectionInset = new UIEdgeInsets (5, 5, 5, 5) 
		})
		{
		}

        public override void ViewDidLoad()
        {
//			View = new UIView { BackgroundColor = UIColor.White };
            base.ViewDidLoad();

			// ios7 layout
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
               EdgesForExtendedLayout = UIRectEdge.None;
			   
			CollectionView.RegisterNibForCell (KittenCollectionViewCell.Nib, KittenCollectionViewCell.Key);
//			var source = new MvxCollectionViewSource (CollectionView, KittenCollectionViewCell.Key);
			var source = new KittensCollectionViewSource(this.ViewModel as KittensViewModel, CollectionView, KittenCollectionViewCell.Key);
			CollectionView.Source = source;

			var set = this.CreateBindingSet<KittensView, KittensViewModel> ();
			set.Bind (source).To (vm => vm);
			//set.Bind (source).For (s => s.SelectionChangedCommand).To (vm => vm.ItemSelectedCommand);
			set.Apply ();

			CollectionView.ReloadData ();
        }

		public override bool ShouldSelectItem (UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}

		public override bool ShouldHighlightItem (UICollectionView collectionView, NSIndexPath indexPath)
		{
			return true;
		}



		internal class KittensCollectionViewSource : MvxCollectionViewSource
		{
			KittensViewModel KittensViewModel { get; set; }

			public KittensCollectionViewSource (KittensViewModel kittensViewModel, UICollectionView collectionView, NSString defaultCellIdentifier) : base (collectionView, defaultCellIdentifier)
			{
				this.KittensViewModel = kittensViewModel;
			}

			public override int GetItemsCount (UICollectionView collectionView, int section)
			{
				var count = KittensViewModel.KittenSections [section].Kittens.Count;

				return count;
			}

			public override int NumberOfSections (UICollectionView collectionView)
			{
				var count = KittensViewModel.KittenSections.Count;

				return count;
			}

			protected override UICollectionViewCell GetOrCreateCellFor (UICollectionView collectionView, NSIndexPath indexPath, object item)
			{
				var cell = collectionView.DequeueReusableCell (DefaultCellIdentifier, indexPath) as KittenCollectionViewCell;

//				cell.DelayBind (() => {
//					var set = this.CreateBindingSet<KittenCollectionViewCell, Kitten>();
//					set.Bind(cell.Label).To(vm => vm.Name);
//					set.Bind (_loader).To (kitten => kitten.ImageUrl);
//					set.Apply();
//				});

				return cell;
			}

//			public override UICollectionViewCell GetCell (UICollectionView collectionView, NSIndexPath indexPath)
//			{
//				var cell = collectionView.DequeueReusableCell (DefaultCellIdentifier, indexPath) as KittenCollectionViewCell;
//
//				return cell;	// as UICollectionViewCell;
//			}
		}
    }
}