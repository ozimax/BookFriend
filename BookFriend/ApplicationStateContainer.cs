using BookFriend.Models;

namespace BookFriend
{
    public class ApplicationStateContainer
    {
        public string SearchText { get; set; }

        //using the application state to pass an object from a page to another one
        public Book Value { get; set; }
        public event Action OnStateChange;
        public void SetValue(Book value)
        {
            this.Value = value;
            NotifyStateChanged();
        }
        private void NotifyStateChanged() => OnStateChange?.Invoke();
    }
}
