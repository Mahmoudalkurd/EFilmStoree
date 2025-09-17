using EBookStore.DTOs;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooks();
    Task<BookDto> CreateBook(BookDto bookDto);
    Task<List<BookDto>> GetBooksFiltered(string? filter, string? sortOrder);
}