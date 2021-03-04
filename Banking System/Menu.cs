using System;
using System.Collections.Generic;
using Banking_System.Interfaces;
using Banking_System.Cards;
using Banking_System.Structs;
using Banking_System.Enums;
using System.Linq;
using System.Runtime.InteropServices;
using Banking_System.Accounts;

namespace Banking_System
{
    internal static class Menu
    {
        static Dictionary<AccountType, Action<Name, string, string, string, Currency>> AccountCreator = new Dictionary<AccountType, Action<Name, string, string, string, Currency>>()
        {
            {
                AccountType.StandardAccount, (name, email, address, password, currency) => 
                    Bank.Customers.Add(new Customer(name, new StandardAccount(email, address, password, currency)))
            },

            {
                AccountType.StudentAccount, (name, email, address, password, currency) => 
                    Bank.Customers.Add(new Customer(name, new StudentAccount(email, address, password, currency)))
            },

            {
                AccountType.EnterpriseAccount, (name, email, address, password, currency) => 
                    Bank.Customers.Add(new Customer(name, new EnterpriseAccount(email, address, password, currency)))
            },
        };

        internal static List<Action> Options = new List<Action>()
        {
            Welcome,
            CreateAccount
        };

        internal static void Welcome()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Welcome to FutureBank!");
            Console.WriteLine();
            Console.ResetColor();
        }

        internal static void ListOptions()
        {
            Console.WriteLine("What would you like to do?");
        }

        internal static void CreateAccount()
        {
            var name = new Name();
            Console.WriteLine("What is your first name?");
            name.firstName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("What is your last name?");
            name.lastName = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("What is your email?");
            var email = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("What is your address?");
            var address = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("What is your desired currency?");
            ListCurrencies();
            Currency currency = (Currency)Enum.Parse(typeof(Currency), Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("What type of account would you like?");
            ListAccountTypes();
            AccountType accountType = (AccountType)Enum.Parse(typeof(AccountType), Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Set a password for your account: ");
            var password = Console.ReadLine();
            Console.WriteLine();

            if(!AccountCreator.ContainsKey(accountType))
                throw new NotImplementedException($"Account type {accountType} not implemented.");

            AccountCreator[accountType](name, email, address, password, currency);

            Console.WriteLine("You successfully created a new account.");
            Console.WriteLine();
        }

        internal static void ListAccountTypes()
        {
            var accountTypes = Enum.GetValues(typeof(AccountType));
            foreach (var accountType in accountTypes)
                Console.Write($"{accountType} ");
            Console.WriteLine();
        }

        internal static void ListCurrencies()
        {
            var currencies = Enum.GetValues(typeof(Currency));
            foreach (var currency in currencies)
                Console.Write($"{currency} ");
            Console.WriteLine();
        }

    }
}
