using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookFriend.Models
{
    public class BookCover
    {
        public string bib_key { get; set; }

        public string thumbnail_url { get; set; }

        public string MediumImage_url
        {
            get
            {
                return thumbnail_url.Replace("S.jpg", "M.jpg");
            }
        }


        public string LargeImage_url
        {
            get
            {
                return thumbnail_url.Replace("S.jpg", "L.jpg");
            }
        }
    }


}
