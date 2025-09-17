using AutoMapper;
using AutoMapper.QueryableExtensions;
using EBookStore.Data;
using EBookStore.DTOs;
using EBookStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EBookStore.Services
{
    public class BookService : IBookService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Befintliga metoder
        public async Task<List<BookDto>> GetAllBooks()
        {
            return await _context.Books
                .Include(b => b.Author)
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BookDto> CreateBook(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDto>(book);
        }

        // NY: Filtrering & sortering
        public async Task<List<BookDto>> GetBooksFiltered(string? filter, string? sortOrder)
        {
            var query = _context.Books
                .Include(b => b.Author)
                .AsQueryable();

            // Filtrering
            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(b => b.Title.Contains(filter) ||
                                     b.Author.Name.Contains(filter));
            }

            // Sortering
            query = (sortOrder?.ToLower() == "desc")
                ? query.OrderByDescending(b => b.Title)
                : query.OrderBy(b => b.Title);

            return await query
                .ProjectTo<BookDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}