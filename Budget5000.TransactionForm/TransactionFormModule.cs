using Budget5000.Infrastructure;
using Budget5000.TransactionForm.View;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _RegionManager.RegisterViewWithRegion(RegionNames.MainContentRegion, () => _Container.Resolve<RegisterView>());
        }

    }
}
