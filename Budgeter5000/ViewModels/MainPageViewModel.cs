using Budgeter5000.Services;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgeter5000.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IDataRepository _dataRepository;

        public MainPageViewModel(IDataRepository dataRepository,
            INavigationService navigationService)
        {
            _dataRepository = dataRepository;
            NavigateCommand = new DelegateCommand(
                () => navigationService.Navigate(
                    "UserInput", null));
        }

        public DelegateCommand NavigateCommand { get; private set; }

        public List<string> DisplayItems
        {
            get { return _dataRepository.GetFeatures(); }
        }

        private bool _isNavigationDisabled;
        public bool IsNavigationDisabled
        {
            get { return _isNavigationDisabled; }
            set { SetProperty(ref _isNavigationDisabled, value); }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            e.Cancel = _isNavigationDisabled;
            base.OnNavigatingFrom(e, viewModelState, suspending);
        }

    }
}
