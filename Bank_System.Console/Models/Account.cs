namespace Models
{
    public class Account
    {
        public Guid Id {get; set;}
        public String HolderName {get; set;} = string.Empty;
        public decimal Balance  {get; set;} = 0;
        public AccountType AccountType {get;set;}
    }
}
