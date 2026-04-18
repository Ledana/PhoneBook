using PhoneBook.Ledana;

var context = new ContactContext();
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
UserInterface.MainMenu();

