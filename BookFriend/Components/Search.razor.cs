using Microsoft.AspNetCore.Components;

namespace BookFriend.Components
{
    public partial class Search
    {
        private string searchText;

        [Parameter]
        public EventCallback<string> OnSearchText { get; set; }

        private async Task OnSearch()
        {
            await OnSearchText.InvokeAsync(searchText);
        }
    }
}
