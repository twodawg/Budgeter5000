using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Service.Service
{
    public class TransactionService : ITransactionService
    {
        public ObservableCollection<Transaction> WorkingTransactions { get; set; }

        public TransactionService()
        {
            WorkingTransactions = new ObservableCollection<Transaction>();
        }

        public ObservableCollection<Transaction> GetTransactions()
        {
            return WorkingTransactions;
        }
    }
}
