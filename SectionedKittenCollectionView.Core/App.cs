using Cirrious.CrossCore.IoC;

namespace SectionedKittenCollectionView.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
				
			RegisterAppStart<ViewModels.KittensViewModel>();
        }
    }
}