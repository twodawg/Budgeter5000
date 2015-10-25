using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using Budget5000.Service.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Budget5000.Service.Service
{
    public class TransactionService : ITransactionService
    {
        private DataManager _DataManager;
        public ObservableCollection<Transaction> WorkingTransactions { get; set; }

        public TransactionService()
        {
            _DataManager = new DataManager();
            WorkingTransactions = _DataManager.LoadRecords();
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return WorkingTransactions;
        }

        public void SaveTransactions()
        {
            _DataManager.SaveRecords(WorkingTransactions);
        }        
    }
}
