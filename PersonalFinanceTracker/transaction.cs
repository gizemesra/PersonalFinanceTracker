using System;

public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
    public TransactionCategory Category { get; set; }

    public Transaction(decimal amount, DateTime date, string description, TransactionCategory category)
    {
        Amount = amount;
        Date = date;
        Description = description;
        Category = category;
    }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Amount:C2} - {Description} - {Category}";
    }
}
