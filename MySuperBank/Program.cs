using System;

namespace MySuperBank
{
    class Program
    {
        /*
         * CREATING BANK APP:
         * 
         * 1. Accounts have 10 Digit number ID
         * 2. Has a string that stores the name(s) of the owner(s)
         * 3. The balance can be retrieved
         * 4. It accepts deposits
         * 5. It accepts withdrawals
         * 6. The initial balance must be positive
         * 7. Withdrawals cannot make the balance negative
         * 
         */
        
        static void Main(string[] args)
        {
            try
            {
                BankAccount account = new BankAccount("Jacques", 10000);

                Console.WriteLine($"Account {account.Number} was created for {account.ListOwners()} with {account.GetBalance()}");

                account.MakeWithdrawal(60, DateTime.Now, "Bought Paper Mario");

                Console.WriteLine(account.GetTransactionHistory());
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
