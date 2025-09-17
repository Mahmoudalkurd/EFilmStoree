using AutoMapper;
using AutoMapper.QueryableExtensions;
using EBookStore.Data;
using EBookStore.DTOs;
using EBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EBookStore.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> GetAllAuthors()
        {
            return await _context.Authors
                .AsNoTracking()
                .ProjectTo<AuthorDto>(_mapper.ConfigurationProvider) // Använd AutoMappers ProjectTo
                .ToListAsync();
        }

        public async Task<AuthorDto> CreateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDto>(author);
        }
    }
}