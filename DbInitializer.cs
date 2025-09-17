using Bogus;
using EBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Data
{
    public static class DbInitializer
    {

        public static void Initialize(AppDbContext context)
        {
            if (context.Books.Any()) return;

           

            var authors = new List<Author>
{
    new() { Name = "J.K. Rowling" },
    new() { Name = "Stephen King" }
};

            var books = new List<Book>
{
    new Book { BookId = 1, Title = "Harry Potter", Price = 299, AuthorId = 1 },
    new Book { BookId = 2, Title = "The Shining", Price = 199, AuthorId = 2 }
};

            
            context.Authors.AddRange(authors);
            context.Books.AddRange(books);
            context.SaveChanges();
        }

    }

}