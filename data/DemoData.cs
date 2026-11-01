using BookStore.Models;

namespace BookStore.Data;

public static class DemoData
{
    public static void Seed(BookStoreContext context)
    {
        var author = new Author
        {
            FirstName = "Robert",
            LastName = "Martin",
            Email = "robert.martin@example.com",
            Biography = "Software development author.",
            DateOfBirth = new DateOnly(1952, 12, 5)
        };

        var category = new Category
        {
            Name = "Software Development",
            Description = "Books about software engineering.",
            IsActive = true
        };

        var book = new Book
        {
            Title = "Clean Code",
            ISBN = "9780132350884",
            Price = 45.99m,
            NumberOfPages = 464,
            PublishedYear = 2008,
            IsInStock = true,

            Author = author,
            Category = category
        };

        context.Books.Add(book);
        context.SaveChanges();
    }
}