using EBookStore.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EBookStore.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorDto>> GetAllAuthors();
        Task<AuthorDto> CreateAuthor(AuthorDto authorDto);
    }
}