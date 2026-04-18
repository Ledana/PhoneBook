using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Ledana
{
    internal class Enums
    {
        internal enum MenuOptions
        {
            ManageContacts,
            ManageCategories,
            ManageEmails,
            ManageSMSs,
            Quit
        }
        internal enum ContactOptions
        {
            AddContact,
            DeleteContact,
            UpdateContact,
            ViewContact,
            ViewAllContacts,
            GoBack
        }
        internal enum CategoryOptions
        {
            AddCategory,
            DeleteCategory,
            UpdateCategory,
            ViewCategories,
            GoBack
        }
        internal enum EmailOptions
        {
            SendEmail,
            ViewEmails,
            GoBack
        }
        internal enum SMSOptions
        {
            SendSMS,
            ViewSMSs,
            GoBack
        }
    }
}
