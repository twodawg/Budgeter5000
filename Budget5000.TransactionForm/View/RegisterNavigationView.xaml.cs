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

namespace Budget5000.TransactionForm.View
{
    /// <summary>
    /// Interaction logic for RegisterNavigationView.xaml
    /// </summary>
    public partial class RegisterNavigationView : UserControl
    {
        private static Uri registerViewUri = new Uri("RegisterView", UriKind.Relative);
        private IRegionManager _RegionManager;

        public RegisterNavigationView(IRegionManager regionManager)
        {
            InitializeComponent();

            _RegionManager = regionManager;
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            _RegionManager.RequestNavigate(RegionNames.MainContentRegion, registerViewUri);
        }
    }
}
