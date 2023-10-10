using BookFriend.Models;
using BookFriend.Services;
using Microsoft.AspNetCore.Components;

namespace BookFriend.Pages
{
    public partial class Index
    {
        [Inject]
        public IBookService? BookService { get; set; }
        public List<Book> Books { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            Books = (await BookService.GetBooksBySubject("Math")).ToList();  
        }

    }
}
