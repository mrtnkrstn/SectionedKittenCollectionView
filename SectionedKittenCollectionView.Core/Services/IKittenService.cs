using System;
using System.Linq;
using System.Collections.Generic;
using SectionedKittenCollectionView.Core.ViewModels;

namespace SectionedKittenCollectionView.Core
{
	public interface IKittenService
	{
		IEnumerable<KittenSectionViewModel> GetKittenSections(int numSections);
	}

	public class KittenService : IKittenService
	{
		public IEnumerable<KittenSectionViewModel> GetKittenSections(int numSections)
		{
			var kittenSections = new List<KittenSectionViewModel> ();

			for (int i = 0; i < numSections; i++) {
				var kittenSection = GetKittenSection (i);

				kittenSections.Add (kittenSection);
			}

			return kittenSections;
		}

		private KittenSectionViewModel GetKittenSection(int section)
		{
			return new KittenSectionViewModel
			{
				Kittens = GetKittens(),
				SectionName = string.Format("Section_{0}", section)
			};
		}

		private List<Kitten> GetKittens(string extra = "")
		{
			var kittens = new List<Kitten> ();

			var kittenCount = Random (13) + 3;

			for (int i = 0; i < kittenCount; i++) {
				var kitten = new Kitten {
					Name = _names [Random (_names.Count)] + extra,
					ImageUrl = string.Format ("http://placekitten.com/{0}/{0}", Random (20) + 300),
//				Price = RandomPrice()
				};

				kittens.Add (kitten);
			}

			return kittens;
		}

		private readonly List<string> _names = new List<string>() { 
			"Tiddles", 
			"Amazon", 
			"Pepsi", 
			"Solomon", 
			"Butler", 
			"Snoopy", 
			"Harry", 
			"Holly", 
			"Paws", 
			"Polly", 
			"Dixie", 
			"Fern", 
			"Cousteau", 
			"Frankenstein", 
			"Bazooka", 
			"Casanova", 
			"Fudge", 
			"Comet" };

		private readonly System.Random _random = new System.Random();
		protected int Random(int count)
		{
			return _random.Next(count);
		}
//
//		protected int RandomPrice()
//		{
//			return Random(23) + 3;
//		}
	}
}

