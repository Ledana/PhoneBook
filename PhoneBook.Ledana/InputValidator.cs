using PhoneBook.Ledana.Controllers;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace PhoneBook.Ledana
{
    public static class InputValidator
    {
        public static string ValidateEmail()
        {
            var email = AnsiConsole.Ask<string>("Contact's email address(abc@abc.com):");

            while (!IsEmailValid(email))
            {
                email = AnsiConsole.Ask<string>("Invalid email, contact's email address(abc@abc.com):");
            }
            return email;
        }
        public static bool IsEmailValid(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }
        public static string ValidatePhoneNumber()
        {
            var phoneNumber = AnsiConsole.Ask<string>("Contact's phone number(+3556********):");

            while ((!IsNumberValid(phoneNumber))|| ContactController.ValidatePhoneNumber(phoneNumber))
            {
                if (ContactController.ValidatePhoneNumber(phoneNumber))
                    phoneNumber = AnsiConsole.Ask<string>("Phone number already exist, try again(+3556********):");
                else
                    phoneNumber = AnsiConsole.Ask<string>("Invalid phone number format, try again(+3556********):");
            }
            return phoneNumber;
        }
        public static bool IsNumberValid(string phoneNumber)
        {
            return phoneNumber.Length == 13
                && phoneNumber.StartsWith('+')
                && phoneNumber.Substring(1).All(char.IsDigit);
                //&& !ContactController.ValidatePhoneNumber(phoneNumber);
        }
    }
}
