using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookFriend.Models
{
    public class BookCover
    {
        public string bib_key { get; set; }

        public string thumbnail_url { get; set; }
    }


}
