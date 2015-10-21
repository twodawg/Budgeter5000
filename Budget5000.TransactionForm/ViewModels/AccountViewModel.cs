using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

namespace Budget5000.TransactionForm.ViewModels
{
    public class AccountViewModel : BindableBase, INavigationAware
    {
        private IAccountService _AccountService;

        public AccountViewModel(IAccountService accountservice)
        {
            _AccountService = accountservice;
        }
        public AccountViewModel()
        { }

        private ObservableCollection<Account> _Records;
        public ObservableCollection<Account> Records
        {
            get { return _Records; }
            set { SetProperty(ref _Records, value); }
        }

        private Account _CurrentRecord;

        public Account CurrentRecord
        {
            get { return _CurrentRecord; }
            set { SetProperty(ref _CurrentRecord, value); }
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Records = new ObservableCollection<Account>(_AccountService.GetAccounts());
        }
    }
}
