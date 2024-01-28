using System;
using System.Collections.Generic;

public class TransactionManager
{
    private List<Transaction> transactions = new List<Transaction>();

    public void AddTransaction(decimal amount, DateTime date, string description)
    {
        transactions.Add(new Transaction(amount, date, description));
    }

    public void ListTransactions()
    {
        foreach (var transaction in transactions)
        {
            Console.WriteLine(transaction);
        }
    }
}
