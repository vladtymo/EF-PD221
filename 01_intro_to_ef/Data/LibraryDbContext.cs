using Microsoft.EntityFrameworkCore;

namespace _01_intro_to_ef
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base() 
        {
            //this.Database.EnsureDeleted();
            // create database if does not exist
            //this.Database.EnsureCreated();

            // Use Migrations instead: (install NuGet: EFCore.Tools)
            // - add-migration <MigrationName> - add new migration with available changes
            // - update-database               - update the database by the newest migration
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // enable lazy loading
            //optionsBuilder.UseLazyLoadingProxies();

            // Pooling=True;
            string conn = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFLibraryDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
            optionsBuilder.UseSqlServer(conn);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                new Review() {  BookId = 1, Date = new DateTime(2023, 1, 5), Summary = "Everything is good!"},
            });
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}