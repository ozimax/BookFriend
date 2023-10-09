using BookFriend.Models;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using System.Text.Json;

namespace BookFriend.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient? _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<BookContainer> GetBooksBySubject(string subject)
        {

            var bookList = JsonSerializer.DeserializeAsync<BookContainer>
               (await _httpClient.GetStreamAsync($"https://openlibrary.org/search.json?q={subject}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return bookList.Result;
            

        }
    }
}
