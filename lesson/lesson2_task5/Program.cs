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
        BankAccount account = new BankAccount(1000, AccountType.Checking);
        account.PrintAccountInfo();

        account.Deposit(500);
        account.PrintAccountInfo();

        account.Withdraw(200);
        account.PrintAccountInfo();

        account.Withdraw(2000);
        account.PrintAccountInfo();
    }
}