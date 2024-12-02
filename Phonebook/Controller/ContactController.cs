using System.Reflection.Emit;
using Phonebook.DataAccess;
using Phonebook.Model;

namespace Phonebook.Controller;

public class ContactController
{
    private BLL businesslogiclayer;

    public ContactController()
    {
        this.businesslogiclayer = new BLL();
    }

    public void AddContact()
    {
        label1:
        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        label2:
        Console.Write("Enter surname: ");
        string surname = Console.ReadLine();
        label3:
        Console.Write("Enter phone: ");
        string phone = Console.ReadLine();
        label4:
        Console.Write("Enter email: ");
        string email = Console.ReadLine();
        label5:
        Console.Write("Enter website: ");
        string website = Console.ReadLine();

        Contact contact = new Contact(name, surname, phone, email, website);

        int check = businesslogiclayer.CheckContact(contact);
        if (check == 1)
        {
            Console.WriteLine("Name format is wrong!");
            goto label1;
        }
        else if (check == 2)
        {
            Console.WriteLine("Surname format is wrong!");
            goto label2;
        }
        else if (check == 3)
        {
            Console.WriteLine("Phone format is wrong!");
            goto label3;
        }
        else if (check == 4)
        {
            Console.WriteLine("Email format is wrong!");
            goto label4;
        }
        else if (check == 5)
        {
            Console.WriteLine("Website format is wrong!");
            goto label5;
        }
    }

    public void ShowData()
    {
        List<Contact> contacts = businesslogiclayer.GetContact();
        for (int i = 0; i < contacts.Count - 1; i++)
        {
            Console.WriteLine($"Name: {contacts[i].Name} \n" +
                              $"Surname: {contacts[i].Surname} \n" +
                              $"Phone: {contacts[i].Phone} \n" +
                              $"Email: {contacts[i].Email} \n" +
                              $"Website: {contacts[i].Website} \n" +
                              $"==============================");
        }

    }

    public void UpdateContact()
    {
        ReNum:
        Console.Write("Which contact do you want to update, give number: ");
        string number = Console.ReadLine();
        List<Contact> contacts = businesslogiclayer.GetContact();
        bool found = false;
        
        foreach (Contact contact in contacts)
        {
            if (contact.Phone == number)
            {
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Number doesn't exist! Enter again!");
            goto ReNum;
        }


        BegUp:
            Console.Write("Which property do you want to update:\n" +
                          "1. Name \n" +
                          "2. Surname \n" +
                          "3. Phone \n" +
                          "4. Email \n" +
                          "5. Website \n" +
                          "Enter your choice: ");
            string choice = Console.ReadLine();
            if (choice == "1")
            {
                string prop = "Name";
                ReName:
                Console.Write("Write new name: ");
                string newName = Console.ReadLine();
                if (!businesslogiclayer.UpdateContact(number, prop, newName))
                    goto ReName;
            }
            else if (choice == "2")
            {
                string prop = "Surname";
                ReSurname:
                Console.Write("Write new surname: ");
                string newSurname = Console.ReadLine();
                if (!businesslogiclayer.UpdateContact(number, prop, newSurname))
                    goto ReSurname;
            }
            else if (choice == "3")
            {
                string prop = "Phone";
                RePhone:
                Console.Write("Write new phone: ");
                string newPhone = Console.ReadLine();
                if (!businesslogiclayer.UpdateContact(number, prop, newPhone))
                    goto RePhone;
            }
            else if (choice == "4")
            {
                string prop = "Email";
                ReEmail:
                Console.Write("Write new email: ");
                string newEmail = Console.ReadLine();
                if (!businesslogiclayer.UpdateContact(number, prop, newEmail))
                    goto ReEmail;
            }
            else if (choice == "5")
            {
                string prop = "Website";
                ReWeb:
                Console.Write("Write new website: ");
                string newWebsite = Console.ReadLine();
                if (!businesslogiclayer.UpdateContact(number, prop, newWebsite))
                    goto ReWeb;
            }
            else
            {
                Console.WriteLine("There is no this choice! Enter again!");
                goto BegUp;
            }
    }

    public void DeleteContact()
    {
        ReNum:
        Console.Write("Which contact do you want delete, give me number: ");
        string number = Console.ReadLine();
        List<Contact> contacts = businesslogiclayer.GetContact();
        bool found = false;
        
        foreach (Contact contact in contacts)
        {
            if (contact.Phone == number)
            {
                businesslogiclayer.DeleteContact(number);
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Number doesn't exist! Enter again!");
            goto ReNum;
        }
        
    }
}