public class AccountNotFoundException : Exception
{
    public Guid Id {get;}
    public AccountNotFoundException(string message, Guid id):base(message)
    {
        Id = id;
    }
}