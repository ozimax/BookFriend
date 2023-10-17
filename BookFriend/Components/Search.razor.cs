using Microsoft.AspNetCore.Components;

namespace BookFriend.Components
{
    public partial class Search
    {
        private string searchText;

        [Inject]
        public ApplicationStateContainer StateContainer { get; set; }

        [Parameter]
        public EventCallback<string> OnSearchText { get; set; }

        private async Task OnSearch()
        {
            StateContainer.SearchText = searchText;
            await OnSearchText.InvokeAsync(searchText);
        }
    }
}
