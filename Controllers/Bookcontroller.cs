using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EBookStore.Data;
using EBookStore.Models;
using EBookStore.DTOs;
using EBookStore.Validators;
using AutoMapper;

namespace EBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(BookDto bookDto)
        {
            try
            {
                var validator = new BookDtoValidator();
                var validationResult = await validator.ValidateAsync(bookDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var book = _mapper.Map<Book>(bookDto);
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
