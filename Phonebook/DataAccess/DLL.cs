using System.Data.SqlClient;
using System.Data.SqlTypes;
using Phonebook.Controller;
using Phonebook.Model;

namespace Phonebook.DataAccess;

public class DLL
{
    private string connectionString = "Data Source=mybestserver.database.windows.net;Database=PhoneBook;Integrated Security=false;User ID=dbadmin;Password=CodeWithZahra123;";
    List<Contact> contacts = new List<Contact>();
    public void AddContact(Contact contact)
    {
        string query = "INSERT INTO Contacts (Name, Surname, Phone, Email, Website) VALUES\n(@Name, @Surname, @Phone, @Email, @Website)";
            
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
           
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", contact.Name);
                    command.Parameters.AddWithValue("@Surname", contact.Surname);
                    command.Parameters.AddWithValue("@Phone", contact.Phone);
                    command.Parameters.AddWithValue("@Email", contact.Email);
                    command.Parameters.AddWithValue("@Website", contact.Website);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }

    public List<Contact> GetContacts()
    {
        string query = "SELECT*FROM Contacts";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                            
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ID"]);
                            string name = Convert.ToString(reader["Name"]);
                            string surname = Convert.ToString(reader["Surname"]);
                            string phone = Convert.ToString(reader["Phone"]);
                            string email = Convert.ToString(reader["Email"]);
                            string website = Convert.ToString(reader["Website"]);
                            
                            Contact contact = new Contact(name, surname, phone, email, website);
                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        return contacts;
    }

    public void UpdateContact(string phone, string prop, string newValue)
    {
        string query = "UPDATE Contacts\nSET @Property = '@Name'\nWHERE Phone = '@Phone'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Property", prop);
                    command.Parameters.AddWithValue("@Name", newValue);
                    command.Parameters.AddWithValue("@Phone", phone);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }

    public void DeleteContact(string phone)
    {
        string query = "DELETE Contacts WHERE Phone = '@phone'";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@phone", phone);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected>0)
                    {
                        Console.WriteLine("Successfully deleted!");
                    }
                    else
                    {
                        Console.WriteLine("The contact doesn't exist");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}