using System.Linq;
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace SectionedKittenCollectionView.Core.ViewModels
{
	public class Kitten    
	{
		public string Name { get; set; }
		public string ImageUrl { get; set; }

		/*private bool _selected;
		public bool Selected
		{ 
			get { return _selected; } 
			set { _selected = value; RaisePropertyChanged (() => Selected); }
		}*/
	}

	public class KittenSectionViewModel : MvxViewModel
	{
		private string _sectionName;
		public string SectionName
		{
			get { return _sectionName; }
			set { _sectionName = value; RaisePropertyChanged(() => SectionName); }
		}

		private List<Kitten> _kittens;
		public List<Kitten> Kittens
		{ 
			get { return _kittens; }
			set { _kittens = value; RaisePropertyChanged(() => Kittens); }
		}

		/*private MvxCommand<Kitten> _itemSelectedCommand;
		public ICommand ItemSelectedCommand
		{
			get
			{
				_itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<Kitten>(DoSelectItem);
				return _itemSelectedCommand;
			}
		}

		private void DoSelectItem(Kitten kitten)
		{
			kitten.Selected = !kitten.Selected;
		}*/
	}

	public class KittensViewModel: MvxViewModel
	{
		private readonly IKittenService _kittenService;

		public List<KittenSectionViewModel> KittenSections { get; set; }

		public KittensViewModel(IKittenService kittenService)
		{
			_kittenService = kittenService;
		}

		public override void Start ()
		{
			KittenSections = _kittenService.GetKittenSections(3).ToList();
		}
	}
}
