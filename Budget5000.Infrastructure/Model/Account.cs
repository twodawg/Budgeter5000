namespace Budget5000.Infrastructure.Model
{
    public class Account
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public AccountType Type { get; set; }

    }
    public enum AccountType
    {
        ASSET,
        LIABILITY,
        EQUITY,
        INCOME,
        EXPENSE,
    }
}