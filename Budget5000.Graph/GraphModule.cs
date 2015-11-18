using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

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
        }
    }
}
