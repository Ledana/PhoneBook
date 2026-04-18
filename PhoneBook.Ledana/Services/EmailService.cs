using PhoneBook.Ledana.Controllers;
using PhoneBook.Ledana.Models;
using Spectre.Console;

namespace PhoneBook.Ledana.Services
{
    internal class EmailService
    {
        internal static void SendEmail()
        {
            var email = new Email
            {
                Subject = AnsiConsole.Ask<string>("Subject:"),
                Body = AnsiConsole.Ask<string>("Body:")
            };
            var contact = ContactService.GetContactOptionInput();
            if (contact is null)
            {
                Console.WriteLine("Contact empty");
                return;
            }
            email.ContactId = contact.Id;
            EmailController.SendEmail(email);
        }
        internal static void ViewEmails()
        {
            var emails = EmailController.GetEmails();
            UserInterface.ViewEmails(emails);
        }
    }
}
