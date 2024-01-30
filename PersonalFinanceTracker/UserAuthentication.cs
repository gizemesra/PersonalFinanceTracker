using System;

public class UserAuthentication
{
    private const string Username = "user";
    private const string Password = "pass";

    public bool Login()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();
        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        return username == Username && password == Password;
    }
}
