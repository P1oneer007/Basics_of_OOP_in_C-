using System;

public enum AccountType
{
    Savings,
    Checking
}

public class BankAccount
{
    private static int nextAccountNumber = 1;
    private string _accountNumber;
    private decimal _balance;
    private AccountType _accountType;

    public BankAccount(decimal balance, AccountType accountType)
    {
        _accountNumber = GenerateAccountNumber();
        _balance = balance;
        _accountType = accountType;
    }

    private string GenerateAccountNumber()
    {
        return "ACCT" + nextAccountNumber++;
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
        BankAccount account1 = new BankAccount(1000, AccountType.Checking);
        BankAccount account2 = new BankAccount(500, AccountType.Savings);

        account1.PrintAccountInfo();
        account2.PrintAccountInfo();
    }
}