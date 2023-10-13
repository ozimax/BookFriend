using BookFriend.Models;
using Microsoft.VisualBasic;
//using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection.Metadata.Ecma335;
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
            int iSBNLimit = 6;

            var books = JsonSerializer.DeserializeAsync<BookContainer>
               (await _httpClient.GetStreamAsync($"https://openlibrary.org/search.json?q={subject}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Result.Books;

            
            try 
            {
                books.RemoveAll(b => b.CoverEditionKey == null);
                books.RemoveAll(b => b.ISBNs.Count() > iSBNLimit || b.ISBNs.Count() == 0);
                books = books.Take(take).ToList();

                var bookISBNList = books.Select(x => x.ISBNs.Take(1).ToList());
                var bookCoverList = await GetBookCoverList(bookISBNList.SelectMany(list => list).ToList());
                books = PrepareBooksWithCovers(books, bookCoverList);
                return books;
            }
            catch(Exception ex) 
            {
                return null;
            }
                       

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

        private List<Book> PrepareBooksWithCovers(List<Book> books, List<BookCover> bookCoverList) {
            int bookIndex = 0;
            int coverIndex = 0;

            while (coverIndex < bookCoverList.Count())
            {
                if (books[bookIndex].ISBNs[0] == bookCoverList[coverIndex].bib_key) {
                    books[bookIndex].Cover = bookCoverList[coverIndex];
                    bookIndex++; coverIndex++;
                }
                else {
                    bookIndex++;
                }
            }

            books.RemoveAll(b => b.Cover == null);

            return books;
        }
    }
}
