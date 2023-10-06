using Newtonsoft.Json;

namespace BookFriend.Models
{
    public class BookCover
    {
        public Dictionary<string, BookInfo> Books { get; set; }
    }


    public class BookInfo
    {
        [JsonProperty("bib_key")]
        public string ISBN { get; set; }

        [JsonProperty("preview_url")]
        public string PreviewImage { get; set; }

        [JsonProperty("thumbnail_url")]
        public string ThumbnailImage { get; set; }
    }

}
