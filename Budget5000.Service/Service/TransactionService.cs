using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using Budget5000.Service.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Budget5000.Service.Service
{
    public class TransactionService : ITransactionService
    {
        public TransactionService()
        {
            _DataManager = new DataManager();

            WorkingTransactions = _DataManager.LoadRecords();
            WorkingTransactions.CollectionChanged += WorkingTransactions_CollectionChanged;

            foreach(var trans in WorkingTransactions)
            {
                trans.PropertyChanged += Trans_PropertyChanged;
            }
        }

        public ObservableCollection<Transaction> WorkingTransactions { get; set; }
        public event EventHandler<ObservableCollection<Transaction>> Updated = delegate { };
        private void WorkingTransactions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                var trans = e.NewItems[0] as Transaction;
                trans.ID = Guid.NewGuid();
                trans.TimeStamp = DateTime.Now;
                trans.PropertyChanged += Trans_PropertyChanged;
            }
        }

        private void Trans_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {            
            Updated(this, WorkingTransactions);
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return WorkingTransactions;
        }

        public void SaveTransactions()
        {
            _DataManager.SaveRecords(WorkingTransactions);
        }

        private DataManager _DataManager;
    }
}
