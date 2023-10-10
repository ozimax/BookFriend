using BookFriend.Models;

namespace BookFriend.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksBySubject(string subject, int take = 20);

        Task<List<BookCover>> GetBookCoverList(List<string> ISBNs);
    }
}
