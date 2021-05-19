using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpFundamentals
// The namespace declaration provides a way to logically organize your code
{
    public class BankAccount
    //Everything inside the { and } that follows the class declaration defines the state and behavior of the class
    {
        //accountNumberSeed - This is a data member. It's private, which means it can only be accessed by code inside the BankAccount class. It's a way of separating the public responsibilities (like having an account number) from the private implementation (how account numbers are generated).
        //It is also static, which means it is shared by all of the BankAccount objects.
        //The value of a non-static variable is unique to each instance of the BankAccount object.
        private static int accountNumberSeed = 1234567890;

        //Properties are data elements and can have code that enforces validation or other rules
        public string Number { get; }
        public string Owner { get; set; }

        //Now, let's correctly compute the Balance. 
        //The current balance can be found by summing the values of all transactions. 
        //As the code is currently, you can only get the initial balance of the account, so you'll have to update the Balance property
        //public decimal Balance { get; }  => replaced by the code below

        //This example shows an important aspect of properties. You're now computing the balance when another programmer asks for the value. 
        //Your computation enumerates all transactions, and provides the sum as the current balance.
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }





        /*Creating a new object of the BankAccount type means defining a constructor that assigns those values. 
        -A constructor is a member that has the same name as the class. 
        -It is used to initialize objects of that class type.
        -Constructors are called when you create an object using new
        */
        public BankAccount(string name, decimal initialBalance)
        {
            //this.Owner = name;
            //this.Balance = initialBalance;
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        //The List<T> class requires you to import a different namespace. Add the following at the beginning -> using System.Collections.Generic;
        private List<Transaction> allTransactions = new List<Transaction>();

        //MakeDeposit and MakeWithdrawal are methods. 
        //Methods are blocks of code that perform a single function. 
        //Reading the names of each of the members should provide enough information for you or another developer to understand what the class does.
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);

        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }



    }//end of class
}
