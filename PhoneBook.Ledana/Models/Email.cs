using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Ledana.Models
{
    internal class Email
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
    }
}
