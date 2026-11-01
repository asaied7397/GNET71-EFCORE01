using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class BookStoreContext : DbContext
{
    public BookStoreContext(
        DbContextOptions<BookStoreContext> options
    ) : base(options)
    {
    }

    public DbSet<Book> Books => Set<Book>();

    public DbSet<Author> Authors => Set<Author>();

    public DbSet<Category> Categories => Set<Category>();
}