using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget5000.Infrastructure.Model
{
    public class IncomeStatement
    {
        public List<Transaction> Transactions { get; set; }
        public string IncomeStatementImage { get; set; }
    }
}
