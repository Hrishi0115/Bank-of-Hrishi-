using System;
using System.Collections.Generic;

class Account
{
    public int AccountNumber { get; }
    public string AccountHolder { get; }
    public decimal Balance { get; private set; }

    public Account(int accountNumber, string accountHolder, decimal initialBalance)
    {
        AccountNumber = accountNumber;
        AccountHolder = accountHolder;
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Deposited ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Withdrawn ${amount}. New balance: ${Balance}");
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
        }
    }

    public void CheckBalance()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolder}");
        Console.WriteLine($"Balance: ${Balance}");
    }
}

class Bank
{
    private List<Account> accounts = new List<Account>();

    public void CreateAccount(int accountNumber, string accountHolder, decimal initialBalance)
    {
        Account newAccount = new Account(accountNumber, accountHolder, initialBalance);
        accounts.Add(newAccount);
        Console.WriteLine($"Hi {accountHolder.Split(' ')[0]}. Your account was created successfully.");
    }

    public Account GetAccount(int accountNumber)
    {
        return accounts.Find(account => account.AccountNumber == accountNumber);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        // Creating accounts
        bank.CreateAccount(1001, "John Doe", 1000);
        bank.CreateAccount(1002, "Jane Smith", 1500);

        // Making transactions
        Account johnAccount = bank.GetAccount(1001);
        Account janeAccount = bank.GetAccount(1002);

        johnAccount.Deposit(500);
        johnAccount.Withdraw(200);
        johnAccount.CheckBalance();

        janeAccount.Deposit(1000);
        janeAccount.CheckBalance();
    }
}