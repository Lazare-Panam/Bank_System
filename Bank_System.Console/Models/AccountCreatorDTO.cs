namespace Models
{
    public class AccountCreatorDTO
    {
        public string HolderName {get; set;} = string.Empty;
        public string Balance {get; set;} = string.Empty;
        public AccountType AccountType {get;set;}
        public DateTimeOffset DateCreated {get;set;}
    }
}
