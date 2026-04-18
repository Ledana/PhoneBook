# PhoneBook
# PhoneBook.Ledana 📖📱

## Overview
PhoneBook.Ledana is my first project built with **Entity Framework Core (EF Core)**.  
It’s a console-based phone book application that connects to a **SQL Server database**.  
The app allows users to manage contacts, send emails and SMS messages, and organize contacts into categories.

---

## Features
- **Contact Management**
  - Create contacts with first name, last name, email, phone number, and category (e.g., Family, Friends).
  - Phone numbers are **unique** — the app checks for duplicates before saving.
  - Input validation ensures emails and phone numbers match the correct format.

- **Messaging**
  - Send **emails** and **SMS messages** to contacts.
  - Messages are stored in their own tables (`Emails`, `SMSs`) with a `ContactId` foreign key linking them to the target contact.

- **Database**
  - Built with **EF Core** and SQL Server.
  - Tables: `Contacts`, `Categories`, `Emails`, `SMSs`.
  - Relationships enforced with foreign keys.
- - **Seeded data**: initial categories and contacts are inserted via `OnModelCreating`.
  - **Database lifecycle**: the database is deleted and recreated every time the app runs, ensuring a fresh state for testing and development.
  - **Query logging**: every SQL query executed by EF Core is printed to the console for transparency and debugging.

- **Console UI**
  - Uses **Spectre.Console** for rich console output (tables, prompts, etc.).

- **Testing**
  - Unit tests written with **NUnit**.
  - Tests cover validation methods (e.g., email and phone number format).

---

## Tech Stack
- **.NET 10.0**
- **Entity Framework Core**
- **SQL Server**
- **Spectre.Console**
- **NUnit**

---

