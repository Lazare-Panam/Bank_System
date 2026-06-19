using Models;
namespace Delegates
{
    public delegate void AccountAction(Account account);
    public class ActionHandler
    {
        public static void ShowBalance(Account account)
        {
            Console.WriteLine($"Balance alert for account {account.Id}. Current balance: {account.Balance}");
        }
        public static void ShowAccountType(Account account)
        {
            Console.WriteLine($"Account Type alert for account {account.Id}. Account type: {account.AccountType}");
        }
    }
}
