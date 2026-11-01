namespace BookStore.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string ISBN { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int NumberOfPages { get; set; }

    public int PublishedYear { get; set; }

    public bool IsInStock { get; set; }

    // Author relationship
    public int AuthorId { get; set; }

    public Author Author { get; set; } = null!;

    // Category relationship
    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;
}