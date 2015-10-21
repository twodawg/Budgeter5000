using Budget5000.Infrastructure.Interface;
using Budget5000.Service.Service;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace Budget5000.Service
{
    public class ServiceModule : IModule
    {
        private IUnityContainer _Container;
        private IRegionManager _RegionManager;

        public ServiceModule(IUnityContainer container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;
        }

        public void Initialize()
        {
            var accountService = new AccountService();

            //_Container.RegisterType<IAccountService, AccountService>(typeof(AccountService).Name,
            //    new ContainerControlledLifetimeManager());

            _Container.RegisterInstance<IAccountService>(accountService, new ContainerControlledLifetimeManager());
        }
    }
}
