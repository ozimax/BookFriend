using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookFriend.Models
{
    public class Book
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author_name")]
        public List<string> AuthorNames { get; set; } = null;


        [JsonPropertyName("cover_edition_key")]
        public string CoverEditionKey { get; set; }



        [JsonPropertyName("first_publish_year")]
        public int PublishYear { get; set; }

        [JsonPropertyName("isbn")]
        public string[] ISBNs { get; set; }

        public BookCover Cover { get; set; }
    }
}
