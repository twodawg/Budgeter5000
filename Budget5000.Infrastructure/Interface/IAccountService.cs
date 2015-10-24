using Budget5000.Infrastructure.Model;
using System.Collections.Generic;

namespace Budget5000.Infrastructure.Interface
{
    public interface IAccountService
    {
        List<Account> GetAccounts();
        void AddAccount(Account account);
    }
}
