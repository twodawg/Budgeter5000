using Budget5000.Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Infrastructure.Interface
{
    public interface ITransactionService
    {
        List<Transaction> WorkingTransactions { get; set; }

        List<Transaction> GetTransactions();
    }
}
