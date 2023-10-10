using BookFriend.Models;
using Microsoft.AspNetCore.Components;

namespace BookFriend.Components
{
    public partial class BookItem
    {
        [Parameter]
        public Book Book { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; }
    }
}
