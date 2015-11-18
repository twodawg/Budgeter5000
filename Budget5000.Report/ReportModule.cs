using Budget5000.Infrastructure;
using Budget5000.Report.Views;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Report
{
    public class ReportModule : IModule
    {
        private IUnityContainer _Container;
        private IRegionManager _RegionManager;

        public ReportModule(IUnityContainer container, IRegionManager regionManager)
        {
            _Container = container;
            _RegionManager = regionManager;
        }
        public void Initialize()
        {
            _RegionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion,
                () => _Container.Resolve<IncomeStatementNavigationView>());
            _RegionManager.RegisterViewWithRegion(RegionNames.MainNavigationRegion,
                () => _Container.Resolve<BalanceSheetNavigationView>());

            _Container.RegisterType<Object, IncomeStatementView>(nameof(IncomeStatementView));
            _Container.RegisterType<Object, BalanceSheetView>(nameof(BalanceSheetView));
        }
    }
}
