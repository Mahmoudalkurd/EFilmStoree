using System.Text.Json;
using EBookStore.DTOs;
using EBookStore.Models;

namespace EBookStore.Services
{
    public class ExternalBookService
    {
        private readonly HttpClient _httpClient;

        public ExternalBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ExternalBookDto>> SearchBooksAsync(string searchTerm)
        {
            var response = await _httpClient.GetAsync($"https://www.googleapis.com/books/v1/volumes?q={searchTerm}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Failed to fetch books: {response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<GoogleBooksResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (result?.Items == null)
            {
                return new List<ExternalBookDto>();
            }

            return result.Items.Select(book => new ExternalBookDto
            {
                Title = book.VolumeInfo?.Title ?? "Ingen titel",
                Author = book.VolumeInfo?.Authors?.FirstOrDefault() ?? "Okänd",
                CoverUrl = book.VolumeInfo?.ImageLinks?.Thumbnail
            }).ToList();
        }
    }
}
