using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.TransactionForm.ViewModels
{
    public class RegisterViewModel : BindableBase, INavigationAware
    {
        public RegisterViewModel(ITransactionService transactionService,
            IAccountService accountService)
        {
            _TransactionService = transactionService;
            _AccountService = accountService;
        }

        private List<Transaction> _Records;
        private ITransactionService _TransactionService;
        private IAccountService _AccountService;

        public List<Transaction> Records
        {
            get { return _Records; }
            set { SetProperty(ref _Records, value); }
        }

        public List<Account> AccountList
        {
            get
            {
                return _AccountService.GetAccounts();
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Records = _TransactionService.GetTransactions();
            Records.Add(new Transaction());
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
