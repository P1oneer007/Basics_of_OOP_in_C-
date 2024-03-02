using System;

public class BankAccount
{
    public string AccountNumber { get; set; }
    public string Owner { get; set; }
    public decimal Balance { get; set; }

    public BankAccount(string accountNumber, string owner, decimal balance)
    {
        AccountNumber = accountNumber;
        Owner = owner;
        Balance = balance;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        BankAccount other = (BankAccount)obj;
        return AccountNumber == other.AccountNumber && Owner == other.Owner && Balance == other.Balance;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(AccountNumber, Owner, Balance);
    }

    public static bool operator ==(BankAccount a, BankAccount b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(BankAccount a, BankAccount b)
    {
        return !(a == b);
    }

    public override string ToString()
    {
        return $"Account Number: {AccountNumber}, Owner: {Owner}, Balance: {Balance}";
    }
}

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount("12345", "Alice", 1000);
        BankAccount account2 = new BankAccount("54321", "Bob", 500);

        Console.WriteLine(account1);
        Console.WriteLine(account2);

        Console.WriteLine($"Are the accounts equal? {account1 == account2}");
    }
}