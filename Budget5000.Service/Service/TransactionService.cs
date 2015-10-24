using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Service.Service
{
    public class TransactionService : ITransactionService
    {
        public List<Transaction> WorkingTransactions { get; set; }

        public TransactionService()
        {
        }

        public List<Transaction> GetTransactions()
        {
            WorkingTransactions = new List<Transaction>();
            return WorkingTransactions;
        }
    }
}
