using PhoneBook.Ledana.Controllers;
using PhoneBook.Ledana.Models;
using Spectre.Console;

namespace PhoneBook.Ledana.Services
{
    internal class ContactService
    {
        internal static void AddContact()
        {
            var contact = new Contact
            {
                FirstName = AnsiConsole.Ask<string>("Contact's first name:"),
                LastName = AnsiConsole.Ask<string>("Contact's last name:"),
                Email = InputValidator.ValidateEmail(),
                PhoneNumber = InputValidator.ValidatePhoneNumber()
            };
            var category = CategoryServices.GetCategoryOptionInput();
            contact.CategoryId = category.Id;
            ContactController.AddContact(contact);
        }

        internal static void DeleteContact()
        {
            var contact = GetContactOptionInput();
            if (contact is null)
            {
                Console.WriteLine("Empty contact");
                return;
            }
            ContactController.DeleteContact(contact);
        }

        internal static void UpdateContact()
        {
            var contact = GetContactOptionInput();
            if (contact is null)
            {
                Console.WriteLine("Empty contact");
                return;
            }
            contact.FirstName = AnsiConsole.Confirm("Update First Name?")
                ? AnsiConsole.Ask<string>("Contact's new first name")
                : contact.FirstName;
            contact.LastName = AnsiConsole.Confirm("Update Last Name?")
                ? AnsiConsole.Ask<string>("Contact's new last name")
                : contact.LastName;
            contact.Email = AnsiConsole.Confirm("Update Email?")
                ? InputValidator.ValidateEmail()
                : contact.Email;
            contact.PhoneNumber = AnsiConsole.Confirm("Update Phone Number?")
                ? InputValidator.ValidatePhoneNumber()
                : contact.PhoneNumber;
            var category = CategoryServices.GetCategoryOptionInput();
            contact.CategoryId = category.Id;
            ContactController.UpdateContact(contact);
        }

        internal static void ViewContact()
        {
            var contact = GetContactOptionInput();
            if (contact is null)
            {
                Console.WriteLine("Empty contact");
                return;
            }
            UserInterface.ViewContact(contact);
        }

        internal static void ViewContacts()
        {
            var contacts = ContactController.GetAllContacts();
            UserInterface.ViewContacts(contacts);
        }

        internal static Contact? GetContactOptionInput()
        {
            List<Contact> contacts = ContactController.GetAllContacts();
            if (contacts.Count == 0)
            {
                Console.WriteLine("Contact list is empty");
                return null;
            }
            var contactsArray = contacts.Select(c => $"{c.FirstName} {c.LastName}").ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose contact")
                .AddChoices(contactsArray));
            var contact = contacts.SingleOrDefault(c => $"{c.FirstName} {c.LastName}" == option);
            return contact;
        }
    }
}
