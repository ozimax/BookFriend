using BookFriend.Models;
using BookFriend.Services;
using Microsoft.AspNetCore.Components;

namespace BookFriend.Pages
{
    public partial class FetchData
    {

        public List<Book> Books { get; set; } = default!;

        [Inject]
        public IBookService? BookService { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Books = (await BookService.GetBooksBySubject("Math"));

            if (true) { }
        }
    }
}
