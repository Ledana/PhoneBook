using PhoneBook.Ledana.Controllers;
using PhoneBook.Ledana.Models;
using Spectre.Console;

namespace PhoneBook.Ledana.Services
{
    internal class SMSService
    {
        internal static void SendSMS()
        {
            var sms = new SMS
            {
                Subject = AnsiConsole.Ask<string>("Subject:")
            };
            var contact = ContactService.GetContactOptionInput();
            if (contact is null)
            {
                Console.WriteLine("Contact empty");
                return;
            }
            sms.ContactId = contact.Id;
            SMSController.SendSMS(sms);
        }

        internal static void ViewSMSs()
        {
            var SMSs = SMSController.GetSMS();
            UserInterface.ViewSMSs(SMSs);
        }
    }
}
