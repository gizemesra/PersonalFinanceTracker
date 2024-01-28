using System;

class Program
{
    static void Main(string[] args)
    {
        TransactionManager manager = new TransactionManager();

        while (true)
        {
            Console.WriteLine("Personal Finance Tracker");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. List Transactions");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddTransaction(manager);
                    break;
                case "2":
                    ListTransactions(manager);
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddTransaction(TransactionManager manager)
    {
        Console.Write("Enter amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        manager.AddTransaction(amount, DateTime.Now, description);
    }

    static void ListTransactions(TransactionManager manager)
    {
        Console.WriteLine("Transactions:");
        manager.ListTransactions();
    }
}
