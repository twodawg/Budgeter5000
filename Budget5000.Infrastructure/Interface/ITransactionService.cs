using Budget5000.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Infrastructure.Interface
{
    public interface ITransactionService
    {
        event EventHandler<ObservableCollection<Transaction>> Updated;
        ObservableCollection<Transaction> WorkingTransactions { get; set; }

        ObservableCollection<Transaction> GetTransactions();

        void SaveTransactions();
    }
}
