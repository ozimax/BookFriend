using BookFriend.Models;

namespace BookFriend.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetBooksBySubject(string subject);
    }
}
