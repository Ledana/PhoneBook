using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.Ledana.Models
{
    internal class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<Contact> Contacts { get; set; } = [];
    }
}
