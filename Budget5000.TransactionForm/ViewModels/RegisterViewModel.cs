using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Budget5000.TransactionForm.ViewModels
{
    public class RegisterViewModel : BindableBase, INavigationAware
    {
        public RegisterViewModel(ITransactionService transactionService,
            IAccountService accountService)
        {
            _TransactionService = transactionService;
            _AccountService = accountService;

            SaveAllCommand = new DelegateCommand(OnSave);
        }

        private void OnSave()
        {
            _TransactionService.SaveTransactions();
        }

        private ObservableCollection<Transaction> _Records;
        private ITransactionService _TransactionService;
        private IAccountService _AccountService;

        public DelegateCommand SaveAllCommand { get; set; }
        public ObservableCollection<Transaction> Records
        {
            get { return _Records; }
            set
            {
                SetProperty(ref _Records, value);
            }
        }


        private Transaction _SelectedRecord;
        public Transaction SelectedRecord
        {
            get
            {
                return _SelectedRecord;
            }
            set
            {
                SetProperty(ref _SelectedRecord, value);
            }
        }

        private void Records_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var trans = e.NewItems[0] as Transaction;
                trans.ID = Guid.NewGuid();
                trans.TimeStamp = DateTime.Now;
            }
        }
        
        public List<Account> AccountList
        {
            get
            {
                return _AccountService.GetAccounts();
            }
        }
        public Account SelectedAccountFilter
        {
            get
            {
                return null;
            }
            set
            {
                Records = new ObservableCollection<Transaction>(
                    _TransactionService.GetTransactions()
                    .Where(q => q.AccountID == value.ID));

                Records.CollectionChanged += Records_CollectionChanged;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Records = _TransactionService.GetTransactions();
            Records.CollectionChanged += Records_CollectionChanged;
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
