using BookFriend.Models;
using Microsoft.VisualBasic;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace BookFriend.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient? _httpClient;

        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<Book>> GetBooksBySubject(string subject, int take = 20)
        {

            var books = JsonSerializer.DeserializeAsync<BookContainer>
               (await _httpClient.GetStreamAsync($"https://openlibrary.org/search.json?q={subject}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Result.Books;

            books.RemoveAll(b => b.CoverEditionKey == null);
            books.RemoveAll(b => b.ISBNs.Count() > 4);

            books = books.Take(5).ToList();

            var bookISBNList = books.Select(x => x.ISBNs.Take(1).ToList());

            var jjj = await GetBookCoverList(bookISBNList.SelectMany(list => list).ToList());

            return books;            

        }

        public async Task<List<BookCover>> GetBookCoverList(List<string> ISBNs) 
        {
            string commaSeparatedISBNs = string.Join(",", ISBNs);

            var coverDict = JsonSerializer.DeserializeAsync<Dictionary<string, BookCover>>
               (await _httpClient.GetStreamAsync($"https://openlibrary.org/api/books?bibkeys={commaSeparatedISBNs}&format=json"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Result;

            var covers = new List<BookCover>();

            foreach (var cover in coverDict) 
            {
                if (!String.IsNullOrEmpty(cover.Value.thumbnail_url))
                    covers.Add(cover.Value);
            }

            return covers;
        }
    }
}
