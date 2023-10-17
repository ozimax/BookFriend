using BookFriend.Models;
using BookFriend.Services;
using Microsoft.AspNetCore.Components;

namespace BookFriend.Pages
{
    public partial class Index
    {
        [Inject]
        public IBookService? BookService { get; set; }

        [Inject]
        public ApplicationStateContainer StateContainer { get; set; }
        public List<Book> Books { get; set; }

        private string searchText;

        protected override async Task OnInitializedAsync()
        {
            searchText = StateContainer.SearchText ?? "Kung Fu";
            Books = (await BookService.GetBooksBySubject(searchText)).ToList();  
        }

        private async Task HandleSearchAsync(string text)
        {
            Books = null;
            searchText = text;
            Books = (await BookService.GetBooksBySubject(searchText)).ToList();
        }

    }
}
