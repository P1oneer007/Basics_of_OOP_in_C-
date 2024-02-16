using System;
public enum AccountType
{
    Savings,
    Checking
}

namespace BankAccount
{
    public class BankAccount
    {
        private string _accountNumber;
        private decimal _balance;
        private AccountType _accountType;

        public BankAccount(string accountNumber, decimal balance, AccountType accountType)
        {
            _accountNumber = accountNumber;
            _balance = balance;
            _accountType = accountType;
        }

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= _balance)
            {
                _balance -= amount;
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        public void PrintAccountInfo()
        {
            Console.WriteLine("Account Number: " + _accountNumber);
            Console.WriteLine("Balance: " + _balance);
            Console.WriteLine("Account Type: " + _accountType);
        }
    }

    class Program
    {
        static void Main()
        {
            BankAccount account = new BankAccount("12345", 1000, AccountType.Checking);
            account.Deposit(500);
            account.PrintAccountInfo();
        }
    }
}