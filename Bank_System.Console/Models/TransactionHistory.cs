public class TransactionHistory
{
    public decimal Amount {get; set;}
    public TransactionType TransactionType {get; set;}
    public DateTimeOffset Timestamp {get; set;}
    public decimal Balance {get; set;}
}