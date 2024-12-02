using System;
using Phonebook.Controller;
using Phonebook.Model;

namespace Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactController contactController = new ContactController();
            Begin:
            Console.Write("Welcome! What do you want to do: \n" +
                              "1. Show contacts \n" +
                              "2. Add contact \n" +
                              "3. Update contact \n" +
                              "4. Remove contact \n" +
                              "5. Exit \n" +
                              "Enter choice: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                contactController.ShowData();
            }
            else if (choice == "2")
            {
                contactController.AddContact();
                goto Begin;
            }
            else if (choice == "3")
            {
                contactController.ShowData();
                contactController.UpdateContact();
            }
            else if (choice == "4")
            {
                contactController.ShowData();
                contactController.DeleteContact();
            }
            else if (choice == "5")
            {
                Console.Write("Process ended...");
            }
            else
            {
                Console.WriteLine("There is no this choice! Enter again!");
                goto Begin;
            }
        }
    }
}