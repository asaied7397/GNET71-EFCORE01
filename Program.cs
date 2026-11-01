using BookStore.Data;
using Microsoft.EntityFrameworkCore;

string? connectionString = Environment.GetEnvironmentVariable("BOOKSTORE_CONNECTION_STRING");

if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.Error.WriteLine("Set BOOKSTORE_CONNECTION_STRING before running the application.");
    return 1;
}

var options = new DbContextOptionsBuilder<BookStoreContext>()
    .UseSqlServer(connectionString)
    .Options;
try
{
    using var context = new BookStoreContext(options);
    bool schemaCreated = context.Database.EnsureCreated();
    if (schemaCreated)
    {
        Console.WriteLine("Database schema created successfully.");
        DemoData.Seed(context);
        Console.WriteLine("Sample data added successfully.");
    }
    else
    {
        Console.WriteLine("Database already has tables; sample data was not added.");
    }

    var books = context.Books
        .Include(book => book.Author)
        .Include(book => book.Category)
        .OrderBy(book => book.Id)
        .ToList();

    Console.WriteLine();
    Console.WriteLine("===== Books =====");

    foreach (var book in books)
    {
        Console.WriteLine($"Id: {book.Id}");
        Console.WriteLine($"Title: {book.Title}");
        Console.WriteLine($"ISBN: {book.ISBN}");
        Console.WriteLine($"Price: {book.Price:F2}");
        Console.WriteLine($"Pages: {book.NumberOfPages}");
        Console.WriteLine($"Published Year: {book.PublishedYear}");
        Console.WriteLine($"In Stock: {book.IsInStock}");
        Console.WriteLine($"Author: {book.Author.FirstName} {book.Author.LastName}");
        Console.WriteLine($"Category: {book.Category.Name}");
        Console.WriteLine("-----------------------------");
    }

    if (books.Count == 0)
    {
        Console.WriteLine("No books found.");
    }

    Console.WriteLine();
    Console.WriteLine($"Authors: {context.Authors.Count()}");
    Console.WriteLine($"Categories: {context.Categories.Count()}");
    Console.WriteLine($"Books: {books.Count}");
    return 0;
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Database operation failed: {ex.Message}");
    return 1;
}