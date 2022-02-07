using Newtonsoft.Json;

namespace IMO.BookService.App.Models
{
    public class BookAuthors
    {
        [JsonProperty("BookAuthors")]
        public BookAuthor[] Items { get; set; }
    }

    public class BookAuthor
    {
        [JsonProperty("BookTitle")]
        public string Title { get; set; }
        public string Author { get; set; }
        public string[] Genres { get; set; }
    }
}
