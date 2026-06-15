namespace Models
{
    public class AccountCreatorDTO
    {
        public String HolderName {get; set;} = string.Empty;
        public String Balance {get; set;} = string.Empty;
        public AccountType AccountType {get;set;}
    }
}
