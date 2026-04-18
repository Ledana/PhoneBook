using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers
{
    internal class EmailController
    {
        internal static void SendEmail(Email email)
        {
            using var context = new ContactContext();
            context.Emails.Add(email);
            context.SaveChanges();
        }
        internal static List<Email> GetEmails()
        {
            using var context = new ContactContext();
            var emails = context.Emails
                .Include(e => e.Contact)
                .ToList();
            return emails;
        }
    }
}
