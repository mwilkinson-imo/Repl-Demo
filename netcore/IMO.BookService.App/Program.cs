using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using IMO.BookService.App.Models;


namespace IMO.BookService.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookAuthors = GetBookAuthors();
            Console.WriteLine($"Read data. Found {bookAuthors.Items.Length} entries");
            Console.WriteLine("Aggregating author info.");
            var authors = GetAuthors(bookAuthors);
            var output = JsonConvert.SerializeObject(authors, Formatting.Indented);
            Console.WriteLine("Aggregation done:" + Environment.NewLine + Environment.NewLine);
            Console.WriteLine(output);
            Console.ReadLine();
        }

        static BookAuthors GetBookAuthors()
        {
            var text = File.ReadAllText("Samples\\data.json");
            var bookAuthors = JsonConvert.DeserializeObject<BookAuthors>(text);
            return bookAuthors;
        }

        static List<Author> GetAuthors(BookAuthors bookAuthors)
        {
            var authors = new List<Author>();
            var uniqueGroups = bookAuthors.Items.GroupBy(x => x.Author);
            foreach (var grouping in uniqueGroups)
            {
                var author = new Author();
                author.Name = grouping.Key;
                foreach (var authorBook in grouping)
                {
                    author.Books.Add(authorBook.Title);
                    author.Genres.AddRange(authorBook.Genres);
                }
                author.Genres = author.Genres.Distinct().ToList();
                authors.Add(author);
            }

            return authors;
        }
    }
}