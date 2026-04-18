using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana
{
    internal class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<SMS> SMSs { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("ContactsDb");

            optionsBuilder.UseSqlServer(connectionString)
                .EnableSensitiveDataLogging()
                .UseLoggerFactory(GetLoggerFactory());
        }
        private ILoggerFactory? GetLoggerFactory()
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name &&
                level == LogLevel.Information);
            });
            return loggerFactory;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasData(new List<Contact>
                {
                    new() {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Dylan",
                        Email = "dylan12@abc.com",
                        PhoneNumber = "+355691234567",
                        CategoryId = 1
                    },
                    new() {
                        Id = 2,
                        FirstName = "Amelia",
                        LastName = "Aster",
                        Email = "aster12@abc.com",
                        PhoneNumber = "+355691234123",
                        CategoryId = 2
                    },
                    new() {
                        Id = 3,
                        FirstName = "Loredana",
                        LastName = "Marti",
                        Email = "marti12@abc.com",
                        PhoneNumber = "+355694564567",
                        CategoryId = 1
                    },
                    new() {
                        Id = 4,
                        FirstName = "Luiza",
                        LastName = "Griffin",
                        Email = "griffin12@abc.com",
                        PhoneNumber = "+355691201467",
                        CategoryId = 3
                    },
                    new() {
                        Id = 5,
                        FirstName = "Daniel",
                        LastName = "Scott",
                        Email = "scott12@abc.com",
                        PhoneNumber = "+355690230123",
                        CategoryId = 3
                    },
                    new() {
                        Id = 6,
                        FirstName = "Vivian",
                        LastName = "DeMarti",
                        Email = "demarti12@abc.com",
                        PhoneNumber = "+355694064061",
                        CategoryId = 1
                    }
                });
            modelBuilder.Entity<Category>()
                .HasData(new List<Category>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Family"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Friends"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Work"
                    }
                });

            modelBuilder.Entity<Email>()
                .HasData(new List<Email>
                {
                    new()
                    {
                        Id = 1,
                        Subject = "Urgent",
                        Body = "Please call me ASAP",
                        ContactId = 4
                    },
                    new()
                    {
                        Id = 2,
                        Subject = "Party time",
                        Body = "When should we be at the party?",
                        ContactId = 1
                    },
                    new()
                    {
                        Id = 3,
                        Subject = "Project boy",
                        Body = "We will have a meeting about the project Friday at noon",
                        ContactId = 2
                    }
                });

            modelBuilder.Entity<SMS>()
                .HasData(new List<SMS>
                {
                    new()
                    {
                        Id = 1,
                        Subject = "Call me when you can",
                        ContactId = 3
                    },
                    new()
                    {
                        Id = 2,
                        Subject = "I just left work, I'll be home in 10",
                        ContactId = 2
                    },
                    new()
                    {
                        Id = 3,
                        Subject = "Stop calling me!!!! :)",
                        ContactId = 5
                    }
                });
        }
    }

    
}
