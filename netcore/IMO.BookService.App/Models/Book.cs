using System.Collections.Generic;

namespace IMO.BookService.App.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public List<string> Genres { get; set; }

        public Book()
        {
            Genres = new List<string>();
        }
    }
}
