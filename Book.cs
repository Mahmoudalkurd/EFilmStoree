namespace EBookStore.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }  // Se till att detta finns
        public Author Author { get; set; }
    }
}