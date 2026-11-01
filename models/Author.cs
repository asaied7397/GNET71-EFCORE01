namespace BookStore.Models;

public class Author
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Biography { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}