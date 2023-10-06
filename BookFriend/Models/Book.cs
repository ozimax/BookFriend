using Newtonsoft.Json;

namespace BookFriend.Models
{
    public class Book
    {

        [JsonProperty("author_name")]
        public List<string> AuthorNames { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }


        [JsonProperty("first_publish_year")]
        public string PublishYear { get; set; }

        [JsonProperty("isbn")]
        public List<string> ISBNs { get; set; }

        public BookCover Cover { get; set; }
    }
}
