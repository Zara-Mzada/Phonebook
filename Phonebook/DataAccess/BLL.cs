using System.Text.RegularExpressions;
using Phonebook.Model;

namespace Phonebook.DataAccess;

public class BLL
{
    private DLL datalogiclayer;

    public BLL()
    {
        this.datalogiclayer = new DLL();
    }

    string nameRegex = "^[a-zA-Z]+$";
    string phoneRegex = @"^\+994 \(\d{2}\) \d{3} \d{2} \d{2}$";
    string emailRegex = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    string websiteRegex = @"^(http(s)?:\/\/)?(www\.)?[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(/.*)?$";

    
    public int CheckContact(Contact contact)
    {
        if (Regex.IsMatch(contact.Name, nameRegex))
        {
            if (Regex.IsMatch(contact.Surname, nameRegex))
            {
                if (Regex.IsMatch(contact.Phone, phoneRegex))
                {
                    if (Regex.IsMatch(contact.Email, emailRegex) || contact.Email == "")
                    {
                        if (Regex.IsMatch(contact.Website, websiteRegex) || contact.Website == "")
                        {
                            datalogiclayer.AddContact(contact);
                            return 6;
                        }
                        else
                        {
                            return 5;
                        }
                    }
                    else
                    {
                        return 4;
                    }
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }
        }
        else
        {
            return 1;
        }
    }

    public List<Contact> GetContact()
    {
        return datalogiclayer.GetContacts();
    }

    public bool UpdateContact(string phone, string prop, string newValue)
    {
        if (prop == "Name")
        {
            if (Regex.IsMatch(newValue, nameRegex))
            {
                datalogiclayer.UpdateContact(phone, prop, newValue);
            }
            else
            {
                Console.WriteLine("Name format is wrong!");
                return false;
            }
        }
        else if (prop == "Surname")
        {
            if (Regex.IsMatch(newValue, nameRegex))
            {
                datalogiclayer.UpdateContact(phone, prop, newValue);
            }
            else
            {
                Console.WriteLine("Surname format is wrong!");
                return false;
            }
        }
        else if (prop == "Phone")
        {
            if (Regex.IsMatch(newValue, phoneRegex))
            {
                datalogiclayer.UpdateContact(phone, prop, newValue);
            }
            else
            {
                Console.WriteLine("Phone format is wrong!");
                return false;
            }
        }
        else if (prop == "Email")
        {
            if (Regex.IsMatch(newValue, emailRegex))
            {
                datalogiclayer.UpdateContact(phone, prop, newValue);
            }
            else
            {
                Console.WriteLine("Email format is wrong!");
                return false;
            }
        }
        else if (prop == "Website")
        {
            if (Regex.IsMatch(newValue, websiteRegex))
            {
                datalogiclayer.UpdateContact(phone, prop, newValue);
            }
            else
            {
                Console.WriteLine("Website format is wrong!");
                return false;
            }
        }

        return false;
    }

    public void DeleteContact(string phone)
    {
        datalogiclayer.DeleteContact(phone);
    }
    
}