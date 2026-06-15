class AccountBalanceException : Exception
{
    public string CurrentBalance { get; }
    public AccountBalanceException(string message, string balance) : base(message)
    {
        CurrentBalance = balance;
    }
}
