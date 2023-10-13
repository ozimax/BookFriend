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

        [JsonPropertyName("publisher_facet")]
        public List<string> Publishers { get; set; } = null;


        [JsonPropertyName("cover_edition_key")]
        public string CoverEditionKey { get; set; }



        [JsonPropertyName("first_publish_year")]
        public int PublishYear { get; set; }

        [JsonPropertyName("isbn")]
        public List<string> ISBNs { get; set; } = new List<string>();

        public BookCover Cover { get; set; }
    }
}
