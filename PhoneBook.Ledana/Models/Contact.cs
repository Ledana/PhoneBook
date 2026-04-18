using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Ledana.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    internal class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Email> Emails { get; set; } = [];
        public List<SMS> SMSs { get; set; } = [];
    }
}
