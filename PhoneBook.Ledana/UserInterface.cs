using PhoneBook.Ledana.Models;
using PhoneBook.Ledana.Services;
using Spectre.Console;
using static PhoneBook.Ledana.Enums;

namespace PhoneBook.Ledana
{
    internal class UserInterface
    {
        internal static void MainMenu()
        {
            var isAppRunning = true;
            while (isAppRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        MenuOptions.ManageContacts,
                        MenuOptions.ManageCategories,
                        MenuOptions.ManageEmails,
                        MenuOptions.ManageSMSs,
                        MenuOptions.Quit));

                switch (option)
                {
                    case MenuOptions.ManageContacts:
                        ContactsMenu();
                        break;
                    case MenuOptions.ManageCategories:
                        CategoriesMenu();
                        break;
                    case MenuOptions.ManageEmails:
                        EmailsMenu(); 
                        break;
                    case MenuOptions.ManageSMSs:
                        SMSsMenu();
                        break;
                    case MenuOptions.Quit:
                        Console.WriteLine("Goodbye");
                        isAppRunning = false;
                        break;
                }
            }
        }

        private static void SMSsMenu()
        {
            var isSMSsMenuRunning = true;
            while (isSMSsMenuRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<SMSOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        SMSOptions.SendSMS,
                        SMSOptions.ViewSMSs,
                        SMSOptions.GoBack
                        ));

                switch (option)
                {
                    case SMSOptions.SendSMS:
                        SMSService.SendSMS();
                        break;
                    case SMSOptions.ViewSMSs:
                        SMSService.ViewSMSs();
                        break;
                    case SMSOptions.GoBack:
                        isSMSsMenuRunning = false;
                        break;
                }
            }
        }

        private static void EmailsMenu()
        {
            var isEmailsMenuRunning = true;
            while (isEmailsMenuRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<EmailOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        EmailOptions.SendEmail,
                        EmailOptions.ViewEmails,
                        EmailOptions.GoBack
                        ));

                switch (option)
                {
                    case EmailOptions.SendEmail:
                        EmailService.SendEmail();
                        break;
                    case EmailOptions.ViewEmails:
                        EmailService.ViewEmails();
                        break;
                    case EmailOptions.GoBack:
                        isEmailsMenuRunning = false;
                        break;
                }
            }
        }

        private static void CategoriesMenu()
        {
            var isCategoriesMenuRunning = true;
            while (isCategoriesMenuRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<CategoryOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        CategoryOptions.AddCategory,
                        CategoryOptions.DeleteCategory,
                        CategoryOptions.UpdateCategory,
                        CategoryOptions.ViewCategories,
                        CategoryOptions.GoBack
                        ));

                switch (option)
                {
                    case CategoryOptions.AddCategory:
                        CategoryServices.AddCategory();
                        break;
                    case CategoryOptions.DeleteCategory:
                        CategoryServices.DeleteCategory();
                        break;
                    case CategoryOptions.UpdateCategory:
                        CategoryServices.UpdateCategory();
                        break;
                    case CategoryOptions.ViewCategories:
                        CategoryServices.ViewCategories();
                        break;
                    case CategoryOptions.GoBack:
                        isCategoriesMenuRunning = false;
                        break;
                }
            }
        }

        private static void ContactsMenu()
        {
            var isContactsMenuRunning = true;
            while (isContactsMenuRunning)
            {
                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<ContactOptions>()
                    .Title("What do you want to do?")
                    .AddChoices(
                        ContactOptions.AddContact,
                        ContactOptions.DeleteContact,
                        ContactOptions.UpdateContact,
                        ContactOptions.ViewContact,
                        ContactOptions.ViewAllContacts,
                        ContactOptions.GoBack
                        ));

                switch (option)
                {
                    case ContactOptions.AddContact:
                        ContactService.AddContact();
                        break;
                    case ContactOptions.DeleteContact:
                        ContactService.DeleteContact();
                        break;
                    case ContactOptions.UpdateContact:
                        ContactService.UpdateContact();
                        break;
                    case ContactOptions.ViewContact:
                        ContactService.ViewContact();
                        break;
                    case ContactOptions.ViewAllContacts:
                        ContactService.ViewContacts();
                        break;
                    case ContactOptions.GoBack:
                        isContactsMenuRunning = false;
                        break;
                }
            }
        }

        internal static void ViewContact(Contact contact)
        {
            var panel = new Panel($@"Id: {contact.Id}
First Name: {contact.FirstName}
Last Name: {contact.LastName}
Email Address: {contact.Email}
Phone Number: {contact.PhoneNumber}
Category: {contact.Category.Name}")
            {
                Header = new PanelHeader("Contact's Info"),
                Padding = new Padding(2, 2, 2, 2)
            };
            AnsiConsole.Write(panel);
            Console.WriteLine("Press anything to continue");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ViewContacts(List<Contact> contacts)
        {
            var table = new Spectre.Console.Table();
            table.AddColumn("Id");
            table.AddColumn("First Name");
            table.AddColumn("Last Name");
            table.AddColumn("Email Address");
            table.AddColumn("Phone Number");
            table.AddColumn("Category");
            foreach (var item in contacts)
            {
                table.AddRow(item.Id.ToString(), item.FirstName,
                    item.LastName, item.Email
                    , item.PhoneNumber, item.Category.Name);
            }
            AnsiConsole.Write(table);
            Console.WriteLine("Press anything to continue");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ViewCategories(List<Category> categories)
        {
            var table = new Spectre.Console.Table();
            table.AddColumn("Id");
            table.AddColumn("Name");
            foreach (var item in categories)
            {
                table.AddRow(item.Id.ToString(), item.Name);
            }
            AnsiConsole.Write(table);
            Console.WriteLine("Press anything to continue");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ViewEmails(List<Email> emails)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Subject");
            table.AddColumn("Body");
            table.AddColumn("Sent to");
            foreach (var item in emails)
            {
                table.AddRow(item.Id.ToString(), item.Subject, item.Body, $"{item.Contact.FirstName} {item.Contact.LastName}");
            }
            AnsiConsole.Write(table);
            Console.WriteLine("Press anything to continue");
            Console.ReadLine();
            Console.Clear();
        }

        internal static void ViewSMSs(List<SMS> SMSs)
        {
            var table = new Table();
            table.AddColumn("Id");
            table.AddColumn("Subject");
            table.AddColumn("Sent to");
            foreach (var item in SMSs)
            {
                table.AddRow(item.Id.ToString(), item.Subject, $"{item.Contact.FirstName} {item.Contact.LastName}");
            }
            AnsiConsole.Write(table);
            Console.WriteLine("Press anything to continue");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
