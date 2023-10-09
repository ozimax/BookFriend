using BookFriend.Models;

namespace BookFriend.Services
{
    public interface IBookService
    {
        Task<BookContainer> GetBooksBySubject(string subject);
    }
}
