using BookFriend.Models;
using BookFriend.Services;
using Microsoft.AspNetCore.Components;

namespace BookFriend.Pages
{
    public partial class BookDetail
    {
        [Parameter]
        public Book Book { get; set; } = new Book();

        [Inject]
        public IBookService? BookService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ApplicationStateContainer StateContainer { get; set; }


        protected override void OnInitialized()
        {
            base.OnInitialized();
            Book = StateContainer.Value;
        }

        private void GoBackToMainPage()
        {
            StateContainer.SetValue(Book);
            NavigationManager.NavigateTo("/");
        }
    }
}
