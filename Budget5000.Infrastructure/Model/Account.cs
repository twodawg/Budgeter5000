using Prism.Mvvm;
using System;

namespace Budget5000.Infrastructure.Model
{
    public class Account : BindableBase
    {
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private AccountType _Type;
        public AccountType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }
        public override string ToString()
        {
            return Description;
        }
    }
    public enum AccountType
    {
        ASSET,
        LIABILITY,
        EQUITY,
        INCOME,
        COSTOFGOODS,
        EXPENSE,
    }
}