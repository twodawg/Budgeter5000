using System;

namespace Budget5000.Infrastructure.Model
{
    public class Transaction
    {
        public int ID { get; set; }
        public Account AccountName { get; set; }
        public ModifierType Type { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TimeStamp { get; set; }

    }
    public enum ModifierType
    {
        CREDIT,
        DEBIT
    }

}
