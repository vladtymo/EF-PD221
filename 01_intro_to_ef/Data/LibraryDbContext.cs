using Microsoft.EntityFrameworkCore;

namespace _01_intro_to_ef
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext() : base() 
        {
            this.Database.EnsureDeleted();
            // create if database does not exist
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

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

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}