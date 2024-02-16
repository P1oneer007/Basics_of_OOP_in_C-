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

    public void Transfer(BankAccount destinationAccount, decimal amount)
    {
        if (amount <= Balance)
        {
            Withdraw(amount);
            destinationAccount.Deposit(amount);
            Console.WriteLine("Transfer successful");
        }
        else
        {
            Console.WriteLine("Insufficient funds for transfer");
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
        BankAccount account1 = new BankAccount(1000, AccountType.Checking);
        BankAccount account2 = new BankAccount(500, AccountType.Savings);

        account1.PrintAccountInfo();
        account2.PrintAccountInfo();

        account1.Transfer(account2, 200);

        account1.PrintAccountInfo();
        account2.PrintAccountInfo();
    }
}