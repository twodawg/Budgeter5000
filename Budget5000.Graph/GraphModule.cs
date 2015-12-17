using Budget5000.Graph.ViewModels;
using Budget5000.Graph.Views;
using Budget5000.Infrastructure;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;

namespace Budget5000.Graph
{
    public class GraphModule : IModule
    {
        private IUnityContainer _Container;
        private IRegionManager _RegionManager;

        public GraphModule(IUnityContainer container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;
        }
        public void Initialize()
        {
            _RegionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion,
                   () => _Container.Resolve<IncomeGraphNavigationView>());

            _Container.RegisterType<Object, IncomeGraphView>(nameof(IncomeGraphView));

            var graph = _Container.Resolve<IncomeGraphViewModel>();
        }
    }
}
