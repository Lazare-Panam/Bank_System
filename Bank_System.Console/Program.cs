using System;
using Models;
class Bank_System
{
    public static void Main(String []args)
    {
        AccountService accountService = new AccountService();
        while(true)
        {
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            
            if(!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Invalid option, try again");
                continue;
            }
            if(num == 4) 
                break;
            switch(num)
            {
                case 1:
                Console.WriteLine("Enter holder name:");
                string holderName = Console.ReadLine();

                Console.WriteLine("Enter opening balance:");
                string bal = Console.ReadLine();

                Console.WriteLine("Select account type: 1 = Current, 2 = Savings");
                string typeInput = Console.ReadLine();

                AccountType accountType = typeInput switch
                {
                    "1" => AccountType.Current,
                    "2" => AccountType.Savings,
                    _ => throw new Exception("Invalid account type")
                };
                AccountCreatorDTO accountDTO = new AccountCreatorDTO
                {
                    HolderName = holderName,
                    Balance  = bal,
                    AccountType = accountType
                };
                
                var id = accountService.CreateUserAccount(accountDTO);
                Console.WriteLine($"Account created successfully. ID: {id}");
                break;

                case 2:
                Console.WriteLine("Enter account ID:");
                string accountId = Console.ReadLine();

                Console.WriteLine("Enter opening balance:");
                string updateBalance = Console.ReadLine();
                
                var id2 = accountService.IncreaseAccountBalance(new Guid(accountId), updateBalance);
                Console.WriteLine($"Balance updated successfully. ID: {id2}");
                break;

                case 3:
                Console.WriteLine("Enter account ID:");
                string accountId3 = Console.ReadLine();

                Console.WriteLine("Enter opening balance:");
                string updateBalance3 = Console.ReadLine();
                var id3  = accountService.DecreaseAccountBalance(new Guid(accountId3), updateBalance3);
                break;
            }
        }
    }
}
