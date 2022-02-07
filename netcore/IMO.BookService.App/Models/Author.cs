using System.Collections.Generic;

namespace IMO.BookService.App.Models
{
    public class Author
    {
        public string Name { get; set; }

        public List<string> Books { get; set; }

        public List<string> Genres { get; set; }

        public Author()
        {
            Books = new List<string>();
            Genres = new List<string>();
        }
    }
}
