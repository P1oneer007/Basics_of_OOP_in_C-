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

    public string AccountNumber
    {
        get => _accountNumber;
        private set
        {
            _accountNumber = value;
        }
    }

    public decimal Balance
    {
        get => _balance;
        private set
        {
            _balance = value;
        }
    }

    public AccountType AccountType
    {
        get => _accountType;
        private set
        {
            _accountType = value;
        }
    }

    public BankAccount() : this(0, AccountType.Checking)
    {
    }

    public BankAccount(decimal balance) : this(balance, AccountType.Checking)
    {
    }

    public BankAccount(AccountType accountType) : this(0, accountType)
    {
    }

    public BankAccount(decimal balance, AccountType accountType)
    {
        AccountNumber = GenerateAccountNumber();
        Balance = balance;
        AccountType = accountType;
    }

    private string GenerateAccountNumber()
    {
        return "ACCT" + nextAccountNumber++;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }

    public void PrintAccountInfo()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Balance: " + Balance);
        Console.WriteLine("Account Type: " + AccountType);
    }
}

class Program
{
    static void Main()
    {
        BankAccount account1 = new BankAccount();
        BankAccount account2 = new BankAccount(1000);
        BankAccount account3 = new BankAccount(AccountType.Savings);
        BankAccount account4 = new BankAccount(500, AccountType.Checking);

        account1.PrintAccountInfo();
        account2.PrintAccountInfo();
        account3.PrintAccountInfo();
        account4.PrintAccountInfo();
    }
}