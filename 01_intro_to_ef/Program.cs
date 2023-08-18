using Microsoft.EntityFrameworkCore.Storage;

namespace _01_intro_to_ef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryDbContext db = new();

            // create new author
            var author = new Author()
            {
                Name = "Ivan",
                Surname = "Franko",
                CountryId = 1,
                Birthdate = new DateTime(1856, 8, 27) 
            };
            //db.Authors.Add(author);

            //db.Books.Add(new Book()
            //{
            //    Title = "Blue Sky",
            //    Year = 2017,
            //    Authors = new[] { author }
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
        }
    }
}