using Budget5000.Infrastructure;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Budget5000.Report.Views
{
    public partial class IncomeStatementNavigationView : UserControl
    {
        private static Uri incomeStatementViewUri = new Uri(nameof(IncomeStatementView), UriKind.Relative);
        private IRegionManager _RegionManager;

        public IncomeStatementNavigationView(IRegionManager regionManager)
        {
            InitializeComponent();
            _RegionManager = regionManager;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _RegionManager.RequestNavigate(RegionNames.MainContentRegion, incomeStatementViewUri);
        }

    }
}
