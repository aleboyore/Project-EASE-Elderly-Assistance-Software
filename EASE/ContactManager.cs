using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EASE
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Category { get; set; }

        public void DisplayDetails()
        {
            Console.WriteLine("\tName : {0}\n\tPhone Number : {1}\n\tCategory: {2}\n", Name, PhoneNumber, Category);
        }
    }

    public class ContactManager
    {
        private List<Contact> contact = new List<Contact>();
        private List<string> phoneCategories = new List<string> { "Default" };

        public void AddContact(string name, string phoneNumber, string phoneCategory)
        {
            if (contact.Any(c => c.PhoneNumber.Equals(phoneNumber)))
            {
                Console.WriteLine("\n\tA contact with this phone number already exists.");
                return;
            }

            if (!phoneCategories.Contains(phoneCategory, StringComparer.OrdinalIgnoreCase))
            {
                phoneCategories.Add(phoneCategory);
            }

            Contact newContact = new Contact();

            newContact.Name = name;
            newContact.PhoneNumber = phoneNumber;
            newContact.Category = string.IsNullOrEmpty(phoneCategory) ? "Default" : phoneCategory;

            contact.Add(newContact);

            Console.WriteLine("\tContact added successfully...");
        }

        public void ViewContacts(string phoneCategory = null)
        {
            List<Contact> filteredContacts;

            if (string.IsNullOrEmpty(phoneCategory))
            {
                filteredContacts = contact;
                Console.WriteLine("\n\tAll Contacts:\n");
            }
            else
            {
                filteredContacts = contact.Where(contactList => contactList.Category.Equals(phoneCategory, StringComparison.OrdinalIgnoreCase)).ToList();

                Console.WriteLine("\n\tContacts in '{0}' Category:\n", phoneCategory);
            }

            if (filteredContacts.Count == 0)
            {
                Console.WriteLine("\n\tNo contacts available.");
                return;
            }

            foreach (var contactList in filteredContacts)
            {
                contactList.DisplayDetails();
            }
        }

        public void SearchContact(string name)
        {
            foreach (var contactList in contact)
            {
                if (contactList.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\tContact found: \n");
                    contactList.DisplayDetails();
                    return;
                }
            }
            Console.WriteLine("\n\tContact not found!");
        }

        public void UpdateContact(string name)
        {
            var contactToUpdate = contact.Find(contactList => contactList.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contactToUpdate == null)
            {
                Console.WriteLine("\n\tContact '{0}' not found!", name);
            }
            else
            {
                string newPhoneNumber = Validation.GetValidPhoneNumber("\tEnter contact phone number (e.g., 09XXXXXXXXX): ");
                contactToUpdate.PhoneNumber = newPhoneNumber;
                Console.WriteLine("\n\tContact '{0}' updated successfully!", name);
            }
        }

        public void DeleteContact(string name)
        {
            var contactToDelete = contact.Find(contactList => contactList.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (contactToDelete != null)
            {
                contact.Remove(contactToDelete);
                Console.WriteLine("\n\tContact '{0}' deleted successfully!", name);
            }
            else
            {
                Console.WriteLine("\n\tContact '{0}' not found!", name);
            }
        }

        public List<string> GetPhoneCategories()
        {
            return phoneCategories;
        }
    }

}
