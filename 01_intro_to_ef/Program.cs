using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace _01_intro_to_ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext db = new();

            // create new author
            //var author = new Author()
            //{
            //    Name = "Ivan",
            //    Surname = "Franko",
            //    CountryId = 1,
            //    Birthdate = new DateTime(1856, 8, 27) 
            //};
            //db.Authors.Add(author);

            //db.Books.Add(new Book()
            //{
            //    Title = ".NET 7 Tutorial",
            //    Year = 2022,
            //    Description = "It's official .NET documentation."
            //});

            db.SaveChanges(); // submit all changes to db

            foreach (var c in db.Countries)
            {
                Console.WriteLine($"[{c.Id}] - {c.Name}");
            }

            foreach (var a in db.Authors)
            {
                Console.WriteLine($"[{a.Id}] - {a.Name} rating: {a.Rating}");
            }

            // filtering: show all books during the last 5 years

            var books = db.Books.Where(x => x.Year >= DateTime.Now.Year - 5);

            Console.WriteLine("Book during the last 5 years:");
            foreach (var i in books)
            {
                Console.WriteLine(i);
            }

            LoadingTypes(db);
        }

        static void LoadingTypes(LibraryDbContext db)
        {
            // -------------------- Loading Types
            // 1 - eager loaing

            // TASK: show all authors
            // .Include(navigation property) - do LEFT JOIN in SQL
            var authors = db.Authors.Include(x => x.Country)
                                    .Include(x => x.Books).ThenInclude(x => x.Review);

            Console.WriteLine("All authors");
            foreach (var i in authors)
            {
                Console.WriteLine($"Author: {i.Name} {i.Surname} Country: {i.Country?.Name} {i.Country.Authors.Count} Books: {i.Books.Count}");
            }

            Console.WriteLine(authors.First().Books.First().Review?.Summary);

            // 2 - lazy loading

            var res = db.Books; // without JOIN

            foreach (var book in res)
            {
                Console.WriteLine($"Book with description: {book.Title} {book.Review?.Summary}");
            }

            // 3 - explicit loading
            var author = db.Authors.Find(1);

            Console.WriteLine($"{author.Name} {author.Surname}");

            // .Reference().Load() - load signle object
            // .Collection().Load() - load collection data

            db.Entry(author).Reference(x => x.Country).Load();
            db.Entry(author).Collection(x => x.Books).Load();

            Console.WriteLine($"{author.Country?.Name}");
            Console.WriteLine($"{author.Books.Count}");
        }
    }
}