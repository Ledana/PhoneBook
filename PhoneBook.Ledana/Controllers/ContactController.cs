using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers
{
    internal class ContactController
    {
        internal static void AddContact(Contact contact)
        {
            using var context = new ContactContext();
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        internal static void DeleteContact(Contact contact)
        {
            using var context = new ContactContext();
            context.Contacts.Remove(contact);
            context.SaveChanges();
        }

        internal static List<Contact> GetAllContacts()
        {
            using var context = new ContactContext();
            var contacts = context.Contacts.Include(c => c.Category)
                .ToList();
            return contacts;
        }

        internal static void UpdateContact(Contact contact)
        {
            using var context = new ContactContext();
            context.Contacts.Update(contact);
            context.SaveChanges();
        }
        internal static bool ValidatePhoneNumber(string phoneNumber)
        {
            using var context = new ContactContext();
            var phoneNumberExists = context.Contacts.Where(c => c.PhoneNumber == phoneNumber).Count();
            return phoneNumberExists > 0;
        }
    }
}
