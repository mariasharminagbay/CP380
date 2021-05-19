using System;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {

            var account = new BankAccount("Sharmin", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            Console.WriteLine(account.Balance);
            //DateTime.Now is a property that returns the current date and time
            account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
            Console.WriteLine(account.Balance);

            // Test that the initial balances must be positive.
            //BankAccount invalidAccount;
            //try
            //{
            //    invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //    return;
            //}

            // Test for a negative balance.
            //You use the try and catch statements to mark a block of code that may throw exceptions and to catch those errors that you expect. 
            //You can use the same technique to test the code that throws an exception for a negative balance.
            //try
            //{
            //    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}

            Console.ReadLine();

            Console.WriteLine(account.GetAccountHistory());
        }
    }
}
