using System;
using System.Globalization;
using ExExceptions.Entities;
using ExExceptions.Entities.Exceptions;

namespace ExExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("HOW MANY ACCOUNTS YOU WISH TO DO? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter account number #{i} data");
                Console.Write("NUMBER: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("HOLDER: ");
                string holder = Console.ReadLine();
                Console.Write("INICIAL BALANCE: ");
                double deposit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("WITHDRAWLIMIT: ");
                double withdrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Account account = new Account(number, holder, deposit, withdrawLimit);
                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                try
                {
                    account.Withdraw(amount);
                    Console.WriteLine("New Balance: " + account.Balance.ToString("F2", CultureInfo.InvariantCulture));
                }
                catch (DomainException e)
                {
                    Console.WriteLine("Withdraw error: " + e.Message);
                }
            }
        }
    }
}
