using Budget5000.Infrastructure.Interface;
using Budget5000.Infrastructure.Model;
using System.Collections.Generic;

namespace Budget5000.Service.Service
{
    public class AccountService : IAccountService
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
                new Account() { ID=100, Type=AccountType.ASSET, Description="Cash" },
                new Account() { ID=101, Type=AccountType.ASSET, Description="Loans" },
                new Account() { ID=102, Type=AccountType.ASSET, Description="Stock" },
                new Account() { ID=103, Type=AccountType.ASSET, Description="Vehicle" },
                new Account() { ID=104, Type=AccountType.ASSET, Description="Investment Property" },
                new Account() { ID=105, Type=AccountType.ASSET, Description="Home" },
                new Account() { ID=106, Type=AccountType.ASSET, Description="Inventory" },
                new Account() { ID=200, Type=AccountType.LIABILITY, Description="Credit Card" },
                new Account() { ID=201, Type=AccountType.LIABILITY, Description="Loans" },
                new Account() { ID=202, Type=AccountType.LIABILITY, Description="Mortgage Balance" },
                new Account() { ID=203, Type=AccountType.LIABILITY, Description="Tax" },
                new Account() { ID=300, Type=AccountType.EQUITY, Description="Retained Earnings" },
                new Account() { ID=400, Type=AccountType.INCOME, Description="Bank Interest" },
                new Account() { ID=401, Type=AccountType.INCOME, Description="Loan Income" },
                new Account() { ID=402, Type=AccountType.INCOME, Description="Dividends" },
                new Account() { ID=403, Type=AccountType.INCOME, Description="Capital Gains" },
                new Account() { ID=404, Type=AccountType.INCOME, Description="Pay Check" },
                new Account() { ID=405, Type=AccountType.INCOME, Description="Rental Income" },
                new Account() { ID=500, Type=AccountType.COSTOFGOODS, Description="Cost" },
                new Account() { ID=600, Type=AccountType.EXPENSE, Description="Mortgage Bill" },
                new Account() { ID=610, Type=AccountType.EXPENSE, Description="Rental Mortgage Bill" },
                new Account() { ID=601, Type=AccountType.EXPENSE, Description="Credit Card" },
                new Account() { ID=602, Type=AccountType.EXPENSE, Description="Loan Payment" },
                new Account() { ID=603, Type=AccountType.EXPENSE, Description="Retail Maintenance" },
                new Account() { ID=604, Type=AccountType.EXPENSE, Description="Child Care" },
                new Account() { ID=605, Type=AccountType.EXPENSE, Description="Utilities" },
                new Account() { ID=606, Type=AccountType.EXPENSE, Description="Gasoline" },
                new Account() { ID=607, Type=AccountType.EXPENSE, Description="Vehicle Maintenance" },
                new Account() { ID=608, Type=AccountType.EXPENSE, Description="Home Maintenance" },

            };
        }

        public List<Account> GetAccounts()
        {
            return _Accounts;
        }

        public void AddAccount(Account account)
        {
            if (account == null) return;

            _Accounts.Add(account);
        }
    }
}
