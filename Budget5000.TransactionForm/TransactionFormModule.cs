using Budget5000.Infrastructure;
using Budget5000.TransactionForm.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace Budget5000.TransactionForm
{
    public class TransactionFormModule : IModule
    {
        private IUnityContainer _Container;
        private IRegionManager _RegionManager;

        public TransactionFormModule(IUnityContainer container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;
        }
        public void Initialize()
        {
            //_RegionManager.RegisterViewWithRegion(RegionNames.MainContentRegion,
            //    () => _Container.Resolve<RegisterView>());

            _RegionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion,
                () => _Container.Resolve<RegisterNavigationView>());
            _RegionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion,
                () => _Container.Resolve<AccountNavigationView>());

            // Register views to be called via RequestNavigate
            _Container.RegisterType<Object, AccountView>("AccountView");
            _Container.RegisterType<Object, RegisterView>("RegisterView");

            _RegionManager.RequestNavigate(RegionNames.MainContentRegion, new Uri("RegisterView", UriKind.Relative));
        }

    }
}
