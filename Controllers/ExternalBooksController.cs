using Microsoft.AspNetCore.Mvc;
using EBookStore.Services;

namespace EBookStore.Controllers
{
    [ApiController]
    [Route("api/external-books")]
    public class ExternalBooksController : ControllerBase
    {
        private readonly ExternalBookService _externalBookService;

        public ExternalBooksController(ExternalBookService externalBookService)
        {
            _externalBookService = externalBookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetExternalBooks([FromQuery] string query = null)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return BadRequest("Please provide a search query");
                }

                var books = await _externalBookService.SearchBooksAsync(query);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
