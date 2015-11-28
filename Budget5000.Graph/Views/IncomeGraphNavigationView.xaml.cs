using Budget5000.Infrastructure;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Budget5000.Graph.Views
{
    /// <summary>
    /// Interaction logic for IncomeGraphNavigationView.xaml
    /// </summary>
    public partial class IncomeGraphNavigationView : UserControl
    {
        private static Uri incomeGraphViewUri = new Uri(nameof(IncomeGraphView), UriKind.Relative);
        private IRegionManager _RegionManager;

        public IncomeGraphNavigationView(IRegionManager regionManager)
        {
            InitializeComponent();
            _RegionManager = regionManager;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _RegionManager.RequestNavigate(RegionNames.MainContentRegion, incomeGraphViewUri);

        }
    }
}
