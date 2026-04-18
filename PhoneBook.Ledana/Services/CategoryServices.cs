using PhoneBook.Ledana.Controllers;
using PhoneBook.Ledana.Models;
using Spectre.Console;

namespace PhoneBook.Ledana.Services
{
    internal class CategoryServices
    {
        internal static void AddCategory()
        {
            var category = new Category
            {
                Name = AnsiConsole.Ask<string>("Category's name:")
            };
            CategoryController.AddCategory(category);
        }

        internal static void DeleteCategory()
        {
            Category category = GetCategoryOptionInput();
            if (category is null)
            {
                Console.WriteLine("Empty contact");
                return;
            }
            CategoryController.DeleteCategory(category);
        }

        internal static Category GetCategoryOptionInput()
        {
            List<Category> categories = CategoryController.GetCategories();
            if (categories.Count == 0)
            {
                Console.WriteLine("Categories list is empty");
                return null;
            }
            var categoriesArray = categories.Select(c => c.Name).ToArray();
            var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
                .Title("Choose category")
                .AddChoices(categoriesArray));
            var category = categories.SingleOrDefault(c => c.Name == option);
            return category;
        }

        internal static void UpdateCategory()
        {
            var category = GetCategoryOptionInput();
            if (category is null)
            {
                Console.WriteLine("Empty contact");
                return;
            }
            category.Name = AnsiConsole.Confirm("Update First Name?")
                ? AnsiConsole.Ask<string>("Contact's new first name")
                : category.Name;

            CategoryController.UpdateCategory(category);
        }

        internal static void ViewCategories()
        {
            var categories = CategoryController.GetCategories();
            UserInterface.ViewCategories(categories);
        }
    }
}
