using System;
using Models;

class Bank_System
{
    public static void Main(String []args)
    {
        AccountService accountService = new AccountService();
        Bank_System bank_System = new Bank_System();
        while(true)
        {
            Console.WriteLine("1. Create account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4.  View Account & Transaction History");
            Console.WriteLine("5. Exit");
            
            if(!int.TryParse(Console.ReadLine(), out int num))
            {
                Console.WriteLine("Invalid option, try again");
                continue;
            }
            if(num == 5) 
                break;
            switch(num)
            {
                case 1:
                    bank_System.CreateUserAccount(accountService);
                    break;   

                case 2:
                    bank_System.DepositMoney(accountService);
                    break;

                case 3:
                    bank_System.WithdrawMoney(accountService);
                    break;    
            }
        }
    }
    private void CreateUserAccount(AccountService accountService)
    {
        try
        {
            Console.WriteLine("Enter holder name:");
            string holderName = Console.ReadLine();

            Console.WriteLine("Enter opening balance:");
            string openingBalance = Console.ReadLine();

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
                Balance  = openingBalance,
                AccountType = accountType
            };
            var id = accountService.CreateUserAccount(accountDTO);
            Console.WriteLine($"Account created successfully. ID: {id}");        
        }
        catch(ArgumentNullException ex)
        {
            Console.WriteLine(ex.Message);
        }  
        catch(AccountBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.Message}");
        }
    }

    private void DepositMoney(AccountService accountService)
    {
        try
        {
            Console.WriteLine("Enter account ID:");
            string accountId = Console.ReadLine();

            Console.WriteLine("Enter opening balance:");
            string updateBalance = Console.ReadLine();
            
            var id2 = accountService.IncreaseAccountBalance(new Guid(accountId), updateBalance);
            Console.WriteLine($"Balance updated successfully. ID: {id2}");
        }
        catch(AccountNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(AccountBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.Message}");
        }
    }

    private void WithdrawMoney(AccountService accountService)
    {
        try
        {
            Console.WriteLine("Enter account ID:");
            string accountId = Console.ReadLine();

            Console.WriteLine("Enter opening balance:");
            string updateBalance = Console.ReadLine();
            var id  = accountService.DecreaseAccountBalance(new Guid(accountId), updateBalance);
        }
        catch(AccountNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(AccountBalanceException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Exception occured: {ex.Message}");
        }
    }
}
