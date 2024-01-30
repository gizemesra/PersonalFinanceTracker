using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        UserAuthentication auth = new UserAuthentication();
        if (!auth.Login())
        {
            Console.WriteLine("Authentication failed!");
            return;
        }

        TransactionManager manager = new TransactionManager();

        while (true)
        {
            Console.WriteLine("\nPersonal Finance Tracker");
            Console.WriteLine("1. Add Transaction");
            Console.WriteLine("2. List Transactions");
            Console.WriteLine("3. Edit Transaction");
            Console.WriteLine("4. Delete Transaction");
            Console.WriteLine("5. Summary by Category");
            Console.WriteLine("6. Exit");
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
                    EditTransaction(manager);
                    break;
                case "4":
                    DeleteTransaction(manager);
                    break;
                case "5":
                    manager.PrintSummaryByCategory();
                    break;
                case "6":
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
        decimal amount = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Select a category:");
        foreach (var category in Enum.GetValues(typeof(TransactionCategory)))
        {
            Console.WriteLine($"- {category}");
        }
        Console.Write("Category: ");
        TransactionCategory selectedCategory = (TransactionCategory)Enum.Parse(typeof(TransactionCategory), Console.ReadLine());

        manager.AddTransaction(amount, DateTime.Now, description, selectedCategory);
    }

    static void ListTransactions(TransactionManager manager)
    {
        Console.WriteLine("\nTransactions:");
        manager.ListTransactions();
    }

    static void EditTransaction(TransactionManager manager)
    {
        ListTransactions(manager);
        Console.Write("Enter the transaction number to edit: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        Console.Write("Enter new amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Enter new description: ");
        string description = Console.ReadLine();

        Console.WriteLine("Select a new category:");
        foreach (var category in Enum.GetValues(typeof(TransactionCategory)))
        {
            Console.WriteLine($"- {category}");
        }
        Console.Write("New category: ");
        TransactionCategory selectedCategory = (TransactionCategory)Enum.Parse(typeof(TransactionCategory), Console.ReadLine());

        Transaction newTransaction = new Transaction(amount, DateTime.Now, description, selectedCategory);
        manager.EditTransaction(index, newTransaction);
    }

    static void DeleteTransaction(TransactionManager manager)
    {
        ListTransactions(manager);
        Console.Write("Enter the transaction number to delete: ");
        int index = Convert.ToInt32(Console.ReadLine()) - 1;

        manager.DeleteTransaction(index);
    }
}
