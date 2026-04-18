using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers
{
    internal class SMSController
    {
        internal static List<SMS> GetSMS()
        {
            using var context = new ContactContext();
            var SMSs = context.SMSs
                .Include(s => s.Contact)
                .ToList();
            return SMSs;
        }

        internal static void SendSMS(SMS sms)
        {
            using var context = new ContactContext();
            context.SMSs.Add(sms);
            context.SaveChanges();
        }
    }
}
