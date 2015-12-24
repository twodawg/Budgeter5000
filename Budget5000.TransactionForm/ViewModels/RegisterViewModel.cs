using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Budget5000.TransactionForm.ViewModels
{
    public class RegisterViewModel : BindableBase, INavigationAware
    {
        public RegisterViewModel(ITransactionService transactionService,
            IAccountService accountService)
        {
            _TransactionService = transactionService;
            _AccountService = accountService;

            InitCommands();
        }

        private void InitCommands()
        {
            SaveAllCommand = new DelegateCommand(OnSave);
            ExportCommand = new DelegateCommand(OnExport);
            ImportCommand = new DelegateCommand(OnImport);
        }

        private void OnImport()
        {

        }

        private void OnExport()
        {
            var homeDirectory = Environment.GetFolderPath(
                Environment.SpecialFolder.Personal) + "\\Budgeter 5000\\Budgeter5000 Export.xlsx";

            XSSFWorkbook workbook = GetRegisterData();
            using (var f = File.Create(homeDirectory))
            {
                workbook.Write(f);
            }
            Process.Start(homeDirectory);
        }

        private XSSFWorkbook GetRegisterData()
        {
            var workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Register Transactions");

            var row = sheet.CreateRow(0);
            row.CreateCell(0).SetCellValue("AccountID");
            row.CreateCell(1).SetCellValue("Type");
            row.CreateCell(2).SetCellValue("Description");
            row.CreateCell(3).SetCellValue("Amount");
            row.CreateCell(4).SetCellValue("TimeStamp");
            row.CreateCell(5).SetCellValue("RepeatAfterDays");

            sheet.SetColumnWidth(2, 6000);
            sheet.SetColumnWidth(4, 3000);
            sheet.SetColumnWidth(5, 4000);

            for (var i = 0; i < Records.Count; i++)
            {
                var row2 = sheet.CreateRow(i + 1);
                row2.CreateCell(0).SetCellValue(Records[i].AccountID);
                row2.CreateCell(1).SetCellValue(Records[i].Type.ToString());
                row2.CreateCell(2).SetCellValue(Records[i].Description);
                row2.CreateCell(3).SetCellValue(Records[i].Amount.ToString());
                row2.CreateCell(4).SetCellValue(Records[i].TimeStamp.ToShortDateString());
                row2.CreateCell(5).SetCellValue(Records[i].RepeatAfterDays);
            }

            return workbook;
        }

        private void OnSave()
        {
            _TransactionService.SaveTransactions();
        }

        private ObservableCollection<Transaction> _Records;
        private ITransactionService _TransactionService;
        private IAccountService _AccountService;

        public DelegateCommand SaveAllCommand { get; set; }
        public DelegateCommand ExportCommand { get; set; }
        public DelegateCommand ImportCommand { get; set; }
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
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Records = _TransactionService.GetTransactions();
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
