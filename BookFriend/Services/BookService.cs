using BookFriend.Models;
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
        public async Task<IEnumerable<Book>> GetBooksBySubject(string subject)
        {
            //fix root object in json for parsing
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Book>>
                    (await _httpClient.GetStreamAsync($"https://openlibrary.org/search.json?q={subject}"));


            return list;

        }
    }
}
