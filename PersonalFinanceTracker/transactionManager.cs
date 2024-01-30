using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TransactionManager
{
    private List<Transaction> transactions = new List<Transaction>();
    private const string FilePath = "transactions.txt";

    public TransactionManager()
    {
        transactions = LoadTransactionsFromFile();
    }

    public void AddTransaction(decimal amount, DateTime date, string description, TransactionCategory category)
    {
        var transaction = new Transaction(amount, date, description, category);
        transactions.Add(transaction);
        SaveTransactionsToFile();
    }

    public void ListTransactions()
    {
        for (int i = 0; i < transactions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transactions[i]}");
        }
    }

    public void EditTransaction(int index, Transaction newTransaction)
    {
        if (index >= 0 && index < transactions.Count)
        {
            transactions[index] = newTransaction;
            SaveTransactionsToFile();
        }
    }

    public void DeleteTransaction(int index)
    {
        if (index >= 0 && index < transactions.Count)
        {
            transactions.RemoveAt(index);
            SaveTransactionsToFile();
        }
    }

    public void PrintSummaryByCategory()
    {
        var summary = transactions
            .GroupBy(t => t.Category)
            .Select(group => new { Category = group.Key, Total = group.Sum(t => t.Amount) });

        foreach (var entry in summary)
        {
            Console.WriteLine($"{entry.Category}: {entry.Total:C2}");
        }
    }

    private List<Transaction> LoadTransactionsFromFile()
    {
        var transactions = new List<Transaction>();
        if (File.Exists(FilePath))
        {
            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split('|');
                var transaction = new Transaction(
                    decimal.Parse(parts[0]),
                    DateTime.Parse(parts[1]),
                    parts[2],
                    (TransactionCategory)Enum.Parse(typeof(TransactionCategory), parts[3])
                );
                transactions.Add(transaction);
            }
        }
        return transactions;
    }

    private void SaveTransactionsToFile()
    {
        using (var writer = new StreamWriter(FilePath, false))
        {
            foreach (var transaction in transactions)
            {
                var line = $"{transaction.Amount}|{transaction.Date}|{transaction.Description}|{transaction.Category}";
                writer.WriteLine(line);
            }
        }
    }
}
