using BookFriend.Models;

namespace BookFriend.Services
{
    public class BookService : IBookService
    {
        public Task<IEnumerable<Book>> GetBooksBySubject(string subject)
        {
            throw new NotImplementedException();
        }
    }
}
