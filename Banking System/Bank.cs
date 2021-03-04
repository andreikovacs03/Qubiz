using System;
using Banking_System.Accounts;
using Banking_System.Enums;
using Banking_System.Structs;
using Banking_System.Cards;
using Banking_System.Interfaces;
using System.Collections.Generic;

namespace Banking_System
{
    class Bank
    {
        internal static List<ICustomer> Customers = new List<ICustomer>();

        static void Main(string[] args)
        {
            StudentAccount newStudentAccount = new StudentAccount("mihainan@qubiz.ro", "Strada Posadei", "secret", Currency.EUR);
            Name name = new Name { firstName = "Mihai", lastName = "Nan" };

            ICustomer Mihai = new Customer(name, newStudentAccount);

            ICard newCard = new GoldCard(name, CardService.MasterCard, "309");

            newStudentAccount = new StudentAccount("andreilunca@qubiz.ro", "Strada Mihai Eminescu", "secret2", Currency.RON);
            name = new Name { firstName = "Andrei", lastName = "Lunca" };

            ICustomer Lunca = new Customer(name, newStudentAccount);

            ICard newTitanCard = new TitanCard(name, CardService.Visa, "400");

            Lunca.SelectAccount(0).AddCard(newTitanCard);

            Mihai.SelectAccount(0).AddCard(newCard);

            Mihai.SelectAccount(0).Deposit(100);

            Mihai.SelectAccount(0).Withdraw(50);

            Console.WriteLine(Mihai.SelectAccount(0).Balance);

            IAccount transferAccount = Lunca.SelectAccount(0);

            Mihai.SelectAccount(0).Transfer(20, transferAccount);

            Console.WriteLine(Mihai.SelectAccount(0).Balance);

            Customers.Add(Mihai);
            Customers.Add(Lunca);

            Menu.Welcome();
            Menu.CreateAccount();

        }
    }
}
