using Models;

public class AccountService
{
    List<Account> accounts = new List<Account>();

    private Account FindAccount(Guid id)
    {
        var account = accounts.FirstOrDefault(x=>x.Id==id);
        if(account==null)
        {
            throw new ArgumentNullException("Account does not exist", nameof(account));
        }
        return account;
    }
    private decimal ValidateAccountCreationInput(AccountCreatorDTO accountCreatorDTO)
    {
        if(string.IsNullOrWhiteSpace(accountCreatorDTO.HolderName))
        {
            throw new ArgumentNullException("Holder name cannot be empty or whitespace", nameof(accountCreatorDTO.HolderName));
        }
        decimal balance;
        if (string.IsNullOrWhiteSpace(accountCreatorDTO.Balance) || !decimal.TryParse(accountCreatorDTO.Balance, out balance))
        {
            throw new AccountBalanceException("Invalid Balance.", accountCreatorDTO.Balance);
        }
        else if (balance <= 0.0M)
        {
            throw new AccountBalanceException("Insufficient balance.", accountCreatorDTO.Balance);  
        }
        return balance;
    }
    private decimal ValidateAccountBalanceUpdateDetials(Guid id, String bal)
    {
        if(id == Guid.Empty)
        {
            throw new ArgumentNullException("Id cannot be null", nameof(id));
        }
        decimal balance;
        if (string.IsNullOrWhiteSpace(bal) || !decimal.TryParse(bal, out balance))
        {
            throw new AccountBalanceException("Invalid Balance.", bal);
        }
        return balance;
    }
    public Guid CreateUserAccount(AccountCreatorDTO accountDTO)
    {
        decimal balance = ValidateAccountCreationInput(accountDTO);
        Account account = new Account
        {
            Id = Guid.NewGuid(),
            HolderName = accountDTO.HolderName,
            Balance = balance,
            AccountType = accountDTO.AccountType
        };
        accounts.Add(account);
        return account.Id;
    }
    public Guid IncreaseAccountBalance(Guid id, String bal)
    {
        decimal balance = ValidateAccountBalanceUpdateDetials(id,bal);
        var account = FindAccount(id);
        account.Balance+=balance;
        return id;
    }

    public Guid DecreaseAccountBalance(Guid id, String bal)
    { 
        decimal balance = ValidateAccountBalanceUpdateDetials(id,bal);
        var account = FindAccount(id);
        if(balance > account.Balance)
            throw new AccountBalanceException($"Insufficient funds. Shortfall: {balance - account.Balance}", bal);
        account.Balance-=balance;
        return id;
    }
}