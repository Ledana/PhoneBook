using Microsoft.EntityFrameworkCore;
using PhoneBook.Ledana.Models;

namespace PhoneBook.Ledana.Controllers
{
    internal class CategoryController
    {
        internal static List<Category> GetCategories()
        {
            using var context = new ContactContext();
            var categories = context.Categories
                .Include(c => c.Contacts)
                .ToList();
            return categories;
        }
        internal static void AddCategory(Category category)
        {
            using var context = new ContactContext();
            context.Categories.Add(category);
            context.SaveChanges();
        }

        internal static void DeleteCategory(Category category)
        {
            using var context = new ContactContext();
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        internal static void UpdateCategory(Category category)
        {
            using var context = new ContactContext();
            context.Categories.Update(category);
            context.SaveChanges();
        }
    }
}
