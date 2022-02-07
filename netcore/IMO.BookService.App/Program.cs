using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using IMO.BookService.App.Models;

namespace IMO.BookService.App
{
    /// <summary>
    /// A command line utility that allows for access and modification to a books data set.
    /// Utility currently only supports dataset generation and dataset fetching.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1 && args[0] == "-g")
            {
                var books = GenerateSampleBooks(15);
                var output = JsonConvert.SerializeObject(books, Formatting.Indented);
                File.WriteAllText("Samples/data.json", output);
            }
            else
            {
                var books = FetchAllBooks();
                var output = JsonConvert.SerializeObject(books, Formatting.Indented);
                Console.WriteLine(output);
            }
        }

        static Book[] FetchAllBooks()
        {
            var text = File.ReadAllText("Samples/data.json");
            var books = JsonConvert.DeserializeObject<Book[]>(text);
            return books;
        }

        /// <summary>
        /// Function for generating sample book data. 
        /// All books include a generated AuthorName, Title, and 2 Genres.
        /// </summary>
        /// <param name="numberOfBooks"></param>
        /// <returns></returns>
        static Book[] GenerateSampleBooks(int numberOfBooks)
        {
            var sampleBooks = new List<Book>();
            var random = new Random();
            for (var i = 0; i < numberOfBooks; i++)
            {
                var sampleBook = new Book();
                var firstNames = new[] { "Alisha", "Harris", "Mike", "Reynard", "Amy", "Charise", "A. B.", "Rudiger" };
                var authorFirstName = firstNames[random.Next(firstNames.Length)];

                var lastNames = new[] { "Jones", "McGee", "Smith", "Chandler", "Charlot", "Ali" };
                var authorLastName = lastNames[random.Next(lastNames.Length)];

                sampleBook.Author = $"{authorFirstName} {authorLastName}";

                var genres = new[] { "Fiction", "Thriller", "True Crime", "Non-Fiction", "Graphic Novel", "Children's" };
                var selectedGenres = genres.OrderBy(x => random.Next()).Take(2);

                sampleBook.Genres.AddRange(selectedGenres);

                var modifiers = new[] { "The", "That", "This", "The Only", "The First", "The Last" };
                var modifier = modifiers[random.Next(modifiers.Length)];

                var adjectives = new[] { "Happy", "Hungry", "Sad", "Grumpy", "Sleepy", "Nervous", "Ornery" };
                var adjective = adjectives[random.Next(adjectives.Length)];

                var animals = new[] { "Falcon", "Deer", "Coyote", "Rabbit", "Squirrel", "Cat", "Dog", "Iguana", "Chinchilla" };
                var animal = animals[random.Next(animals.Length)];

                sampleBook.Title = $"{modifier} {adjective} {animal}";
                sampleBooks.Add(sampleBook);
            }
            return sampleBooks.ToArray();
        }

        /// <summary>
        /// Feature-Request: Clients want to be able to display the names of the Authors we support.
        /// </summary>
        static string[] GetAuthors()
        {
            return new string[0];
        }

        /// <summary>
        /// Feature-Request: Clients want to be able to search for books by a certain author.
        /// </summary>
        /// <returns></returns>
        static Book[] GetBooksByAuthorName()
        {
            return new Book[0];
        }

        /// <summary>
        /// Feature-Request: Clients want to be able to search for books within a genre.
        /// </summary>
        /// <returns></returns>
        static Book[] GetBooksByGenre()
        {
            return new Book[0];
        }
    }
}