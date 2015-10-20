using Budget5000.Infrastructure.Model;
using System.Collections.Generic;

namespace Budget5000.Service.Service
{
    public class AccountService
    {
        private List<Account> _Accounts;

        public AccountService()
        {
            Initialize();
        }

        private void Initialize()
        {
            _Accounts = new List<Account>()
            {
                new Account() { ID=0, Type=AccountType.ASSET, Description="Cash" },
                new Account() { ID=1, Type=AccountType.ASSET, Description="Loans" },
                new Account() { ID=2, Type=AccountType.ASSET, Description="Stock" },
                new Account() { ID=3, Type=AccountType.ASSET, Description="Vehicle" },
                new Account() { ID=4, Type=AccountType.ASSET, Description="Investment Property" },
                new Account() { ID=5, Type=AccountType.ASSET, Description="Home" },
                new Account() { ID=6, Type=AccountType.ASSET, Description="Cash" },
                new Account() { ID=7, Type=AccountType.LIABILITY, Description="Credit Card" },
                new Account() { ID=8, Type=AccountType.LIABILITY, Description="Loans" },
                new Account() { ID=9, Type=AccountType.LIABILITY, Description="Mortgage Balance" },
                new Account() { ID=10, Type=AccountType.LIABILITY, Description="Tax" },
                new Account() { ID=11, Type=AccountType.EQUITY, Description="Business Equity" },
                new Account() { ID=12, Type=AccountType.INCOME, Description="Bank Interest" },
                new Account() { ID=13, Type=AccountType.INCOME, Description="Loan Income" },
                new Account() { ID=14, Type=AccountType.INCOME, Description="Dividends" },
                new Account() { ID=15, Type=AccountType.INCOME, Description="Capital Gains" },
                new Account() { ID=16, Type=AccountType.INCOME, Description="Pay Check" },
                new Account() { ID=17, Type=AccountType.INCOME, Description="Rental Income" },
                new Account() { ID=18, Type=AccountType.EXPENSE, Description="Mortgage Bill" },
                new Account() { ID=19, Type=AccountType.EXPENSE, Description="Credit Card" },
                new Account() { ID=20, Type=AccountType.EXPENSE, Description="Loan Payment" },
                new Account() { ID=21, Type=AccountType.EXPENSE, Description="Retail Maintenance" },
                new Account() { ID=22, Type=AccountType.EXPENSE, Description="Child Care" },
                new Account() { ID=23, Type=AccountType.EXPENSE, Description="Utilities" },
                new Account() { ID=24, Type=AccountType.EXPENSE, Description="Gasoline" },
                new Account() { ID=25, Type=AccountType.EXPENSE, Description="Vehicle Maintenance" },
                new Account() { ID=26, Type=AccountType.EXPENSE, Description="Home Maintenance" },

            };
        }

        public List<Account> GetAccounts()
        {
            return _Accounts;
        }
    }
}
