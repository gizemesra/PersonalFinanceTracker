using System;

public class Transaction
{
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Transaction(decimal amount, DateTime date, string description)
    {
        Amount = amount;
        Date = date;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()} - {Amount:C2} - {Description}";
    }
}
