using Budget5000.Infrastructure;
using Prism.Regions;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Budget5000.TransactionForm.Views
{
    /// <summary>
    /// Interaction logic for AccountNavigationView.xaml
    /// </summary>
    public partial class AccountNavigationView : UserControl
    {

        private static Uri accountViewUri = new Uri("AccountView", UriKind.Relative);
        private IRegionManager _RegionManager;

        public AccountNavigationView(IRegionManager regionManager)
        {
            InitializeComponent();

            _RegionManager = regionManager;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _RegionManager.RequestNavigate(RegionNames.MainContentRegion, accountViewUri);
        }
    }
}
