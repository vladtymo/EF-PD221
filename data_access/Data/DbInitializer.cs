using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_access.Data
{
    public static class DbInitializer
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country() { Id = 1, Name = "Ukraine" },
                new Country() { Id = 2, Name = "Italy" },
                new Country() { Id = 3, Name = "Great Britain" },
                new Country() { Id = 4, Name = "France" }
            });

            modelBuilder.Entity<Author>().HasData(new Author[]
            {
                new Author() { Id = 1, Name = "Ivan", Surname = "Franko", CountryId = 1, Birthdate = new DateTime(1856, 8, 27)  },
                new Author() { Id = 2, Name = "Taras", Surname = "Shevchenko", CountryId = 1, Birthdate = new DateTime(1814, 3, 9) },
            });

            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book()
                {
                    Id = 1,
                    Title = "Blue Sky",
                    Year = 2017
                }
            });

            modelBuilder.Entity<Review>().HasData(new Review[]
            {
                new Review() {  Id = 1, Date = new DateTime(2023, 1, 5), Summary = "Everything is good!"},
            });
        }
    }
}
