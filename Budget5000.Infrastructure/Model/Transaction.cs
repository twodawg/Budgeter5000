using Prism.Mvvm;
using System;

namespace Budget5000.Infrastructure.Model
{
    public class Transaction : BindableBase
    {

        private Guid _ID;
        public Guid ID
        {
            get { return _ID; }
            set { SetProperty(ref _ID, value); }
        }

        private int _AccountID;
        public int AccountID
        {
            get { return _AccountID; }
            set { SetProperty(ref _AccountID, value); }
        }

        private ModifierType _Type;
        public ModifierType Type
        {
            get { return _Type; }
            set { SetProperty(ref _Type, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        private decimal _Amount;
        public decimal Amount
        {
            get { return _Amount; }
            set { SetProperty(ref _Amount, value); }
        }

        private DateTime _TimeStamp;
        public DateTime TimeStamp
        {
            get { return _TimeStamp; }
            set { SetProperty(ref _TimeStamp, value); }
        }
        private int _RepeatAfterDays;
        public int RepeatAfterDays
        {
            get { return _RepeatAfterDays; }
            set { SetProperty(ref _RepeatAfterDays, value); }
        }
    }
    public enum ModifierType
    {
        CREDIT,
        DEBIT
    }

}
