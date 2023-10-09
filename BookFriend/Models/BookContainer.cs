using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookFriend.Models
{
    public class BookContainer
    {
        [JsonPropertyName("numFound")]
        public int Count { get; set; }
        //public int NumFound { get; set; }
        public int Start { get; set; }
        public bool NumFoundExact { get; set; }

        [JsonPropertyName("docs")]
        public List<Book> Books { get; set; }
    }
}
