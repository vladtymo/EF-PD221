using data_access.Data;
using data_access.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace data_access
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

            // -------------------- Fluent API configurations
            // Author
            modelBuilder.ApplyConfiguration(new AuthorConfigs());

            // Book
            modelBuilder.Entity<Book>().Property(x => x.Title).IsRequired(false).HasMaxLength(200);
            modelBuilder.Entity<Book>().HasOne(x => x.Review)
                                        .WithOne(x => x.Book)
                                        .HasForeignKey<Review>(x => x.Id)
                                        .IsRequired();
            // Review
            modelBuilder.Entity<Review>().HasKey(x => x.Id).HasName("BookId");

            // -------------------- Seed Data
            DbInitializer.SeedData(modelBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}